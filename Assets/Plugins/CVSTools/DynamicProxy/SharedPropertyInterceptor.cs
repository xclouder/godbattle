using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;


/// <summary>
/// 共享的属性拦截器实现，所有属性的验证标识按照实例hash进行存储
/// </summary>
public class SharedPropertyInterceptor : IPropertyInterceptor
{
    private readonly Dictionary<int, Dictionary<string, string>> _propertyHashCodes = new Dictionary<int, Dictionary<string, string>>();

    private readonly Int32 _randomInt32 = new Random().Next(122, 2345);

    private readonly Int64 _randomInt64 = new Random().Next(333, 3456);

    private readonly Double _randomDouble = new Random().NextDouble() * 10;

    private readonly Single _randomSingle = (Single)new Random().NextDouble() * 5;

    private void AddOrUpdate(Int32 objHashCode, String propName, String hashCode)
    {
        if (!_propertyHashCodes.ContainsKey(objHashCode))
        {
            _propertyHashCodes.Add(objHashCode, new Dictionary<String, String>());
        }

        if (_propertyHashCodes[objHashCode].ContainsKey(propName))
        {
            _propertyHashCodes[objHashCode][propName] = hashCode;
        }
        else
        {
            _propertyHashCodes[objHashCode].Add(propName, hashCode);
        }
    }

    private Boolean TryGet(Int32 objHashCode, String propName, out String hashCode)
    {
        if (_propertyHashCodes.ContainsKey(objHashCode) && _propertyHashCodes[objHashCode].ContainsKey(propName))
        {
            hashCode = _propertyHashCodes[objHashCode][propName];
            return true;
        }

        hashCode = null;
        return false;
    }

    private void Check(Int32 objHashCode, String propName, String hashCode)
    {
        String preValueHash;
        if (TryGet(objHashCode, propName, out preValueHash) && !preValueHash.Equals(hashCode))
        {
            throw new CsvModelPropertyVerificationException(propName);
        }
    }

    private void _Invoke(Object obj, String propName, String propValueHash, Boolean update)
    {
        var objHashCode = RuntimeHelpers.GetHashCode(obj);

        if (update)
        {
            AddOrUpdate(objHashCode, propName, propValueHash);
        }
        else
        {
            Check(objHashCode, propName, propValueHash);
        }

        try
        {
            UnityEngine.Debug.Log(String.Format("SharedPropertyInterceptor -(1) PropertyName:{0} PropertyValueHash:{1}", propName,
                propValueHash));
        }
        catch (System.Security.SecurityException)
        {
            
        }
    }

    private void _Invoke<T>(Object obj, String propName, T[] propValue, Boolean update)
    {
        if (propValue == null || propValue.Length == 0)
        {
            _Invoke(obj, propName, "@NULL|EMPTY@", update);
        }
        else
        {
            var charArray = String.Join(String.Empty, propValue.Select(v=>v.ToString()).ToArray()).ToCharArray();
            Array.Reverse(charArray);
            var propValueHash = new String(charArray);

            _Invoke(obj, propName, propValueHash, update);
        }
    }

    private static void Log(Object obj, String propName, Object propValue, Boolean update)
    {
        var array = propValue as Array;
        var propValueString = array != null ? String.Join(",", array.Cast<Object>().Select(o => o.ToString()).ToArray()) : propValue;

        try
        {
            UnityEngine.Debug.Log(
                String.Format(
                    "SharedPropertyInterceptor -(2) DynamicProxyType:{0} PropertyName:{1} PropertyValue:{2} InvokeType:{3}",
                    obj.GetType(), propName, propValueString, update ? "Set" : "Get"));
        }
        catch (System.Security.SecurityException)
        {
            
        }
    }

    public void Invoke(Object obj, String propName, Int32 propValue, Boolean update)
    {
        var propValueHash = propValue + _randomInt32;
        _Invoke(obj, propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Int32[] propValue, Boolean update)
    {
        _Invoke(obj, propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Int64 propValue, Boolean update)
    {
        var propValueHash = propValue + _randomInt64;
        _Invoke(obj, propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Int64[] propValue, Boolean update)
    {
        _Invoke(obj, propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Single propValue, Boolean update)
    {
        var propValueHash = propValue + _randomSingle;
        _Invoke(obj, propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Single[] propValue, Boolean update)
    {
        _Invoke(obj, propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Double propValue, Boolean update)
    {
        var propValueHash = propValue + _randomDouble;
        _Invoke(obj, propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Double[] propValue, Boolean update)
    {
        _Invoke(obj, propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Decimal propValue, Boolean update)
    {
        var propValueHash = propValue + _randomInt32;
        _Invoke(obj, propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, Decimal[] propValue, Boolean update)
    {
        _Invoke(obj, propName, propValue, update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, String propValue, Boolean update)
    {
        var propValueHash = RuntimeHelpers.GetHashCode(propValue);
        _Invoke(obj, propName, propValueHash.ToString(CultureInfo.InvariantCulture), update);
        Log(obj, propName, propValue, update);
    }

    public void Invoke(Object obj, String propName, String[] propValue, Boolean update)
    {
        _Invoke(obj, propName, propValue, update);
        Log(obj, propName, propValue, update);
    }
}