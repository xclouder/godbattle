using System;

/// <summary>
///  PropertyInterceptor属性验证失败时抛出
/// </summary>
public class CsvModelPropertyVerificationException : Exception
{
    public CsvModelPropertyVerificationException(String propName)
        : base(String.Format("Csv模型属性( {0} )验证失败。", propName))
    {
        
    }
}