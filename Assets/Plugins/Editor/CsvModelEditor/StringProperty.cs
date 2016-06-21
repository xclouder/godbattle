namespace Assets.Editor.CsvModelEditor
{
    public class StringProperty: BaseProperty {

        public StringProperty()
        {
            ((PropertyObject)SerializedObject.targetObject).DataType = FieldType.String;
        }
    }
}
