/// <summary>
/// Csv模型代理帮助类
/// </summary>
public static class CsvModelDynamicProxyHelper
{
    private static readonly CsvModelDynamicProxy DynamicProxy = new CsvModelDynamicProxy();

    /// <summary>
    /// 为指定类型创建一个使用共享拦截器的代理实例
    /// </summary>
    /// <typeparam name="T">被代理类型</typeparam>
    /// <returns>代理实例</returns>
    public static T Of<T>() where T : class, new()
    {
        return DynamicProxy.Of<T>();
    }

    /// <summary>
    /// 为指定类型创建一个使用独立拦截器的代理实例
    /// </summary>
    /// <typeparam name="T">被代理类型</typeparam>
    /// <returns>代理实例</returns>
    public static T OfWithIndependentPropertyInterceptor<T>() where T : class, new()
    {
        return DynamicProxy.Of<T>(new IndependentPropertyInterceptor());
    }
}