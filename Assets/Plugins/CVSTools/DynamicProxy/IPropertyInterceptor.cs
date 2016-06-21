using System;

/// <summary>
/// 属性拦截器接口
/// </summary>
public interface IPropertyInterceptor
{
    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Int32 propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Int32[] propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Int64 propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Int64[] propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Single propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Single[] propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Double propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Double[] propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Decimal propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, Decimal[] propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, String propValue, Boolean update);

    /// <summary>
    /// 访问对象属性时调用
    /// </summary>
    /// <param name="obj">目标对象实例</param>
    /// <param name="propName">属性名称</param>
    /// <param name="propValue">属性值</param>
    /// <param name="update">访问属性时为false，将对属性进行验证，验证失败抛出异常。 设置属性时为true，属性设置后更新验证码。</param>
    /// <exception cref="CsvModelPropertyVerificationException">访问属性时对属性进行验证，验证失败抛出该异常</exception>
    void Invoke(Object obj, String propName, String[] propValue, Boolean update);
}