using System;
using System.Collections.Generic;

namespace Assets.Editor.CsvModelEditor
{
    [Serializable]
    public class ModelMeta
    {
        public List<PropertyObjectWrapper> PropertyObjectWrappers { get; set; }

        public String Description { get; set; }
    }
}
