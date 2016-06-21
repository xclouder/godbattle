namespace Assets.Editor.CsvModelEditor
{
    public class FloatProperty : BaseProperty
    {
        public FloatProperty()
        {
            ((PropertyObject)SerializedObject.targetObject).DataType = FieldType.Single;
        }
    }
}