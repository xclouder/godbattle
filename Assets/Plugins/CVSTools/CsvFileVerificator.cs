using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

/// <summary>
/// Csv文件验证器
/// </summary>
public class CsvFileVerificator
{
    /// <summary>
    /// 用于加密/解密Csv配置文件HashCode的密码
    /// </summary>
    private const String HashPassword =
        "But if I had...If I had goodness I lost it.If I had anything tender in me.I shot it dead.";

    /// <summary>
    /// 用于加密/解密CSv指纹文件内容的密码
    /// </summary>
    private const String FingerprintPassword = "The outer world you see is a reflection of your inner self.";

    /// <summary>
    /// Csv文件名与校验码分隔符
    /// </summary>
    public const Char NameAndCodeSeparator = '-';

    /// <summary>
    /// Csv文件校验码之间的分隔符
    /// </summary>
    public const Char FileCodeSeparator = ';';

    private readonly Dictionary<String, String> _vCodes = new Dictionary<String, String>();

    private static CsvFileVerificator _instance;

    private static CsvFileVerificator Instance
    {
        get
        {
            ForceInit();
            return _instance;
        }
    }

    /// <summary>
    /// 强制初始化文件验证器的单例。注意： 需要在主线程中调用该方法确保单例被正确初始化
    /// </summary>
    public static void ForceInit()
    {
        if (_instance == null)
        {
            _instance = new CsvFileVerificator("fingerprint");
        }
    }

    /// <summary>
    /// 强制重新加载指纹文件。该方法仅可在 Unity 编辑器环境调用，其他环境调用将抛出异常。
    /// </summary>
    /// <exception cref="InvalidOperationException">在非 Unity 编辑器环境下调用该方法抛出该异常。</exception>
    public static void ForceUpdate()
    {
# if UNITY_EDITOR
        _instance = new CsvFileVerificator("fingerprint");
# else
        throw new InvalidOperationException("ForceUpdateCache() 方法仅在 Unity 编辑器环境可用。"); 
#endif
    }

    /// <summary>
    /// 获取所有Csv文件的指纹信息
    /// </summary>
    /// <returns>文件指纹信息字典， key为文件名， value为指纹</returns>
    public static Dictionary<String, String> GetAllVCodes()
    {
        return new Dictionary<String, String>(Instance._vCodes);
    }

    /// <summary>
    /// 检查Csv配置文件的Hash是否有效
    /// </summary>
    /// <param name="configFileName">配置文件名</param>
    /// <param name="hashCode">文件Hash的16进制字符串</param>
    /// <returns>若与指纹文件中的Hash匹配，返回true，否则返回false</returns>
    public static Boolean IsValidHashCode(String configFileName, String hashCode)
    {
        if (String.IsNullOrEmpty(hashCode))
        {
            return false;
        }

        String vCode;
        return Instance._TryGetVCode(configFileName, out vCode) && DecryptHashCode(vCode) == hashCode;
    }

    /// <summary>
    /// 加密hash码
    /// </summary>
    /// <param name="hashCode">hash码</param>
    /// <returns>加密后的VCode</returns>
    public static String EncryptHashCode(String hashCode)
    {
        return hashCode != null
            ? SimpleSymmetricCryptography.Encrypt<RC2CryptoServiceProvider>(hashCode, HashPassword)
            : String.Empty;
    }

    /// <summary>
    /// 解密hash码
    /// </summary>
    /// <param name="vCode">hash码加密后的VCode</param>
    /// <returns>hash码</returns>
    public static String DecryptHashCode(String vCode)
    {
        String hashCode;
        SimpleSymmetricCryptography.TryDecrypt<RC2CryptoServiceProvider>(vCode, HashPassword, out hashCode);
        return hashCode;
    }

    /// <summary>
    /// 加密指纹内容
    /// </summary>
    /// <param name="fingerprintContent">指纹明文</param>
    /// <returns>指纹密文</returns>
    public static String EncryptFingerprintContent(String fingerprintContent)
    {
        return SimpleSymmetricCryptography.Encrypt(fingerprintContent, FingerprintPassword);
    }

    private CsvFileVerificator(String fingerprintFileName)
    {
        var textAsset = Load(fingerprintFileName);
        if (textAsset != null)
        {
            String ciphertext;
            using (var sr = new StreamReader(new MemoryStream(textAsset.bytes), Encoding.UTF8))
            {
                ciphertext = sr.ReadToEnd();
            }

            String plaintext;
            if (SimpleSymmetricCryptography.TryDecrypt(ciphertext, FingerprintPassword, out plaintext))
            {
                foreach (var nameAndCode in plaintext.Split(FileCodeSeparator).Select(item => item.Split(NameAndCodeSeparator)).Where(nameAndCode => nameAndCode.Length == 2))
                {
                    if (_vCodes.ContainsKey(nameAndCode[0]))
                    {
                        _vCodes[nameAndCode[0]] = nameAndCode[1];
                    }
                    else
                    {
                        _vCodes.Add(nameAndCode[0], nameAndCode[1]);
                    }
                }
            }
            else
            {
                Debug.LogWarning(String.Format("fingerprint_ciphertext: {0}", ciphertext));
				Debug.LogWarning(String.Format("Decrypt the fingerprint file failed: {0}", fingerprintFileName));
            }
        }
        else
        {
			Debug.LogWarning(String.Format("Not found fingerprint file: {0}", fingerprintFileName));
        }
    }

    private Boolean _TryGetVCode(String configFileName, out String vCode)
    {
        return  _vCodes.TryGetValue(configFileName, out vCode);
    }

    private static TextAsset Load(String fingerprintFileName)
    {
        var path = Path.Combine("Configs", fingerprintFileName).Replace(Path.DirectorySeparatorChar, '/');
        return Resources.Load<TextAsset>(path);
    }
}