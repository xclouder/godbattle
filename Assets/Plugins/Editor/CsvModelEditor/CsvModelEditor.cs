using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.CsvModelEditor
{
    public class CsvModelEditor : EditorWindow
    {
        private readonly System.Diagnostics.Stopwatch _stopWatch = new System.Diagnostics.Stopwatch();
        private List<BaseProperty> _windows = new List<BaseProperty>();
        private List<BaseProperty> _waitingWindows;

        private Vector2 _mousePos;

        private float _panY;
        private float _panX;

        private bool _scrollWindow;
        private Vector2 _scrollStartMousePos;

        private readonly Dictionary<String, Action> _createPropertyActions = new Dictionary<String, Action>();
        private readonly Dictionary<String, Action<PropertyObject>> _rebuildPropertyActions = new Dictionary<String, Action<PropertyObject>>();

        private String _currentFilePath;
        private Boolean _isDirtyFile;
        private const Int32 PanelWidth = 250;
        private Vector2 _scollPosition = Vector2.zero;
        private String _modelDescription = String.Empty;

        public CsvModelEditor()
        {
            title = "Untitled";
            _createPropertyActions.Add("Int32", CreatePropertyInstance<Int32Property>);
            _createPropertyActions.Add("Int64", CreatePropertyInstance<Int64Property>);
            _createPropertyActions.Add("String", CreatePropertyInstance<StringProperty>);
            _createPropertyActions.Add("Single", CreatePropertyInstance<FloatProperty>);
            _createPropertyActions.Add("Double", CreatePropertyInstance<DoubleProperty>);
            _createPropertyActions.Add("Decimal", CreatePropertyInstance<DecimalProperty>);
            _createPropertyActions.Add("Custom", CreatePropertyInstance<CustomProperty>);
            _createPropertyActions.Add("Open", OpenFile);
            _createPropertyActions.Add("OpenCsv", OpenCsvFile);
            _createPropertyActions.Add("Save", SaveFile);
            _createPropertyActions.Add("SaveAs", SaveAsFile);
            _createPropertyActions.Add("Generate", GenerateModel);
            _createPropertyActions.Add("Delete", DeleteProperty);
            _createPropertyActions.Add("Close", CloseFlie);
            _createPropertyActions.Add("AutoLayout", AutoLayout);

            _rebuildPropertyActions.Add("Int32", RebuildPropertyInstance<Int32Property>);
            _rebuildPropertyActions.Add("Int64", RebuildPropertyInstance<Int64Property>);
            _rebuildPropertyActions.Add("String", RebuildPropertyInstance<StringProperty>);
            _rebuildPropertyActions.Add("Single", RebuildPropertyInstance<FloatProperty>);
            _rebuildPropertyActions.Add("Double", RebuildPropertyInstance<DoubleProperty>);
            _rebuildPropertyActions.Add("Decimal", RebuildPropertyInstance<DecimalProperty>);
            _rebuildPropertyActions.Add("Custom", RebuildPropertyInstance<CustomProperty>);
        }

        [MenuItem("Tools/CsvModel Tools/CsvModel Editor")]
        private static void Init()
        {
            var editor = GetWindow<CsvModelEditor>();
            if (editor.position.width < 800)
            {
                editor.position = new Rect(50, 50, 800, 500);
            }
            editor._stopWatch.Start();
        }

        private void Update()
        {
            var dTime = _stopWatch.ElapsedMilliseconds;
            var deltaTime = ((Single)dTime) / 1000;

            foreach (var prop in _windows)
            {
                prop.Tick(deltaTime);
            }

            _stopWatch.Reset();
            _stopWatch.Start();

            Repaint();
        }

        private void OnGUI()
        {
            title = String.Format("{0}{1}", _isDirtyFile && !title.StartsWith("*") ? "*" : String.Empty,
                _currentFilePath != null ? Path.GetFileName(_currentFilePath) : title);

            var e = Event.current;
            _mousePos = e.mousePosition;

            if (_waitingWindows != null)
            {
                _windows = _waitingWindows;
                _currentFilePath = null;
                _waitingWindows = null;
                _modelDescription = String.Empty;
            }

            if (e.button == 1 && e.type == EventType.MouseDown)
            {
                ShowContextMenu();
                e.Use();
            }

            if (e.button == 0 && e.isMouse && e.type == EventType.MouseDown)
            {
                ActivateWindow();
            }

            DrawWindows();
            UpdateScrollStatus(e);
        }

        private string PreviousOpenPath
        {
            get
            {
                return EditorPrefs.GetString("CSVModelEditor_PreviousOpenPath", null);
            }
            set
            {
                EditorPrefs.SetString("CSVModelEditor_PreviousOpenPath", value);
            }
        }

        private string PreviousOpenCsvPath
        {
            get
            {
                return EditorPrefs.GetString("CSVModelEditor_PreviousOpenCsvPath", null);
            }
            set
            {
                EditorPrefs.SetString("CSVModelEditor_PreviousOpenCsvPath", value);
            }
        }

        private string PreviousExportPath
        {
            get
            {
                return EditorPrefs.GetString("CSVModelEditor_PreviousExportPath", null);
            }
            set
            {
                EditorPrefs.SetString("CSVModelEditor_PreviousExportPath", value);
            }
        }

        private void CloseFlie()
        {
            if (_windows.Count > 0)
            {
                var msg = String.IsNullOrEmpty(_currentFilePath)
                    ? "当前模型未保存，你确定要关闭？"
                    : "你确定要关闭模型？";

                if (!EditorUtility.DisplayDialog("确认", msg, "确定", "取消"))
                {
                    return;
                }

                _windows.Clear();
            }

            _isDirtyFile = false;
            title = "Untitled";
            _currentFilePath = null;
            _modelDescription = String.Empty;
        }

        private ModelMeta CurrentModelMeta
        {
            get
            {
                return new ModelMeta
                {
                    Description = _modelDescription,
                    PropertyObjectWrappers = _windows.Select(w => w.PropertyObject.PropertyObjectWrapper).ToList()
                };
            }
        }

        private void RebuildPropertyInstances(IEnumerable<PropertyObject> propertyObjects)
        {
            _windows.Clear();
            foreach (var propertyObject in propertyObjects)
            {
                var typeName = propertyObject.IsCustomType ? "Custom" : propertyObject.DataType.ToString();
                _rebuildPropertyActions[typeName](propertyObject);
            }
        }

        private void RebuildPropertyInstance<T>(PropertyObject propertyObject) where T : BaseProperty
        {
            var property = CreateInstance<T>();
            property.PropertyObject = propertyObject;
            property.InitWindowRect(propertyObject.Left, propertyObject.Top);
            _windows.Add(property);
        }

        private void OpenFile()
        {
            try
            {
                if (_windows.Count == 0 ||
                    (_windows.Count > 0 && EditorUtility.DisplayDialog("确认", "你确定要关闭当前模型，并加载其他 CSV 模型文件？", "确定", "取消")))
                {
                    var path = EditorUtility.OpenFilePanel("Open Flie", PreviousOpenPath ?? Application.dataPath, "csvm");

                    if (File.Exists(path))
                    {
                        PreviousOpenPath = path;
                        ModelMeta modelMeta;

                        using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            var formatter = new BinaryFormatter();
                            modelMeta = formatter.Deserialize(fs) as ModelMeta;
                        }

                        if (modelMeta != null)
                        {
                            if (modelMeta.PropertyObjectWrappers != null && modelMeta.PropertyObjectWrappers.Count > 0)
                            {
                                RebuildPropertyInstances(modelMeta.PropertyObjectWrappers.Select(w => w.PropertyObject));
                            }
                            _modelDescription = modelMeta.Description;
                            _currentFilePath = path;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                EditorUtility.DisplayDialog("异常", exception.Message, "确定");
            }
        }

        private void OpenCsvFile()
        {
            var path = EditorUtility.OpenFilePanel("Open Csv Flie", PreviousOpenCsvPath ?? Application.dataPath, "csv");
            if (File.Exists(path))
            {
                PreviousOpenCsvPath = path;

                var props = CsvEditorUtility.ExportFromCsvFile(path);
                AutoLayout(props);
                _waitingWindows = props;
            }
        }

        private void AutoLayout(List<BaseProperty> windows)
        {
            var rows = (Int32)((position.width - PanelWidth - 15f) / 270);
            for (var i = 0; i < windows.Count; i++)
            {
                var left = PanelWidth + 15f + (i % rows) * 270f;
                var top = 20f + (i / rows) * 140;
                windows[i].InitWindowRect(left, top);
            }
        }

        private void AutoLayout()
        {
            AutoLayout(_windows);
        }

        private void SaveFile()
        {
            var path = _currentFilePath ?? EditorUtility.SaveFilePanel("Save File", "", "", "csvm");

            if (!String.IsNullOrEmpty(path))
            {
                try
                {
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        var formatter = new BinaryFormatter();
                        formatter.Serialize(fs, CurrentModelMeta);
                    }

                    _currentFilePath = path;
                    _isDirtyFile = false;
                    EditorUtility.DisplayDialog("提示", String.Format("文件成功保存到 {0} 。", path), "确定");
                }
                catch (Exception exception)
                {
                    EditorUtility.DisplayDialog("异常", exception.Message, "确定");
                }
            }
        }

        private void SaveAsFile()
        {
            var path = EditorUtility.SaveFilePanel("Save File", "", "", "csvm");
            if (!String.IsNullOrEmpty(path))
            {
                try
                {
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        var formatter = new BinaryFormatter();
                        formatter.Serialize(fs, CurrentModelMeta);
                    }

                    _currentFilePath = path;
                    _isDirtyFile = false;
                    EditorUtility.DisplayDialog("提示", String.Format("文件另存为 {0} 操作成功。", path), "确定");
                }
                catch (Exception exception)
                {
                    EditorUtility.DisplayDialog("异常", exception.Message, "确定");
                }
            }
        }

        private void GenerateModel()
        {
            var path = EditorUtility.SaveFilePanel("Export Model Code", PreviousExportPath ?? String.Empty, String.Empty, "cs");

            if (String.IsNullOrEmpty(path))
            {
                return;
            }

            try
            {
                PreviousExportPath = path;
                var preExtension = Path.GetExtension(path);
                var csvFilePath = String.Format("{0}.csv", path.Substring(0, path.Length - preExtension.Length));
                if (File.Exists(csvFilePath) &&
                    !EditorUtility.DisplayDialog("确认", String.Format("你确定要覆盖 CSV 模板文件 {0} ？", csvFilePath), "确定", "取消"))
                {
                    return;
                }

                SaveModelCodeToFile(path, csvFilePath);
                EditorUtility.DisplayDialog("提示", String.Format("操作成功，模型代码导出到文件 {0}，CSV模板导出到文件 {1} 。", path, csvFilePath), "确定");
            }
            catch (Exception exception)
            {
                EditorUtility.DisplayDialog("异常", exception.Message, "确定");
            }
        }

        private void SaveModelCodeToFile(String path, String csvFilePath)
        {
            var code = GenerateModelCode(Path.GetFileNameWithoutExtension(path).ToTitleCaseAndRemoveAllWhitespace());
            using (var sw = new StreamWriter(new FileStream(path, FileMode.Create), Encoding.UTF8))
            {
                sw.Write(code);
            }

            var csv = GenerateCsv();
            using (var sw = new StreamWriter(new FileStream(csvFilePath, FileMode.Create), new UTF8Encoding(false)))
            {
                sw.Write(csv);
            }
        }

        private String GenerateCsv()
        {
            var existNames = new HashSet<String>();
            var existPops = new List<PropertyObject>();

            var props = _windows.Where(w => w.PropertyObject.IsValid()).Select(w => w.PropertyObject).ToList();

            foreach (var prop in props)
            {
                var pn = prop.PropertyName.Trim();
                if (!existNames.Contains(pn))
                {
                    existNames.Add(pn);
                    existPops.Add(prop);
                }
            }

            var sb = new StringBuilder();
            sb.AppendLine(String.Join(",",
                existPops.Select(p => p.CsvFieldNameCode).ToArray()));
            sb.AppendLine(String.Join(",",
                existPops.Select(p => p.CsvFieldTypeCode).ToArray()));
            sb.AppendLine(String.Join(",",
                existPops.Select(p => !String.IsNullOrEmpty(p.Annotation) ? p.Annotation : "缺少注释").ToArray()));
            return sb.ToString();
        }

        private String GenerateModelCode(String className)
        {
            var sb = new StringBuilder();
            sb.AppendLine("using System;");
            sb.AppendLine();
            sb.AppendLine("/// <summary>");
            foreach (var s in _modelDescription.Split('\n').Where(x => !String.IsNullOrEmpty(x)))
            {
                sb.AppendLine(String.Format("/// {0}", s.Trim()));
            }
            sb.AppendLine("/// </summary>");
            sb.AppendLine(String.Format("public class {0}", className));
            sb.AppendLine("{");

            var existNames = new HashSet<String>();
            var props = _windows.Where(w => w.PropertyObject.IsValid()).Select(w => w.PropertyObject).ToList();
            if (props.Count != _windows.Count)
            {
                EditorUtility.DisplayDialog("提示", "空属性及重名的属性将不会输出到文件。", "确定");
            }

            foreach (var prop in props)
            {
                var pn = prop.PropertyName.Trim();
                if (!existNames.Contains(pn))
                {
                    existNames.Add(pn);
                    sb.AppendLine(prop.PropertyCode);
                }
            }

            sb.AppendLine("}");
            return sb.ToString();
        }

        private void ActivateWindow(Int32 id = -1)
        {
            for (int i = 0; i < _windows.Count; i++)
            {
                var window = _windows[i];
                window.IsActive = i == id || window.WindowRect.Contains(_mousePos);
            }
        }

        private void UpdateScrollStatus(Event e)
        {
            if (e.keyCode == KeyCode.A && e.type == EventType.KeyDown)
            {
                if (_scrollWindow)
                {
                    _scrollWindow = false;
                }
                else
                {
                    _scrollStartMousePos = e.mousePosition;
                    _scrollWindow = true;
                }
            }

            if (e.button == 2)
            {
                if (e.type == EventType.MouseDown)
                {
                    _scrollStartMousePos = e.mousePosition;
                    _scrollWindow = true;
                }
                else if (e.type == EventType.MouseUp)
                {
                    _scrollWindow = false;
                }
            }

            if (_scrollWindow)
            {
                Vector2 mouseDiff = e.mousePosition - _scrollStartMousePos;
                _panX += mouseDiff.x / 100;
                _panY += mouseDiff.y / 100;
            }
        }

        private void ShowContextMenu()
        {
            if (_mousePos.x <= PanelWidth)
            {
                return;
            }

            if (_windows.Any(t => t.WindowRect.Contains(_mousePos)))
            {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent("Delete Property"), false, ContextCallback, "Delete");
                menu.ShowAsContext();
            }
            else
            {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent("Add String Property"), false, ContextCallback, "String");
                menu.AddItem(new GUIContent("Add Int32 Property"), false, ContextCallback, "Int32");
                menu.AddItem(new GUIContent("Add Int64 Property"), false, ContextCallback, "Int64");
                menu.AddItem(new GUIContent("Add Single Property"), false, ContextCallback, "Single");
                menu.AddItem(new GUIContent("Add Double Property"), false, ContextCallback, "Double");
                menu.AddItem(new GUIContent("Add Decimal Property"), false, ContextCallback, "Decimal");
                menu.AddSeparator(String.Empty);
                menu.AddItem(new GUIContent("Add Custom Property"), false, ContextCallback, "Custom");
                menu.AddSeparator(String.Empty);
                menu.AddItem(new GUIContent("Open"), false, ContextCallback, "Open");
                menu.AddItem(new GUIContent("Open Csv"), false, ContextCallback, "OpenCsv");
                if (_windows.Count > 0)
                {
                    menu.AddItem(new GUIContent("Save"), false, ContextCallback, "Save");
                    menu.AddItem(new GUIContent("SaveAs"), false, ContextCallback, "SaveAs");
                    menu.AddSeparator(String.Empty);
                    menu.AddItem(new GUIContent("Export Model Code"), false, ContextCallback, "Generate");
                    menu.AddSeparator(String.Empty);
                    menu.AddItem(new GUIContent("Auto Layout"), false, ContextCallback, "AutoLayout");
                    menu.AddSeparator(String.Empty);
                    menu.AddItem(new GUIContent("Close"), false, ContextCallback, "Close");
                }
                menu.ShowAsContext();
            }
        }

        private void DrawWindows()
        {
            GUI.BeginGroup(new Rect(_panX, _panY, Screen.width, Screen.height));
            GUILayout.BeginVertical(GUI.skin.box, GUILayout.Width(PanelWidth), GUILayout.Height(position.height - 9));
            _scollPosition = GUILayout.BeginScrollView(_scollPosition, false, false, GUILayout.Width(PanelWidth), GUILayout.Height(position.height - 12));
            EditorGUILayout.Foldout(true, "模型文件名称");
            GUILayout.Button(String.IsNullOrEmpty(title) ? "Untitled" : title, GUI.skin.textField);

            EditorGUILayout.Space();
            EditorGUILayout.Foldout(true, "模型描述信息");
            _modelDescription = GUILayout.TextArea(_modelDescription, GUILayout.Height(50));

            EditorGUILayout.Space();
            EditorGUILayout.Foldout(true, String.Format("属性列表[{0}]", _windows.Count));
            for (var i = 0; i < _windows.Count; i++)
            {
                GUI.color = _windows[i].Color;
                if (GUILayout.Button(_windows[i].WindowTitle, GUI.skin.textField))
                {
                    GUI.FocusWindow(i);
                    ActivateWindow(i);
                }
            }

            if (_windows.Count > 0)
            {
                GUI.color = BaseProperty.DefaultColor;
                EditorGUILayout.Space();
                GUILayout.BeginHorizontal(GUI.skin.box);
                if (GUILayout.Button("  Save  ", GUI.skin.textField, GUILayout.Width(60)))
                {
                    SaveFile();
                }
                if (GUILayout.Button(" SaveAs ", GUI.skin.textField, GUILayout.Width(60)))
                {
                    SaveAsFile();
                }

                if (GUILayout.Button(" Export ", GUI.skin.textField, GUILayout.Width(60)))
                {
                    GenerateModel();
                }

                //EditorGUILayout.Space();
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
            GUILayout.EndVertical();

            BeginWindows();
            for (var i = 0; i < _windows.Count; i++)
            {
                GUI.color = _windows[i].Color;
                _windows[i].WindowRect = ClampToScreen(GUI.Window(i, _windows[i].WindowRect, DrawWindowById, String.Empty, GUI.skin.textField));
            }
            EndWindows();
            GUI.EndGroup();
        }

        private void DrawWindowById(int id)
        {
            _windows[id].DrawWindow();
            GUI.DragWindow();
        }

        private Rect ClampToScreen(Rect rect)
        {
            rect.x = Mathf.Clamp(rect.x, PanelWidth + 10, position.width - rect.width);
            rect.y = Mathf.Clamp(rect.y, 0, position.height - rect.height);
            return rect;
        }

        private void ContextCallback(object obj)
        {
            var clb = obj.ToString();

            if (_createPropertyActions.ContainsKey(clb))
            {
                _createPropertyActions[clb]();

            }
        }

        private void CreatePropertyInstance<T>() where T : BaseProperty
        {
            var property = CreateInstance<T>();
            property.InitWindowRect(_mousePos.x, _mousePos.y);
            property.IsActive = true;
            _windows.Add(property);
            _isDirtyFile = true;
        }

        private void DeleteProperty()
        {
            var clickedOnWindow = false;
            var selectedIndex = -1;

            for (var i = 0; i < _windows.Count; i++)
            {
                if (_windows[i].WindowRect.Contains(_mousePos))
                {
                    selectedIndex = i;
                    clickedOnWindow = true;
                    break;
                }
            }


            if (clickedOnWindow)
            {
                var selProperty = _windows[selectedIndex];
                _windows.RemoveAt(selectedIndex);
                _isDirtyFile = true;

                foreach (var n in _windows)
                {
                    n.NodeDeleted(selProperty);
                }
            }
        }
    }
}
