namespace Assets.Editor.CsvModelEditor
{
    public class Int32Property: BaseProperty {

        public Int32Property()
        {
            ((PropertyObject) SerializedObject.targetObject).DataType = FieldType.Int32;
        }
    }
}