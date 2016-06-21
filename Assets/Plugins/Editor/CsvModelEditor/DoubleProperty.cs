namespace Assets.Editor.CsvModelEditor
{
    public class DoubleProperty : BaseProperty
    {
        public DoubleProperty()
        {
            ((PropertyObject)SerializedObject.targetObject).DataType = FieldType.Double;
        }
    }
}