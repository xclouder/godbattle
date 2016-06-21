using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;

/// <summary>
/// 独立的属性拦截器实现，每个模型实例拥有一个该拦截器实例，对属性验证码进行单独存储
/// </summary>
public class IndependentPropertyInterceptor : IPropertyInterceptor
{
    private Dictionary<String, String> _propertyHashCodes;

    private readonly Int32 _randomInt32 = new Random().Next(10, 2345);

    private readonly Int64 _randomInt64 = new Random().Next(33, 3456);

    private readonly Double _randomDouble = new Random().NextDouble() * 10;

    private readonly Single _randomSingle = (Single)new Random().NextDouble() * 5;

    private void TryInitStorage()
    {
        //延迟初始化属性存储字典，这样对于没有需要的模型代理就不会生成一个无用的字典实例，节省内存
        if (_propertyHashCodes == null)
        {
            _propertyHashCodes = new Dictionary<String, String>(); 
        }
    }

    private void AddOrUpdate(String propName, String hashCode)
    {
        TryInitStorage();

        if (_propertyHashCodes.ContainsKey(propName))
        {
            _propertyHashCodes[propName] = hashCode;
        }
        else
        {
            _propertyHashCodes.Add(propName, hashCode);
        }
    }

    private Boolean TryGet(String propName, out String hashCode)
    {
        TryInitStorage();

        return _propertyHashCodes.TryGetValue(propName, out hashCode);
    }

    private void Check(String propName, String hashCode)
    {
        String preValueHash;
        if (TryGet(propName, out preValueHash) && !preValueHash.Equals(hashCode))
        {
            throw new CsvModelPropertyVerificationException(propName);
        }
    }

    private void _Invoke(String propName, String propValueHash, Boolean update)
    {
        if (update)
        {
            AddOrUpdate(propName, propValueHash);
        }
        else
        {
            Check(propName, propValueHash);
        }
        #if UNITY_EDITOR
        try
        {
            UnityEngine.Debug.Log(String.Format("IndependentPropertyInterceptor -(1) PropertyName:{0} PropertyValueHash:{1}",
                propName, propValueHash));
        }
        catch (System.Security.SecurityException)
        {
            
        }
        #endif
    }

    private void _Invoke<T>(String propName, T[] propValue, Boolean update)
    {
        if (propValue == null || propValue.Length == 0)
        {
            _Invoke(propName, "@NULL|EMPTY@", update);
        }
        else
        {
            var charArray = String.Join(String.Empty, propValue.Select(v => v.ToString()).ToArray()).ToCharArray();
            Array.Reverse(charArray);
            var propValueHash = new String(charArray);

            _Invoke(propName, propValueHash, update);
        }
    }

    private static void Log(Object obj, String propName, Object propValue, Boolean update)
    {
        #if UNITY_EDITOR
        var array = propValue as Array;
        var propValueString = array != null? String.Join(",", array.Cast<Object>().Select(o=>o.ToString()).ToArray()): propValue;

        try
        {
            UnityEngine.Debug.Log(
                String.Format(
                    "IndependentPropertyInterceptor -(2) DynamicProxyType:{0} PropertyName:{1} PropertyValue:{2} InvokeType:{3}",
                    obj.GetType(), propName, propValueString, update ? "Set" : "Get"));

        }
        catch (System.Security.SecurityException)
        {

        }
        #endif

    }

    public void Invoke(Object obj, String propName, Int32 propValue, Boolean update)
    {
        var propValueHash = propValue + _randomInt32;

        _Invoke(propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Int32[] propValue, Boolean update)
    {
        _Invoke(propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Int64 propValue, Boolean update)
    {
        var propValueHash = propValue + _randomInt64;

        _Invoke(propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Int64[] propValue, Boolean update)
    {
        _Invoke(propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Single propValue, Boolean update)
    {
        var propValueHash = propValue + _randomSingle;

        _Invoke(propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Single[] propValue, Boolean update)
    {
        _Invoke(propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Double propValue, Boolean update)
    {
        var propValueHash = propValue + _randomDouble;

        _Invoke(propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Double[] propValue, Boolean update)
    {
        _Invoke(propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Decimal propValue, Boolean update)
    {
        var propValueHash = propValue + _randomInt32;

        _Invoke(propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Decimal[] propValue, Boolean update)
    {
        _Invoke(propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, String propValue, Boolean update)
    {
        var propValueHash = RuntimeHelpers.GetHashCode(propValue);

        _Invoke(propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, String[] propValue, Boolean update)
    {
        _Invoke(propName, propValue, update);
        Log(obj, propName, propValue, update);
    }
}