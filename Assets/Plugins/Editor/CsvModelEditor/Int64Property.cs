namespace Assets.Editor.CsvModelEditor
{
    public class Int64Property : BaseProperty
    {
        public Int64Property()
        {
            ((PropertyObject)SerializedObject.targetObject).DataType = FieldType.Int64;
        }
    }
}