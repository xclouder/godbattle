using System;

/// <summary>
/// 当Csv文件校验失败时抛出该异常类型
/// </summary>
public class InvalidCsvFileException : Exception
{
    /// <summary>
    /// 构建异常实例
    /// </summary>
    /// <param name="fileName">Csv文件名称</param>
    public InvalidCsvFileException(String fileName)
        : base(String.Format("配置文件 {0} 不是有效的配置文件（指纹校验失败）。", fileName))
    {

    }
}