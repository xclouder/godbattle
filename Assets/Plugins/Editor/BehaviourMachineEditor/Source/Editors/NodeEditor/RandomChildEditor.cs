//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

    /// <summary>
    /// Custom editor for the RandomChild node.
    /// <seealso cref="BehaviourMachine.RandomChild" />
    /// </summary>
    [CustomNodeEditor(typeof(RandomChild), true)]
    public class RandomChildEditor : NodeEditor {

    	/// <summary>
        /// The custom inspector.
        /// </summary>
        public override void OnInspectorGUI () {
            DrawDefaultInspector();

            var randomChild = target as RandomChild;
            
            if (randomChild != null) {
                // Get children nodes
                ActionNode[] children = randomChild.children;

                // Update serialized node data
                if (Event.current.type == EventType.Layout) {
                    this.serializedNode.Update();
                }

                // Get an iterator
                var iterator = serializedNode.GetIterator();

                // Cache the indent level
                int indentLevel = EditorGUI.indentLevel;

                if (iterator.Find("weight")) {
                    SerializedNodeProperty current = iterator.current;

                    // Cache the depth of array name
                    int depth = iterator.depth;

                    // Don't draw the size
                    iterator.Next(true);

                    // The current index of the child
                    int childIndex = 0;

                    // Draw children weight
                    while (iterator.Next(iterator.current == null || iterator.current.propertyType != NodePropertyType.Variable) && iterator.depth > depth) {
                        current = iterator.current;
                        if (!current.hideInInspector) {
                            EditorGUI.indentLevel = indentLevel + iterator.depth - 1;
                            
                            // Its an array element of  weight array?
                            if (iterator.depth - depth == 1 && childIndex < children.Length)
                                GUILayoutHelper.DrawNodeProperty(new GUIContent(children[childIndex++].name + " Weight", current.tooltip), current, target);
                            else
                                GUILayoutHelper.DrawNodeProperty(new GUIContent(current.label, current.tooltip), current, target);
                        }
                    }
                }

                 // Restore the indent level
                EditorGUI.indentLevel = indentLevel;
                
                // Apply modified properties
                this.serializedNode.ApplyModifiedProperties();
            }
        }
    }
}