namespace Assets.Editor.CsvModelEditor
{
    public class DecimalProperty : BaseProperty
    {
        public DecimalProperty()
        {
            ((PropertyObject)SerializedObject.targetObject).DataType = FieldType.Decimal;
        }
    }
}