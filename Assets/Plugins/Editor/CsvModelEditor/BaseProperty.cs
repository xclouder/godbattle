using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.CsvModelEditor
{
    public class BaseProperty : ScriptableObject
    {
        public static readonly Color DefaultColor = GUI.color;

        public Rect WindowRect;
        public string WindowTitle = "Property";

        protected SerializedObject SerializedObject = new SerializedObject(CreateInstance<PropertyObject>());

        public Boolean IsActive { get; set; }

        public Color Color
        {
            get { return IsActive ? Color.cyan : DefaultColor; }
        }

        public PropertyObject PropertyObject
        {
            get
            {
                return ((PropertyObject)SerializedObject.targetObject);
            }
            set
            {
                if (value != null)
                {
                    SerializedObject = new SerializedObject(value);
                }
            }
        }

        public virtual void InitWindowRect(Single left, Single top)
        {
            WindowRect = new Rect(left, top, 250, 140);
        }

        public void DrawWindow()
        {
            SerializedObject.UpdateIfDirtyOrScript();
            //EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.BeginVertical();
            EditorGUILayout.Space();
            //EditorGUILayout.Foldout(true, "属性信息");
            DrawFileds();
            EditorGUILayout.EndHorizontal();
            SerializedObject.ApplyModifiedProperties();
            ChangeWinTitle();
            UpdateSerializedObjectPosition();
        }

        private void UpdateSerializedObjectPosition()
        {
            var prop = ((PropertyObject)SerializedObject.targetObject);
            prop.Left = WindowRect.position.x;
            prop.Top = WindowRect.position.y;
        }

        protected virtual void ChangeWinTitle()
        {
            var prop = (PropertyObject)SerializedObject.targetObject;
            WindowTitle = String.IsNullOrEmpty(prop.PropertyName) ? String.Format("{0} Property", prop.DataType) : String.Format("{0} [{1} {2}]", prop.PropertyName, prop.DataType, prop.IsArray?"Array": String.Empty);
        }

        protected virtual void DrawFileds()
        {
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("PropertyName"), true, GUILayout.MinWidth(50));
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("CsvFieldName"), true, GUILayout.MinWidth(50));
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("DataType"), true, GUILayout.MinWidth(50));
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("OnlyRead"), true, GUILayout.MinWidth(50));
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("Annotation"), true, GUILayout.MinWidth(50));
            DrawProperty(SerializedObject.FindProperty("PropertyName"));
            DrawProperty(SerializedObject.FindProperty("CsvFieldName"));
            DrawProperty(SerializedObject.FindProperty("DataType"));
            DrawProperty(SerializedObject.FindProperty("IsArray"));
            DrawProperty(SerializedObject.FindProperty("OnlyRead"));
            DrawProperty(SerializedObject.FindProperty("IsGuarded"));
            DrawProperty(SerializedObject.FindProperty("Annotation"));
        }

        protected void DrawProperty(SerializedProperty prop, Single labelMinWidth = 100, Single fieldMinWidth=100)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(prop.name, GUILayout.MinWidth(labelMinWidth));
            GUILayout.FlexibleSpace();
            EditorGUILayout.PropertyField(prop, GUIContent.none, true, GUILayout.MinWidth(fieldMinWidth));
            GUILayout.EndHorizontal();
        }

        public virtual void NodeDeleted(BaseProperty property)
        {

        }

        public virtual void Tick(float deltaTime)
        {

        }
    }
}
