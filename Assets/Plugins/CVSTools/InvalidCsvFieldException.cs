using System;

/// <summary>
///  Csv字段转换失败时抛出的异常
/// </summary>
public class InvalidCsvFieldException : Exception
{
    /// <summary>
    /// 构建一个 InvalidCsvFieldException 对象实例
    /// </summary>
    /// <param name="properyName">属性名称</param>
    /// <param name="fieldName">csv字段名称</param>
    /// <param name="fieldValue">csv字段值</param>
    /// <param name="innerException">字段赋值失败的实际异常实例</param>
    public InvalidCsvFieldException(String properyName, String fieldName, String fieldValue, Exception innerException)
        : base(
            String.Format("propertyName={0}, fieldName={1}, fieldValue={2}, 无效的 csv 字段配置。", properyName, fieldName,
                fieldValue), innerException)
    {

    }
}