using System;
using System.Collections.Generic;
using System.Linq;


/// <summary>
/// 类型转换接口全局注册器
/// </summary>
public static class CsvFieldConverterRegister
{
    private static readonly Dictionary<String, ICsvFieldConverter> Converters = new Dictionary<String, ICsvFieldConverter>();

    static CsvFieldConverterRegister()
    {
        Register(new PrimitiveTypeArrayConverter<Int32>());
        Register(new PrimitiveTypeArrayConverter<Int64>());
        Register(new PrimitiveTypeArrayConverter<Single>());
        Register(new PrimitiveTypeArrayConverter<Double>());
        Register(new PrimitiveTypeArrayConverter<Decimal>());
        Register(new PrimitiveTypeArrayConverter<String>());
    }

    /// <summary>
    /// 注册类型转换接口
    /// </summary>
    /// <remarks>
    /// 如果已经存在同名的转换接口，新接口将覆盖旧接口
    /// </remarks>
    /// <param name="converter">类型转换接口实例</param>
    public static void Register(ICsvFieldConverter converter)
    {
        if (!Converters.ContainsKey(converter.Name))
        {
            Converters.Add(converter.Name, converter);
        }
        else
        {
            Converters[converter.Name] = converter;
        }
    }

    /// <summary>
    /// 获取指定名称的类型转换接口实例
    /// </summary>
    /// <param name="converterName">类型转换接口名称</param>
    /// <exception cref="NotFoundCsvFieldConverterExcetion">没有在注册器中找到指定名称的转换接口时抛出</exception>
    /// <returns>如果已经注册指定名称和的接口，则返回接口，否则返回null</returns>
    public static ICsvFieldConverter GetConverter(String converterName)
    {
        ICsvFieldConverter converter;
        if (Converters.TryGetValue(converterName, out converter))
        {
            return converter;
        }

        throw new NotFoundCsvFieldConverterExcetion(converterName);
    }

    /// <summary>
    /// 获取基元类型数组的数据转换器
    /// </summary>
    /// <remarks>
    /// 目前仅支持部分基元类型的数组转换：Int32[], Int64[], Single[], Double[], Decimal[], String[]
    /// </remarks>
    /// <param name="type">基元类型数组类型</param>
    /// <exception cref="NotFoundCsvFieldConverterExcetion">没有为指定基元类型数据组找到转换接口时抛出</exception>
    /// <returns>如果已经注册指定基元类型数组的转换接口，则返回接口，否则返回null</returns>
    public static ICsvFieldConverter GetPrimitiveTypeArrayConverter(Type type)
    {
        return GetConverter(type.ToString());
    }

    /// <summary>
    ///  基元类型的数据类型数据转换器
    /// </summary>
    /// <typeparam name="T">基元类型</typeparam>
    private class PrimitiveTypeArrayConverter<T> : ICsvFieldConverter
    {
        public string Name { get; private set; }

        public object ChangeType(object obj, Type targetType)
        {
            if (typeof (T[]) != targetType)
            {
                throw new ArgumentException(String.Format("基元类型数组转换器 {0} 无法处理类型 {1} .", Name, targetType), "targetType");
            }

            var str = obj.ToString();
            return String.IsNullOrEmpty(str)
                ? new T[0]
                : str.Split(',').Select(e => (T) Convert.ChangeType(e.Trim(), typeof (T))).ToArray();
        }

        public PrimitiveTypeArrayConverter()
        {
            Name = typeof(T[]).ToString();
        }
    }
}