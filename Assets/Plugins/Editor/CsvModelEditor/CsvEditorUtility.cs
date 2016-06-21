using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

namespace Assets.Editor.CsvModelEditor
{
    public static class CsvEditorUtility
    {
        public static String ToTitleCaseAndRemoveAllWhitespace(this String s)
        {
            return string.IsNullOrEmpty(s) ? string.Empty : Regex.Replace(char.ToUpper(s[0]) + s.Substring(1), @"\s+", "");
        }

        public static void Populate<T>(this T[] array, T value)
        {
            for (var i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }

        public static List<BaseProperty> ExportFromCsvFile(String path)
        {
            if (File.Exists(path))
            {
                using (var sr = new StreamReader(path, Encoding.UTF8))
                {
                    var fieldsLine = sr.ReadLine();
                    if (fieldsLine != null)
                    {
                        var dataTypeLine = sr.ReadLine();
                        if (dataTypeLine != null)
                        {
                            var fields = fieldsLine.Split(',').Select(f => f.Trim()).ToArray();
                            var dataTypes = dataTypeLine.Split(',').Select(d=>d.Trim()).ToArray();
                            var list = new List<BaseProperty>();

                            var annotations = new string[fields.Length];
                            annotations.Populate(String.Empty);

                            var annotationLine = sr.ReadLine();
                            if (annotationLine != null)
                            {
                                annotations = annotationLine.Split(',').Select(a => a.Trim()).ToArray();
                            }

                            for (var i = 0; i < fields.Length; i++)
                            {
                                var propObj = CreateProperty(fields[i], i < dataTypes.Length ? dataTypes[i] : "string",
                                    i< annotations.Length ? annotations[i]: String.Empty);
                                var prop = propObj.IsCustomType
                                    ? ScriptableObject.CreateInstance<CustomProperty>()
                                    : ScriptableObject.CreateInstance<BaseProperty>();
                                prop.PropertyObject = propObj;
                                list.Add(prop);
                            }

                            return list;
                        }
                    }
                }
            }

            return new List<BaseProperty>(0);
        }

        private static PropertyObject CreateProperty(String fieldName, String dataType, String annotation)
        {
            var prop = ScriptableObject.CreateInstance<PropertyObject>();
            prop.PropertyName = fieldName.ToTitleCaseAndRemoveAllWhitespace();
            prop.CsvFieldName = fieldName;
            prop.Annotation = annotation ?? String.Empty;

            var index = dataType.IndexOf("[", StringComparison.Ordinal);
            if (index > 0)
            {
                dataType = dataType.Substring(0, index);
                prop.IsArray = true;
            }

            switch (dataType.ToLower())
            {
                case "int":
                case "int32":
                    prop.DataType = FieldType.Int32;
                    break;
                case "long":
                case "int64":
                    prop.DataType = FieldType.Int64;
                    break;
                case "float":
                case "single":
                    prop.DataType = FieldType.Single;
                    break;
                case "double":
                    prop.DataType = FieldType.Double;
                    break;
                case "decimal":
                    prop.DataType = FieldType.Decimal;
                    break;
                case "string":
                    prop.DataType = FieldType.String;
                    break;
                default:
                    prop.DataType = FieldType.String;
                    prop.IsCustomType = true;
                    prop.CustomTypeName = dataType;
                    break;
            }

            return prop;
        }
    }
}
