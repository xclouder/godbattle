//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

#if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3

using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using System.Collections;

namespace BehaviourMachine {

    /// <summary>
    /// A wraper for the internal class UnityEditor.ReorderableList (in Unity 4.5+ is the class UnityEditorInternal.ReorderableList).
    /// </summary>
    public class ReorderableList {

        #region Delegates
        public delegate void DrawElementCallback(Rect rect, int index, bool selected, bool focused);

        public delegate void DrawHeaderCallback(Rect rect);

        public delegate void SelectCallbackDelegate(ReorderableList list);

        public delegate void AddCallbackDelegate(ReorderableList list);

        public delegate void RemoveCallbackDelegate(ReorderableList list);

        public delegate void ReorderCallbackDelegate(ReorderableList list);
        #endregion Delegates

        #region Constructor
        /// <summary>
        /// Constructor for an array or list.
        /// <param name="elements">The elements of the list.</param>
        /// <param name="elementType">The elements type.</param>
        /// <param name="draggable">The elements can be dragged?</param>
        /// <param name="displayHeader">Display header?</param>
        /// <param name="displayAddButton">Display option to add element?</param>
        /// <param name="displayRemoveButton">Display option to remove element?</param>
        /// </summary>
        public ReorderableList(IList elements, Type elementType, bool draggable = true, bool displayHeader = true, bool displayAddButton = true, bool displayRemoveButton = true) {
            ctor = constructorInfo.Invoke(new object[] { elements, elementType, draggable, displayHeader, displayAddButton, displayRemoveButton });
            ctor.GetType().GetProperty("index").SetValue(ctor, 0, null);
        }

        /// <summary>
        /// Constructor for serialized objects.
        /// <param name="serializedObject">The serialized object.</param>
        /// <param name="serializedProperty">The serialized array or list.</param>
        /// <param name="draggable">The elements can be dragged?</param>
        /// <param name="displayHeader">Display header?</param>
        /// <param name="displayAddButton">Display option to add element?</param>
        /// <param name="displayRemoveButton">Display option to remove element?</param>
        /// </summary>
        public ReorderableList(SerializedObject serializedObject, SerializedProperty serializedProperty, bool draggable = true, bool displayHeader = true, bool displayAddButton = true, bool displayRemoveButton = true) {
            ctor = constructorInfo_serialized.Invoke(new object[] { serializedObject, serializedProperty, draggable, displayHeader, displayAddButton, displayRemoveButton });
            ctor.GetType().GetProperty("index").SetValue(ctor, 0, null);
        }
        #endregion Constructor

        
        #region Properties
        /// <summary>
        /// Returns the serialized object if it exists.
        /// </summary>
        public SerializedObject serializedObject {
            get {
                return this.serializedProperty != null ? serializedProperty.serializedObject : null;
            }
        }

        /// <summary>
        /// Returns the serialized property if it exists.
        /// </summary>
        public SerializedProperty serializedProperty {
            get {
                return (SerializedProperty)ctor.GetType().GetProperty("serializedProperty").GetValue(ctor, new object[0]);
            }
        }

        /// <summary>
        /// The elements list.
        /// </summary>
        public IList list {
            get {
                return (IList)ctor.GetType().GetProperty("list").GetValue(ctor, new object[0]);
            }
            set {
                ctor.GetType().GetProperty("list").SetValue(ctor, value, null);
            }
        }

        /// <summary>
        /// The index of the selected element.
        /// </summary>
        public int index {
            get {
                return (int)ctor.GetType().GetProperty("index").GetValue(ctor, new object[0]);
            }
            set {
                ctor.GetType().GetProperty("index").SetValue(ctor, value, null);
            }
        }

        /// <summary>
        /// The height of one element.
        /// </summary>
        public float elementHeight {
            get {
                return (float)ctor.GetType().GetField("elementHeight").GetValue(ctor);
            }
            set {
                ctor.GetType().GetField("elementHeight").SetValue(ctor, value);
            }
        }

        /// <summary>
        /// The height of the header.
        /// </summary>
        public float headerHeight {
            get {
                return (float)ctor.GetType().GetField("headerHeight").GetValue(ctor);
            }
            set {
                ctor.GetType().GetField("headerHeight").SetValue(ctor, value);
            }
        }

        /// <summary>
        /// Optionally register a callback to draw the elements.
        /// </summary>
        public DrawElementCallback drawElementCallback {
            get {
                return m_DrawElementCallback;
            }
            set {
                m_DrawElementCallback = value;
                SetDelegate("ElementCallbackDelegate", "drawElementCallback", "ElementCallback");
            }
        }

        /// <summary>
        /// Optionally register a callback to draw the header.
        /// </summary>
        public DrawHeaderCallback drawHeaderCallback {
            get {
                return m_DrawHeaderCallback;
            }
            set {
                m_DrawHeaderCallback = value;
                SetDelegate("HeaderCallbackDelegate", "drawHeaderCallback", "HeaderCallback");
            }
        }

        /// <summary>
        /// Optionally register a callback to add a new element.
        /// </summary>
        public AddCallbackDelegate onAddCallback {
            get {
                return m_OnAddDelegateCallback;
            }
            set {
                m_OnAddDelegateCallback = value;
                SetDelegate("AddCallbackDelegate", "onAddCallback", "AddCallback");
            }
        }

        /// <summary>
        /// Optionally register a callback to remove an element.
        /// </summary>
        public RemoveCallbackDelegate onRemoveCallback {
            get {
                return m_OnRemoveDelegateCallback;
            }
            set {
                m_OnRemoveDelegateCallback = value;
                SetDelegate("RemoveCallbackDelegate", "onRemoveCallback", "RemoveCallback");
            }
        }

        /// <summary>
        /// Optionally register a callback to when the list is reordered.
        /// </summary>
        public ReorderCallbackDelegate onReorderCallback {
            get {
                return m_OnReorderCallback;
            }
            set {
                m_OnReorderCallback = value;
                SetDelegate("ReorderCallbackDelegate", "onReorderCallback", "ReorderCallback");
            }
        }

        /// <summary>
        /// Optionally register a callback to when the a new element is selected.
        /// </summary>
        public SelectCallbackDelegate onSelectCallback {
            get {
                return m_OnSelectCallback;
            }
            set {
                m_OnSelectCallback = value;
                SetDelegate("SelectCallbackDelegate", "onSelectCallback", "SelectCallback");
            }
        }
        #endregion Propertis


        #region Methods
        #if !UNITY_4_0_0 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3
        /// <summary>
        /// Call this to draw the list.
        /// <param name="rect">The rect to draw the list.</param>
        /// </summary>
        public void DoList(Rect rect) {
            if (init) {
                ctor.GetType().GetMethod("DoList").Invoke(ctor, new object[] {rect});
            }
            init = true;
        }
        #endif

        /// <summary>
        /// Call this to draw the list.
        /// </summary>
        public void DoLayoutList() {
            if (init) {
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3
                EditorGUILayout.Space();
                ctor.GetType().GetMethod("DoList").Invoke(ctor, new object[0]);
                #else
                EditorGUILayout.Space();
                ctor.GetType().GetMethod("DoLayoutList").Invoke(ctor, new object[0]);
                #endif
            }
            init = true;
        }
        #endregion Methods

        
        #region Reflection
        bool init;
        object ctor;
        DrawElementCallback m_DrawElementCallback;
        DrawHeaderCallback m_DrawHeaderCallback;
        AddCallbackDelegate m_OnAddDelegateCallback;
        RemoveCallbackDelegate m_OnRemoveDelegateCallback;
        SelectCallbackDelegate m_OnSelectCallback;
        ReorderCallbackDelegate m_OnReorderCallback;

        /// <summary>
        /// The ReorderableList type.
        /// </summary>
        Type type {
            get {
                #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3
                return Types.GetType("UnityEditor.ReorderableList", "UnityEditor.dll");
                #else
                return Types.GetType("UnityEditorInternal.ReorderableList", "UnityEditor.dll");
                #endif
            }
        }

        /// <summary>
        /// Serialized contructor info.
        /// </summary>
        ConstructorInfo constructorInfo_serialized {
            get {
                return type.GetConstructor(new[]
                    {
                        typeof (SerializedObject), typeof (SerializedProperty), typeof (bool), typeof (bool), typeof (bool),
                        typeof (bool)
                    });
            }
        }

        /// <summary>
        /// List contructor info.
        /// </summary>
        ConstructorInfo constructorInfo {
            get {
                return type.GetConstructor(new[]
                    {
                        typeof (IList), typeof (Type), typeof (bool), typeof (bool), typeof (bool),
                        typeof (bool)
                    });
            }
        }

        /// <summary>
        /// Called when an element need to be drawn.
        /// <param name="rect">The rect to draw the element.</param>
        /// <param name="index">The index of the element to be drawn.</param>
        /// <param name="selected">The element is selected?</param>
        /// <param name="focused">The element is being focused?</param>
        /// </summary>
        void ElementCallback (Rect rect, int index, bool selected, bool focused) {
            if (m_DrawElementCallback != null)
                m_DrawElementCallback(rect, index, selected, focused);
        }

        /// <summary>
        /// Called when the header need to be drawn.
        /// <param name="rect">The rect to draw the header.</param>
        /// </summary>
        void HeaderCallback (Rect rect) {
            if (m_DrawHeaderCallback != null)
                m_DrawHeaderCallback(rect);
        }

        /// <summary>
        /// Called when a new element need to be added.
        /// <param name="obj">The ReorderableList.</param>
        /// </summary>
        void AddCallback (object obj) {
            if (m_OnAddDelegateCallback != null)
                m_OnAddDelegateCallback(this);
        }

        /// <summary>
        /// Called when the selected element need to be removed.
        /// <param name="obj">The ReorderableList.</param>
        /// </summary>
        void RemoveCallback (object obj) {
            if (m_OnRemoveDelegateCallback != null)
                m_OnRemoveDelegateCallback(this);
        }

        /// <summary>
        /// Called when a new element is selected.
        /// <param name="obj">The ReorderableList.</param>
        /// </summary>
        void SelectCallback(object obj) {
            if (m_OnSelectCallback != null)
                m_OnSelectCallback(this);
        }

        /// <summary>
        /// Called when the list is reordered.
        /// <param name="obj">The ReorderableList.</param>
        /// </summary>
        void ReorderCallback (object obj) {
            if (m_OnReorderCallback != null)
                m_OnReorderCallback(this);
        }

        /// <summary>
        /// Set the registered delegates in the supplied event.
        /// <param name="typePath">The type of the delegate.</param>
        /// <param name="delegateName">The name of the delegate is this object.</param>
        /// <param name="callbackName">The name of the event in the Unity internal ReorderableList.</param>
        /// </summary>
        void SetDelegate(string typePath, string delegateName, string callbackName) {
            FieldInfo fieldInfo = ctor.GetType()
                .GetField(delegateName, BindingFlags.Public | BindingFlags.Instance);
            #if UNITY_4_0_0 || UNITY_4_1 || UNITY_4_2 || UNITY_4_3
            Type deleg = Types.GetType("UnityEditor.ReorderableList+" + typePath, "UnityEditor.dll");
            #else
            Type deleg = Types.GetType("UnityEditorInternal.ReorderableList+" + typePath, "UnityEditor.dll");
            #endif
            Delegate @delegate = Delegate.CreateDelegate(deleg, this,
                GetType().GetMethod(callbackName, BindingFlags.NonPublic | BindingFlags.Instance));
            fieldInfo.SetValue(ctor, @delegate);
        }
        #endregion Reflection
    }
}
#endif