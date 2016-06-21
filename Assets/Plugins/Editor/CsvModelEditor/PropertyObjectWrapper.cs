using System;
using System.Reflection;
using System.Runtime.Serialization;
using UnityEngine;

namespace Assets.Editor.CsvModelEditor
{
    [Serializable]
    public class PropertyObjectWrapper : ISerializable
    {
        public PropertyObject PropertyObject { get; set; }

        public PropertyObjectWrapper()
        {

        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            foreach (var field in PropertyObject.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance))
            {
                info.AddValue(field.Name, field.GetValue(PropertyObject), field.FieldType);
            }
        }

        public PropertyObjectWrapper(SerializationInfo info, StreamingContext context)
        {
            PropertyObject = ScriptableObject.CreateInstance<PropertyObject>();
            if (PropertyObject == null)
            {
                return;
            }

            foreach (var field in PropertyObject.GetType().GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy | BindingFlags.Instance))
            {
                try
                {
                    field.SetValue(PropertyObject, info.GetValue(field.Name, field.FieldType));
                }
                catch (SerializationException)
                {
                    Debug.LogWarning(String.Format("序列化数据中不存在字段 {0} 。", field.Name));
                }
            }
        }
    }
}