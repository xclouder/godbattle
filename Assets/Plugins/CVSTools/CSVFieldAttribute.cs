using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class CsvFieldAttribute : Attribute
{
    /// <summary>
    /// 属性对应的CSV字段的名称
    /// </summary>
    public String Name { get; set; }

    /// <summary>
    /// 属性赋值时需要调用转型接口名称
    /// </summary>
    /// <remarks>
    /// 由于字段值可能是复杂的类型，对于这样的类型需要指定接口进行转型
    /// </remarks>
    public String ConverterName { get; set; }
}
