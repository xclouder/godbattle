using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;


/// <summary>
/// 与远程服务器安全通信辅助工具类
/// <summary>
/// 1、RSA公钥加密和签名
/// 2、生成 DES 密钥和初始向量
/// </summary>
/// </summary>
public static class MazeUtil
{
    private const String FileName = "Configs/pub_key";
    private static readonly Byte[] Pwd = { 0x6d, 0x6d, 0x73, 0x74, 0x68, 0x64, 0x68, 0x7a, 0x79, 0x74, 0x63, 0x68 };
    private static readonly System.Random KeyRandom = new System.Random();
    private static readonly RSACryptoServiceProvider Rsa;
    
    static MazeUtil()
    {
		//TODO:
		TextAsset textAsset = null;//JDKResourceManager.Instance.LoadAsset<TextAsset>(FileName);
        if (textAsset != null)
        {
            String pubKey;
            if (SimpleSymmetricCryptography.TryDecrypt(Encoding.ASCII.GetString(textAsset.bytes),
                Encoding.ASCII.GetString(Pwd), out pubKey))
            {
                Rsa = new RSACryptoServiceProvider();
                Rsa.FromXmlString(pubKey);
            }
            else
            {
                throw new Exception(String.Format("无效的公钥文件: {0} ，请核对后再试。", FileName));
            }
        }
        else
        {
            throw new Exception(String.Format("无法加载公钥文件: {0} ， 请确认后再试。", FileName));
        }
    }

    /// <summary>
    /// 加密信息
    /// </summary>
    /// <param name="message">待加密的数据</param>
    /// <returns>密文</returns>
    public static Byte[] Encrypt(Byte[] message)
    {
        return Rsa.Encrypt(message, false);
    }

    /// <summary>
    /// 加密信息
    /// </summary>
    /// <param name="message">待加密的数据</param>
    /// <returns>Base64编码的密文</returns>
    public static String EncryptToBase64(Byte[] message)
    {
        return Convert.ToBase64String(Encrypt(message));
    }

    /// <summary>
    /// 将数据通过 UTF8 编码以后再加密
    /// </summary>
    /// <param name="message">待加密的数据</param>
    /// <returns>Base64编码的密文</returns>
    public static String EncryptToBase64(String message)
    {
        var crypto = Encrypt(Encoding.UTF8.GetBytes(message));
        return Convert.ToBase64String(crypto);
    }

    /// <summary>
    /// 验证签名
    /// </summary>
    /// <param name="buffer">Base64编码的数据</param>
    /// <param name="signature">Base64编码的签名</param>
    /// <returns>是否通过验证</returns>
    public static Boolean Verify(String buffer, String signature)
    {
        return Verify(Convert.FromBase64String(buffer), Convert.FromBase64String(signature));
    }

    /// <summary>
    /// 验证签名
    /// </summary>
    /// <param name="buffer">数据</param>
    /// <param name="signature">签名</param>
    /// <returns>是否通过验证</returns>
    public static Boolean Verify(Byte[] buffer, Byte[] signature)
    {
        return Rsa.VerifyData(buffer, "SHA1", signature);
    }

    /// <summary>
    /// 生成一个发送给远程服务器的随机 Key
    /// </summary>
    /// <returns>随机 Key</returns>
    public static Byte[] GenerateFirstRandomKey()
    {
        return BitConverter.GetBytes(KeyRandom.Next());
    }

    /// <summary>
    /// 生成一个用于 DES 的密钥和初始向量
    /// </summary>
    /// <returns>DES 密钥和初始向量, 长度为 16 个字节， 其中前面 8 字节用着密钥，后面 8 字节用着初始向量</returns>
    public static Byte[] GenerateKey4DES()
    {
        var key = new Byte[16];
        for (var i = 0; i < 4; i++)
        {
            Array.Copy(BitConverter.GetBytes(KeyRandom.Next()), 0, key, i * 4, 4);
        }

        return key;
    }

    /// <summary>
    /// 将本地生成的随机 Key 和远程服务器生成的随机 Key 合并成一个 DES 密钥和初始向量
    /// </summary>
    /// <param name="localKey">本地随机 Key</param>
    /// <param name="remoteKey">远程服务器返回的随机 Key</param>
    /// <returns>DES 密钥和初始向量, 长度为 16 个字节， 其中前面 8 字节用着密钥，后面 8 字节用着初始向量</returns>
    public static Byte[] MergeRandomKey4DES(Byte[] localKey, Byte[] remoteKey)
    {
        var totalLength = localKey.Length + remoteKey.Length;

        if (totalLength > 16 || totalLength < 8)
        {
            throw new ArgumentException("本地 Key 与远程 Key 的长度之和必须在 8 到 16 之间。");
        }

        var key = new Byte[16];
        Array.Copy(localKey, key, localKey.Length);
        Array.Copy(remoteKey, 0, key, localKey.Length, remoteKey.Length);

        return key;
    }
}
