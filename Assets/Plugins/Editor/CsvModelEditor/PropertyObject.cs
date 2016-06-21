using System;
using System.Text;
using UnityEngine;

namespace Assets.Editor.CsvModelEditor
{
    public class PropertyObject : ScriptableObject
    {
        public Boolean OnlyRead = true;

        public Boolean IsArray = false;

        public Boolean IsGuarded = false;

        public String PropertyName = String.Empty;

        public String CsvFieldName = String.Empty;

        public String CsvFieldConverter = String.Empty;

        public Boolean IsCustomType = false;

        public String CustomTypeName = String.Empty;

        public FieldType DataType = FieldType.String;

        public String Annotation = String.Empty;

        public Single Left;

        public Single Top;

        public Boolean IsValid()
        {
            if (String.IsNullOrEmpty(PropertyName))
            {
                return false;
            }

            if (IsCustomType && String.IsNullOrEmpty(CustomTypeName))
            {
                return false;
            }

            return true;
        }

        public PropertyObjectWrapper PropertyObjectWrapper
        {
            get
            {
                return new PropertyObjectWrapper { PropertyObject = this };
            }
        }

        public String PropertyCode
        {
            get
            {
                var sb = new StringBuilder();
                var propName = PropertyName.ToTitleCaseAndRemoveAllWhitespace();

                sb.AppendLine(ToLine("/// <summary>"));
                sb.AppendLine(ToLine(String.Format("/// {0}", String.IsNullOrEmpty(Annotation) ? propName : Annotation)));
                sb.AppendLine(ToLine("/// </summary>"));

                if (String.IsNullOrEmpty(CsvFieldConverter))
                {
                    sb.AppendLine(
                        ToLine(String.Format("[CsvField(Name = \"{0}\")]",
                            String.IsNullOrEmpty(CsvFieldName) ? propName : CsvFieldName)));
                }
                else
                {
                    sb.AppendLine(
                        ToLine(String.Format("[CsvField(Name = \"{0}\", ConverterName = \"{1}\")]",
                            String.IsNullOrEmpty(CsvFieldName) ? propName : CsvFieldName, CsvFieldConverter)));
                }
                sb.AppendLine(
                    ToLine(String.Format("public {3}{0} {1} {{ get; {2}set; }}",
                        IsCustomType ? CustomTypeName : String.Format("{0}{1}", DataType, IsArray ? "[]" : String.Empty),
                        propName, OnlyRead ? "protected " : String.Empty, IsGuarded ? "virtual " : String.Empty)));
                return sb.ToString();
            }
        }

        public String CsvFieldNameCode
        {
            get
            {
                return String.IsNullOrEmpty(CsvFieldName)
                    ? PropertyName.ToTitleCaseAndRemoveAllWhitespace()
                    : CsvFieldName;
            }
        }

        public String CsvFieldTypeCode
        {
            get
            {
                return IsCustomType ? CustomTypeName : String.Format("{0}{1}", DataType, IsArray ? "[]" : String.Empty);
            }
        }

        private static String ToLine(String line)
        {
            return String.Format("\t{0}", line);
        }
    }
}