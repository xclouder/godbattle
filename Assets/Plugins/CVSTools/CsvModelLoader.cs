using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ReadWriteCsv;
using UnityEngine;

/// <summary>
/// Csv模型配置文件加载器
/// </summary>
/// <typeparam name="T">数据模型</typeparam>
public class CsvModelLoader<T> where T : class, new()
{
    private readonly CsvModelMapper<T> _csvModelMapper;
    private readonly Boolean _enableDynamicProxy;

    protected CsvModelLoader(Boolean enableDynamicProxy)
    {
        _csvModelMapper = new CsvModelMapper<T>();
        _enableDynamicProxy = enableDynamicProxy;
    }

    public CsvModelLoader():this(true)
    {
        
    }

	public List<T> LoadFromText(String text, Boolean enablesValidation = true)
	{
		return  GetRawData(text, enablesValidation).Select(rowData => _csvModelMapper.CreateInstance(rowData, _enableDynamicProxy)).ToList();
	}

	private IEnumerable<Dictionary<String, String>> GetRawData(string textData, Boolean enablesValidation)
	{
		using (var ms = new MemoryStream(GetBytes(textData)))
		{
			var csvFileReader = new CsvFileReader(ms);
			var fieldNameRow = new CsvRow();
			
			if (csvFileReader.ReadRow(fieldNameRow))
			{
				var currentRow = new CsvRow();
				var fieldNames = fieldNameRow.Select(x => x.Trim()).ToArray();
				
				while (csvFileReader.ReadRow(currentRow))
				{
					var rowData = new Dictionary<String, String>();
					for (var i = 0; i < fieldNames.Length && i < currentRow.Count; i++)
					{
						rowData.Add(fieldNames[i], currentRow[i]);
					}
					
					yield return rowData;
				}
			}
		}
	}

	public String LoadConfigText(String fileName, String configRootPath = "Configs", Boolean enablesValidation = true)
	{
		var path = Path.Combine(configRootPath, fileName).Replace(Path.DirectorySeparatorChar, '/');

//		System.Threading.ThreadPool.
		var textAsset = Resources.Load<TextAsset>(path);

		if (textAsset != null)
		{
			if (enablesValidation && !CsvFileVerificator.IsValidHashCode(fileName, textAsset.bytes.ComputeHashToHexString()))
			{
				throw new InvalidCsvFileException(fileName);
			}

			return textAsset.text;
		}

		throw new Exception("empty data form file:" + path);
	}

    /// <summary>
    /// 同步载入指定的配置文件
    /// </summary>
    /// <param name="fileName">模型配置文件名称</param>
    /// <param name="configRootPath">模型配置文件所在根目录</param>
    /// <param name="enablesValidation">是否需要通过CsvFileVerificator进行指纹验证，默认为true，需要验证</param>
    /// <exception cref="InvalidCsvFileException">当指定的配置文件没有配置校验码或者校验码与配置的不符时抛出该异常。</exception>
    /// <returns>模型实例列表</returns>
    public List<T> Load(String fileName, String configRootPath = "Configs", Boolean enablesValidation = true)
    {
        var assetPath = Path.Combine(configRootPath, fileName).Replace(Path.DirectorySeparatorChar, '/');
        var bytes = LoadTextAssetBytes(assetPath);

        if (bytes == null)
        {
            return new List<T>(0);
        }

        if (enablesValidation)
        {
            CheckCsvFile(fileName, bytes);
        }

        return CreateModelsFromBytes(bytes).ToList();
    }

	/// <summary>
	/// 在 editor 中同步载入指定的配置文件
	/// </summary>
	/// <param name="fileName">模型配置文件名称</param>
	/// <param name="configRootPath">模型配置文件所在根目录</param>
	/// <returns>模型实例列表</returns>
	public List<T> LoadInEidtor(String fileName, String configRootPath = "Configs")
	{
		var assetPath = Path.Combine(configRootPath, fileName).Replace(Path.DirectorySeparatorChar, '/');
		var bytes = LoadTextAssetBytesDirectly(assetPath);

		if (bytes == null)
		{
			return new List<T>(0);
		}

		return CreateModelsFromBytes(bytes).ToList();
	}

    /// <summary>
    /// 异步载入指定的配置文件，同步创建模型
    /// </summary>
    /// <param name="fileName">模型配置文件名称</param>
    /// <param name="callback">配置文件载入解析完成后回调方法</param>
    /// <param name="configRootPath">模型配置文件所在根目录</param>
    /// <param name="enablesValidation">是否需要通过CsvFileVerificator进行指纹验证，默认为true，需要验证</param>
    /// <exception cref="InvalidCsvFileException">当指定的配置文件没有配置校验码或者校验码与配置的不符时抛出该异常。</exception>
    public void LoadAsync(String fileName, Action<List<T>> callback, String configRootPath = "Configs",
        Boolean enablesValidation = true)
    {
        if (callback == null)
        {
            throw new ArgumentNullException("callback");
        }

        var assetPath = Path.Combine(configRootPath, fileName).Replace(Path.DirectorySeparatorChar, '/');
        LoadTextAssetBytesAsync(assetPath, bytes =>
        {
            if (bytes != null)
            {
                if (enablesValidation)
                {
                    CheckCsvFile(fileName, bytes);
                }

                callback(CreateModelsFromBytes(bytes).ToList());
            }
            else
            {
                callback(new List<T>(0));
            }
        });
    }

    /// <summary>
    /// 异步载入指定的配置文件，并异步创建模型
    /// </summary>
    /// <param name="fileName">模型配置文件名称</param>
    /// <param name="callback">配置文件载入解析完成后回调方法</param>
    /// <param name="configRootPath">模型配置文件所在根目录</param>
    /// <param name="enablesValidation">是否需要通过CsvFileVerificator进行指纹验证，默认为true，需要验证</param>
    /// <exception cref="InvalidCsvFileException">当指定的配置文件没有配置校验码或者校验码与配置的不符时抛出该异常。</exception>
    public void LoadFullAsync(String fileName, Action<List<T>> callback, String configRootPath = "Configs",
        Boolean enablesValidation = true)
    {
        if (callback == null)
        {
            throw new ArgumentNullException("callback");
        }

        var assetPath = Path.Combine(configRootPath, fileName).Replace(Path.DirectorySeparatorChar, '/');
        LoadTextAssetBytesAsync(assetPath, bytes =>
        {
            if (bytes != null)
            {
                //这里很重要，由于 CsvFileVerificator 内部使用了单例模式。
                //所以必须保证在主线程中初始化，在工作线程中加载指纹文件是非法操作。
                CsvFileVerificator.ForceInit();
				//TODO
//                JDKResourceManager.Instance.AsyncExecute(() =>
//                {
//                    if (enablesValidation)
//                    {
//                        CheckCsvFile(fileName, bytes);
//                    }
//
//                    return CreateModelsFromBytes(bytes).ToList();
//                }, callback);
            }
            else
            {
                callback(new List<T>(0));
            }
        });
    }

    private IEnumerable<T> CreateModelsFromBytes(Byte[] bytes)
    {
        if (bytes == null || bytes.Length == 0)
        {
            throw new  ArgumentException("不支持从 `null` 或者长度为 `0` 的字节数组中获取数据。", "bytes");
        }
        
        using (var ms = new MemoryStream(bytes))
        {
            var csvFileReader = new CsvFileReader(ms);
            var fieldNameRow = new CsvRow();

            if (csvFileReader.ReadRow(fieldNameRow))
            {
                var currentRow = new CsvRow();
                var fieldNames = fieldNameRow.Select(x => x.Trim()).ToArray();

                while (csvFileReader.ReadRow(currentRow))
                {
                    var rowData = new Dictionary<String, String>();
                    for (var i = 0; i < fieldNames.Length && i < currentRow.Count; i++)
                    {
                        rowData.Add(fieldNames[i], currentRow[i]);
                    }

                    yield return _csvModelMapper.CreateInstance(rowData, _enableDynamicProxy);
                }
            }
        }
    }

    protected virtual void CheckCsvFile(String fileName, Byte[] bytes)
    {
        if (!CsvFileVerificator.IsValidHashCode(fileName, bytes.ComputeHashToHexString()))
        {

            throw new InvalidCsvFileException(fileName);
        }
    }

    protected virtual void LoadTextAssetBytesAsync(String assetPath, Action<Byte[]> callback)
    {
        LoadTextAssetAsync(assetPath, textAsset =>
        {
            if (textAsset != null)
            {
                callback(textAsset.bytes);
            }
            else
            {
                Debug.LogWarning(String.Format("Not found config file: {0}", assetPath));
                callback(null);
            }
        });
    }

    protected virtual Byte[] LoadTextAssetBytes(String assetPath)
    {
        var textAsset = LoadTextAsset(assetPath);
        if (textAsset != null)
        {
            return textAsset.bytes;
        }

        Debug.LogWarning(String.Format("Not found config file: {0}", assetPath));
        return null;
    }

	//不通过 jdk resource manager， 直接获取资源
	protected Byte[] LoadTextAssetBytesDirectly(String assetPath)
	{
		var textAsset = Resources.Load<TextAsset>(assetPath);
		if (textAsset != null)
		{
			return textAsset.bytes;
		}

		Debug.LogWarning(String.Format("Not found config file: {0}", assetPath));
		return null;
	}

    protected void LoadTextAssetAsync(String assetPath, Action<TextAsset> callback)
    {
		//TODO:
        //JDKResourceManager.Instance.LoadAssetAsync(assetPath, callback);
//		return null;
    }

    protected TextAsset LoadTextAsset(String assetPath)
    {
		//TODO:
//        return JDKResourceManager.Instance.LoadAsset<TextAsset>(assetPath);
		return null;
    }

	private static byte[] GetBytes(string str)
	{
		byte[] bytes = new byte[str.Length * sizeof(char)];
		System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
		return bytes;
	}

	private static string GetString(byte[] bytes)
	{
		char[] chars = new char[bytes.Length / sizeof(char)];
		System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
		return new string(chars);
	}


}