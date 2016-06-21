using System;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor.CsvModelEditor
{
    public class CustomProperty : BaseProperty
    {
        public CustomProperty()
        {
            WindowTitle = "Custom Property";
            ((PropertyObject) SerializedObject.targetObject).IsCustomType = true;
        }

        public override void InitWindowRect(Single left, Single top)
        {
            WindowRect = new Rect(left, top, 250, 140);
        }

        protected override void ChangeWinTitle()
        {

        }

        protected override void DrawFileds()
        {
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("PropertyName"), true, GUILayout.MinWidth(50));
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("CsvFieldName"), true, GUILayout.MinWidth(50));
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("CustomTypeName"), true, GUILayout.MinWidth(50));
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("CsvFieldConverter"), true, GUILayout.MinWidth(50));
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("OnlyRead"), true, GUILayout.MinWidth(50));
            //EditorGUILayout.PropertyField(SerializedObject.FindProperty("Annotation"), true, GUILayout.MinWidth(50));

            DrawProperty(SerializedObject.FindProperty("PropertyName"), 120);
            DrawProperty(SerializedObject.FindProperty("CsvFieldName"), 120);
            DrawProperty(SerializedObject.FindProperty("CustomTypeName"), 120);
            DrawProperty(SerializedObject.FindProperty("CsvFieldConverter"), 120);
            DrawProperty(SerializedObject.FindProperty("OnlyRead"), 120);
            DrawProperty(SerializedObject.FindProperty("Annotation"), 120);
        }
    }
}