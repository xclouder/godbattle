using UnityEngine;
using UnityEditor;
using System.Collections;
using uFrame.MVVM;
using uFrame.Kernel;

[CustomEditor(typeof(ViewBase), true)]
public class ViewInspector : Editor 
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        serializedObject.Update();
        var t = target as ViewBase;

        var resolveNameProperty = serializedObject.FindProperty("_viewModelId");
        var resolutionNameProperty = serializedObject.FindProperty("_viewModelId");
        if (!string.IsNullOrEmpty(t.DefaultIdentifier) && (resolveNameProperty.stringValue != t.DefaultIdentifier))
            if (GUILayout.Button(string.Format("Use Registered \"{0}\" Instance", t.DefaultIdentifier)))
            {
                serializedObject.FindProperty("_viewModelId").stringValue = t.DefaultIdentifier;
            }

        Info("If you leave this empty, View will fetch a new viewmodel on awake.\n" +
             "Otherwise it is going to always use the viewmodel with given identifier.\n" +
             "If viewmodel with given id does not exist, one will be automatically created and registered.");
        EditorGUILayout.PropertyField(resolutionNameProperty, new GUIContent("ViewModel Identifier"));
        serializedObject.ApplyModifiedProperties();
    }

    public void Info(string message)
    {
        //if (!ShowInfoLabels) return;
        EditorGUILayout.HelpBox(message, MessageType.Info);
    }
}
