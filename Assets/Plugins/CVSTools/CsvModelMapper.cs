using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// 基于CSV文件的属性映射器
/// </summary>
/// <typeparam name="T"> 包含 <see cref="CsvFieldAttribute"/>  标记属性的类型</typeparam>
public class CsvModelMapper<T> where T : class, new()
{
    private readonly List<CsvElement> _csvElements = new List<CsvElement>();

#if  UNITY_EDITOR || UNITY_ANDROID
    private const Boolean EnableJIT = true;
#else
    private const Boolean EnableJIT = false;
#endif

    /// <summary>
    /// 创建 <typeparamref name="T"/> 类型的映射器实例
    /// </summary>
    /// <param name="usePropertySetter">
    /// 是否使用属性设置器(当且仅当启用了JIT，即在定义了条件编译标识 `UNITY_EDITOR` 或者 `UNITY_EDITOR` 时有效)，属性设置器使用泛型委托实例化来代替反射。
    /// 使用属性设置器能够获得比反射更高的性能，但在AOT/IL2CPP存在兼容性问题。
    /// </param>
    public CsvModelMapper(Boolean usePropertySetter = true)
    {

        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            var csvFiled =
                Attribute.GetCustomAttribute(property, typeof(CsvFieldAttribute), false) as CsvFieldAttribute;
            if (csvFiled != null)
            {
                _csvElements.Add(new CsvElement
                {
                    Field = csvFiled,
                    Property = property,
                    PropertySetter = EnableJIT && usePropertySetter ? CreatePropertySetterAction(property) : null
                });
            }
        }
    }

    /// <summary>
    /// 创建 <typeparamref name="T"/> 类型的实例
    /// </summary>
    /// <param name="data">用于初始化模型的数据字典，key为模型属性，value为属性值</param>
    /// <param name="enableDynamicProxy">在启用JIT的条件下，是否需要创建动态代理实例</param>
    /// <returns><typeparamref name="T"/> 类型的实例</returns>
    public T CreateInstance(IDictionary<String, String> data, Boolean enableDynamicProxy)
    {
        //var obj = _enableJIT && enableDynamicProxy ? CsvModelDynamicProxyHelper.Of<T>() : new T();
        var obj = EnableJIT && enableDynamicProxy ? CsvModelDynamicProxyHelper.OfWithIndependentPropertyInterceptor<T>() : new T();
        foreach (var csvElement in _csvElements)
        {
            csvElement.SetValueForObj(obj, data);
        }

        return obj;
    }

    /// <summary>
    /// 为 <typeparamref name="T"/> 类型的属性创建属性设置委托
    /// </summary>
    /// <param name="propertyInfo">属性</param>
    /// <returns>未绑定对象的属性设置委托</returns>
    public static Action<T, Object> CreatePropertySetterAction(PropertyInfo propertyInfo)
    {
        return
            ((PropertySetter<T>)
                Activator.CreateInstance(
                    typeof(PropertySetter<,>).MakeGenericType(typeof(T), propertyInfo.PropertyType), propertyInfo))
                .SetValue;
    }

    private class CsvElement
    {
        private Func<Object, Type, Object> _convertFunc;

        public CsvFieldAttribute Field { private get; set; }

        public PropertyInfo Property { private get; set; }

        public Action<T, Object> PropertySetter { private get; set; }

        private Func<Object, Type, Object> ConvertFunc
        {
            get
            {
                return _convertFunc ??
                       (_convertFunc =
                           String.IsNullOrEmpty(Field.ConverterName)
                               ? GetConvertFunc()
                               : CsvFieldConverterRegister.GetConverter(Field.ConverterName).ChangeType);
            }
        }

        private Func<Object, Type, Object> GetConvertFunc()
        {
            if (Property.PropertyType.IsEnum)
            {
                return (obj, targetType) => Convert.ToInt32((String)obj);
            }

            if (Property.PropertyType.IsArray)
            {
                return CsvFieldConverterRegister.GetPrimitiveTypeArrayConverter(Property.PropertyType).ChangeType;
            }

            return Convert.ChangeType;
        }

        public void SetValueForObj(T obj, IDictionary<String, String> source)
        {
            if (source.ContainsKey(Field.Name))
            {
                try
                {
                    if (PropertySetter != null)
                    {
                        PropertySetter(obj, ConvertFunc(source[Field.Name], Property.PropertyType));
                    }
                    else
                    {
                        Property.SetValue(obj, ConvertFunc(source[Field.Name], Property.PropertyType), null);
                    }
                }
                catch (Exception exception)
                {
                    throw new InvalidCsvFieldException(Property.Name, Field.Name, source[Field.Name], exception);
                }
            }
        }
    }
}
