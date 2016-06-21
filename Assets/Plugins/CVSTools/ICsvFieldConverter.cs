using System;

/// <summary>
/// Csv字段数据类型转换接口
/// </summary>
public interface ICsvFieldConverter
{
    /// <summary>
    /// Convert名称
    /// </summary>
    String Name { get; }

    /// <summary>
    /// 将指定类型的实例转换为目标类型实例
    /// </summary>
    /// <param name="obj">原类型类型的实例</param>
    /// <param name="targetType">目标类型</param>
    /// <returns>目标类型实例</returns>
    Object ChangeType(Object obj, Type targetType);
}