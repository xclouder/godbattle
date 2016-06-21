using System;
using System.Reflection;

/// <summary>
/// 对象属性设置器高层抽象基类
/// </summary>
/// <typeparam name="TTarget">属性设置器应用的类型</typeparam>
internal abstract class PropertySetter<TTarget>
{
    /// <summary>
    /// 为 <typeparam name="TTarget" /> 实例设置属性值。具体对应的属性在构建属性设置器时决定。
    /// </summary>
    /// <param name="obj"> <typeparam name="TTarget" /> 实例 </param>
    /// <param name="value">待设置的属性值</param>
    public abstract void SetValue(TTarget obj, Object value);
}

/// <summary>
/// 对象属性设置器
/// </summary>
/// <typeparam name="TTarget">属性设置器应用的类型</typeparam>
/// <typeparam name="TValue">属性的类型</typeparam>
internal class PropertySetter<TTarget, TValue> : PropertySetter<TTarget>
{
    private readonly Action<TTarget, TValue> _action;

    /// <summary>
    /// 构建属性设置器实例
    /// </summary>
    /// <param name="property">属性设置器内部调用的属性</param>
    public PropertySetter(PropertyInfo property)
    {
        _action = (Action<TTarget, TValue>)Delegate.CreateDelegate(typeof(Action<TTarget, TValue>), property.GetSetMethod(true));
    }

    /// <summary>
    /// 为 <typeparam name="TTarget" /> 实例设置属性值。具体对应的属性在构建属性设置器时决定。
    /// </summary>
    /// <param name="obj"> <typeparam name="TTarget" /> 实例 </param>
    /// <param name="value">待设置的属性值</param>
    public override void SetValue(TTarget obj, Object value)
    {
        _action(obj, (TValue)value);
    }
}