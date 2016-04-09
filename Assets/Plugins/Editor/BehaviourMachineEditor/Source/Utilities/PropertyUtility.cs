//----------------------------------------------
//            Behaviour Machine
// Copyright © 2014 Anderson Campos Cardoso
//----------------------------------------------

using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BehaviourMachine;

namespace BehaviourMachineEditor {

	/// <summary> 
    /// Property utility functions
    /// </summary>
	public class PropertyUtility {

		/// <summary> 
        /// Disconnect a property from a prefab.
        /// <param name="target">The target Object.</param>
        /// <param name="propertyPath">The target property to be disconnect.</param>
        /// </summary>
		public static void DisconnectPropertyFromPrefab (UnityEngine.Object target, string propertyPath) {
			var serialObj = new SerializedObject(target);
			var targetProperty = serialObj.FindProperty(propertyPath);

			if (targetProperty != null) {
				var endProperty = targetProperty.GetEndProperty();
				do {
					if (!targetProperty.prefabOverride) {
						switch (targetProperty.propertyType) {
							case SerializedPropertyType.Integer:
								if (targetProperty.intValue == 0)
									targetProperty.intValue = 1;
								else
									targetProperty.intValue = 0;
								break;
							case SerializedPropertyType.String:
								var stringValue = targetProperty.stringValue;
								if (stringValue.Equals(" "))
									targetProperty.stringValue = string.Empty;
								else
									targetProperty.stringValue = " ";
								break;
							case SerializedPropertyType.Float:
								if (targetProperty.floatValue == 0f)
									targetProperty.floatValue = 1f;
								else
									targetProperty.floatValue = 0f;
								break;
							case SerializedPropertyType.Boolean:
								targetProperty.boolValue = !targetProperty.boolValue;
								break;
							case SerializedPropertyType.Color:
								targetProperty.colorValue = ChangeColor(targetProperty.colorValue);
								break;
							case SerializedPropertyType.Enum:
								targetProperty.enumValueIndex = targetProperty.enumValueIndex + 1;
								break;
							case SerializedPropertyType.ObjectReference:
								if (targetProperty.objectReferenceValue == null || targetProperty.objectReferenceValue != target)
									targetProperty.objectReferenceValue = target;
								else
									targetProperty.objectReferenceValue = null;
								break;
						}
					}
				} while (targetProperty.Next(true) && !SerializedProperty.EqualContents(targetProperty, endProperty));

				serialObj.ApplyModifiedProperties();
				PrefabUtility.RecordPrefabInstancePropertyModifications(target);
				// targetProperty.Dispose();

				// Edit array size == 0
				serialObj.Update();
				targetProperty = serialObj.FindProperty(propertyPath);
				endProperty = targetProperty.GetEndProperty();
				do {
					if (!targetProperty.prefabOverride && targetProperty.propertyType == SerializedPropertyType.ArraySize)
						targetProperty.arraySize = 1;
				} while (targetProperty.Next(true) && !SerializedProperty.EqualContents(targetProperty, endProperty));	

				serialObj.ApplyModifiedProperties();
				PrefabUtility.RecordPrefabInstancePropertyModifications(target);
				targetProperty.Dispose();
			}
			serialObj.Dispose();
		}

		/// <summary> 
        /// Changes a color value.
        /// <param name="targetColor">The color to be changed.</param>
        /// <returns>A different color value.</returns>
        /// </summary>
		static Color ChangeColor (Color targetColor) {
			targetColor.r = targetColor.r < 1 ? 1 : 0;
			targetColor.g = targetColor.g < 1 ? 1 : 0;
			targetColor.b = targetColor.b < 1 ? 1 : 0;
			targetColor.a = targetColor.a < 1 ? 1 : 0;
			return targetColor;
		}
	}
}