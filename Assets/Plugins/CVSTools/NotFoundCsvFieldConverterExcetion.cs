using System;

/// <summary>
/// 没有在注册器中找到指定名称的转换接口时抛出的异常类型
/// </summary>
public class NotFoundCsvFieldConverterExcetion : Exception
{
    /// <summary>
    /// 构建一个 NotFoundCsvFieldConverterExcetion 实例
    /// </summary>
    /// <param name="convertName">字段转化接口名称</param>
    public NotFoundCsvFieldConverterExcetion(String convertName)
        : base(String.Format("没有找到名称为 {0} 的CsvFieldConverter。", convertName))
    {

    }
}