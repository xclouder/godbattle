using System;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;

/// <summary>
/// 动态模块
/// </summary>
public class ModuleScope
{
    private readonly AssemblyBuilder _assemblyBuilder;

    /// <summary>
    /// 动态程序集文件名
    /// </summary>
    public static readonly String AssemblyFileName = "CsvModelDynamicProxy.dll";

    /// <summary>
    /// 动态程序集名称
    /// </summary>
    public readonly String NameOfAssembly = "CsvModelDynamicProxyAssembly";

    /// <summary>
    /// 是否需要保存动态程序集
    /// </summary>
    public Boolean SavePhysicalAssembly { get; private set; }

    /// <summary>
    /// ModuleBuilder
    /// </summary>
    public ModuleBuilder ModuleBuilder { get; set; }

    /// <summary>
    /// 构建一个可保存的动态程序集 ModuleScope 模块
    /// </summary>
    /// <param name="assemblySaveDir">程序集保存的目录</param>
    public ModuleScope(String assemblySaveDir)
    {
        if (assemblySaveDir != null && !Directory.Exists(assemblySaveDir))
        {
            throw new DirectoryNotFoundException(assemblySaveDir);
        }
        _assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(NameOfAssembly), AssemblyBuilderAccess.RunAndSave, assemblySaveDir);
        ModuleBuilder = _assemblyBuilder.DefineDynamicModule(NameOfAssembly, AssemblyFileName);
        SavePhysicalAssembly = true;
    }

    /// <summary>
    /// 构建一个无法保存的动态程序集 ModuleScope 模块
    /// </summary>
    public ModuleScope()
    {
        _assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName(NameOfAssembly), AssemblyBuilderAccess.Run);
        ModuleBuilder = _assemblyBuilder.DefineDynamicModule(NameOfAssembly);
        SavePhysicalAssembly = false;
    }

    /// <summary>
    /// 保存动态模块
    /// </summary>
    public void SaveAssembly()
    {
        if (SavePhysicalAssembly)
        {
            _assemblyBuilder.Save(AssemblyFileName);
        }
    }
}