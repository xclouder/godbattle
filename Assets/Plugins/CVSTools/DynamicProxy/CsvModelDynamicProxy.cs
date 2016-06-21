using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

/// <summary>
/// Csv模型代理
/// </summary>
public class CsvModelDynamicProxy
{
    private readonly Dictionary<Type, Type> _cache = new Dictionary<Type, Type>();

    /// <summary>
    /// 动态模块
    /// </summary>
    public ModuleScope ModuleScope { get; private set; }

    /// <summary>
    /// 属性拦截器
    /// </summary>
    public IPropertyInterceptor PropertyInterceptor { get; private set; }

    /// <summary>
    /// 构建 CsvModelDynamicProxy 实例
    /// </summary>
    /// <param name="moduleScope">ModuleScope实例</param>
    public CsvModelDynamicProxy(ModuleScope moduleScope)
    {
        ModuleScope = moduleScope;
        PropertyInterceptor = new SharedPropertyInterceptor();
    }

    /// <summary>
    /// 构建 CsvModelDynamicProxy 实例
    /// </summary>
    public CsvModelDynamicProxy():this(new ModuleScope())
    {
    }

    /// <summary>
    /// 为指定类型创建一个代理实例
    /// </summary>
    /// <typeparam name="T">被代理类型</typeparam>
    /// <returns>代理实例</returns>
    public T Of<T>(IPropertyInterceptor propertyInterceptor = null) where T : class, new()
    {
        if (!_cache.ContainsKey(typeof (T)))
        {
            var proxyType = GenerateProxyType<T>();
            _cache.Add(typeof(T), proxyType);
        }

        return Activator.CreateInstance(_cache[typeof(T)], new object[] { propertyInterceptor ?? PropertyInterceptor }) as T;
    }

    /// <summary>
    /// 为指定类型创建代理类型
    /// </summary>
    /// <typeparam name="T">被代理类型</typeparam>
    /// <returns>动态生成的代理类型</returns>
    public Type GenerateProxyType<T>() where T : class
    {
        return GenerateProxyType(typeof(T));
    }

    /// <summary>
    /// 为指定类型创建代理类型
    /// </summary>
    /// <param name="type">被代理类型</param>
    /// <returns>动态生成的代理类型</returns>
    public Type GenerateProxyType(Type type)
    {
        if (type.IsSealed || type.IsAbstract || (!type.IsPublic && !type.IsNestedPublic))
        {
            throw new ArgumentException(String.Format("CsvModelDynamicProxy not support NotPublic, Sealed, Abstract proxy type. Current Proxy type is {0}", type), "type");
        }

        var baseConstructor = type.GetConstructor(BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance, null, Type.EmptyTypes, null);
        if (baseConstructor == null)
        {
            throw new ArgumentException(String.Format("Proxy type must have a parameterless constructor. Current Proxy type is {0}", type), "type");
        }

        var typeBuilder = ModuleScope.ModuleBuilder.DefineType(String.Format("CsvModelDynamicProxy.{0}DynamicProxy", type.Name), TypeAttributes.Public, type);
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var interceptorField = typeBuilder.DefineField("_propertyInterceptor", typeof(IPropertyInterceptor), FieldAttributes.Private);

        EmitConstructor(typeBuilder, interceptorField, baseConstructor);
        EmitProperties(typeBuilder, interceptorField, properties);

        return typeBuilder.CreateType();
    }

    private static void EmitProperties(TypeBuilder typeBuilder, FieldInfo interceptorField, IEnumerable<PropertyInfo> properties)
    {
        foreach (var property in properties)
        {
            var csvFieldAttribute = Attribute.GetCustomAttribute(property, typeof(CsvFieldAttribute), false) as CsvFieldAttribute;
            if (csvFieldAttribute == null)
            {
                continue;
            }

            var propName = property.Name;
            var propType = property.PropertyType;

            var getMethod = property.GetGetMethod(true);
            var setMethod = property.GetSetMethod(true);

            if (getMethod.IsVirtual && setMethod.IsVirtual)
            {
                var fieldBuilder = typeBuilder.DefineField(String.Format("_{0}", propName), propType,
                    FieldAttributes.Private);
                const MethodAttributes getSetAttributes =
                    MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig |
                    MethodAttributes.Virtual;
                var invokeType = new[] { typeof(Object), typeof(String), propType.IsEnum ? typeof(Int32) : propType, typeof(Boolean) };

                var getMethodBuilder = typeBuilder.DefineMethod(getMethod.Name, getSetAttributes, propType, Type.EmptyTypes);
                var getMethodGenerator = getMethodBuilder.GetILGenerator();
                getMethodGenerator.Emit(OpCodes.Ldarg_0);
                getMethodGenerator.Emit(OpCodes.Ldfld, interceptorField);
                getMethodGenerator.Emit(OpCodes.Ldarg_0);
                getMethodGenerator.Emit(OpCodes.Ldstr, propName);
                getMethodGenerator.Emit(OpCodes.Ldarg_0);
                getMethodGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
                getMethodGenerator.Emit(OpCodes.Ldc_I4_0);
                getMethodGenerator.Emit(OpCodes.Callvirt, typeof(IPropertyInterceptor).GetMethod("Invoke", invokeType));
                getMethodGenerator.Emit(OpCodes.Ldarg_0);
                getMethodGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
                getMethodGenerator.Emit(OpCodes.Ret);

                var setMethodBuilder = typeBuilder.DefineMethod(setMethod.Name, getSetAttributes, null, new[] { propType });
                var setMethodGenerator = setMethodBuilder.GetILGenerator();
                setMethodGenerator.Emit(OpCodes.Ldarg_0);
                setMethodGenerator.Emit(OpCodes.Ldarg_1);
                setMethodGenerator.Emit(OpCodes.Stfld, fieldBuilder);
                setMethodGenerator.Emit(OpCodes.Ldarg_0);
                setMethodGenerator.Emit(OpCodes.Ldfld, interceptorField);
                setMethodGenerator.Emit(OpCodes.Ldarg_0);
                setMethodGenerator.Emit(OpCodes.Ldstr, propName);
                setMethodGenerator.Emit(OpCodes.Ldarg_1);
                setMethodGenerator.Emit(OpCodes.Ldc_I4_1);
                setMethodGenerator.Emit(OpCodes.Callvirt, typeof(IPropertyInterceptor).GetMethod("Invoke", invokeType));
                setMethodGenerator.Emit(OpCodes.Ret);
            }
        }
    }

    private static void EmitConstructor(TypeBuilder typeBuilder, FieldInfo interceptorField, ConstructorInfo baseConstructor)
    {
        Type[] constructorArgs = { typeof(IPropertyInterceptor) };
        var constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard,
            constructorArgs);

        var constructoGenerator = constructorBuilder.GetILGenerator();
        constructoGenerator.Emit(OpCodes.Ldarg_0);
        constructoGenerator.Emit(OpCodes.Call, baseConstructor);
        constructoGenerator.Emit(OpCodes.Ldarg_0);
        constructoGenerator.Emit(OpCodes.Ldarg_1);
        constructoGenerator.Emit(OpCodes.Stfld, interceptorField);
        constructoGenerator.Emit(OpCodes.Ret);
    }
}
