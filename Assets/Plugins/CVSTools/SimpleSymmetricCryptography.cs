using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// 对称加密算法工具类
/// </summary>
/// <remarks>
/// 目前支持的对称算法的实现包括以下几个：
/// 1、AesManaged
/// 2、AesCryptoServiceProvider
/// 3、RijndaelManaged
/// 4、DESCryptoServiceProvider
/// 5、RC2CryptoServiceProvider
/// 6、TripleDESCryptoServiceProvider 
/// </remarks>
public static class SimpleSymmetricCryptography
{
    private const Int32 Iterations = 1024;
    private static readonly Byte[] Salt = Encoding.ASCII.GetBytes("^s2lri&s04s90apy");

    private static Byte[] GenerateSalt(Byte[] bytes)
    {
        var currentSalt = new Byte[Salt.Length + bytes.Length];
        Array.Copy(Salt, 0, currentSalt, 0, Salt.Length);
        Array.Copy(bytes, 0, currentSalt, Salt.Length, bytes.Length);
        return currentSalt;
    }

    /// <summary>
    /// 使用 RijndaelManaged 实现的 AES-CBC-128 加密指定的明文
    /// </summary>
    /// <param name="plaintext">明文</param>
    /// <param name="password">密码</param>
    /// <returns>密文</returns>
    public static String Encrypt(String plaintext, String password)
    {
        return Encrypt<RijndaelManaged>(plaintext, password);
    }

    /// <summary>
    /// 用指定的对称算法加密明文（使用CBC运算模式及算法支持的最大BlockSize）
    /// </summary>
    /// <typeparam name="T">使用的对称算法类型</typeparam>
    /// <param name="plaintext">明文</param>
    /// <param name="password">密码</param>
    /// <param name="usingMaxKeySize">是否使用算法支持的最大密钥长度</param>
    /// <param name="useMaxBlockSize">使用支持的最大块大小(BlockSize)</param>
    /// <returns>密文</returns>
    public static String Encrypt<T>(String plaintext, String password, Boolean usingMaxKeySize = false, Boolean useMaxBlockSize = false)
        where T : SymmetricAlgorithm, new()
    {
        var plaintextData = Encoding.UTF8.GetBytes(plaintext);
        byte[] ciphertextData;

        try
        {
            using (var cipher = new T())
            {
                cipher.Mode = CipherMode.CBC;
                cipher.GenerateIV();
                cipher.BlockSize = useMaxBlockSize ? cipher.LegalBlockSizes[0].MaxSize : cipher.LegalBlockSizes[0].MinSize;

                var currentSalt = GenerateSalt(cipher.IV);
                var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, currentSalt, Iterations);
                var keySize = usingMaxKeySize ? cipher.LegalKeySizes[0].MaxSize : cipher.LegalKeySizes[0].MinSize;
                var key = rfc2898DeriveBytes.GetBytes(keySize / 8);

                using (var encryptor = cipher.CreateEncryptor(key, cipher.IV))
                {
                    using (var ms = new MemoryStream())
                    {
                        var ivLength = BitConverter.GetBytes(cipher.IV.Length);
                        ms.Write(ivLength, 0, ivLength.Length);
                        ms.Write(cipher.IV, 0, cipher.IV.Length);

                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            cs.Write(plaintextData, 0, plaintextData.Length);
                            cs.FlushFinalBlock();

                            ciphertextData = ms.ToArray();
                        }
                    }
                }
                cipher.Clear();
            }
        }
        catch (Exception exception)
        {
			UnityEngine.Debug.LogWarning(String.Format("SimpleSymmetricCryptography.Encrypt() failed. SymmetricAlgorithm: {0} ; Exception: {1}", typeof(T), exception));
            throw;
        }

        return Convert.ToBase64String(ciphertextData);
    }

    /// <summary>
    /// 使用 RijndaelManaged 实现的 AES-CBC-128 解密指定的密文
    /// </summary>
    /// <param name="ciphertext">密文</param>
    /// <param name="password">密码</param>
    /// <param name="plainText">解密成功，plainText 被设置为明文，否则为空字符串。</param>
    /// <returns>解密成功返回true，否则返回false</returns>
    public static Boolean TryDecrypt(String ciphertext, String password, out String plainText)
    {
        return TryDecrypt<RijndaelManaged>(ciphertext, password, out plainText);
    }

    /// <summary>
    /// 尝试用指定对称算法解密密文（使用CBC运算模式及算法支持的最大BlockSize）
    /// </summary>
    /// <typeparam name="T">使用的对称算法类型</typeparam>
    /// <param name="ciphertext">密文</param>
    /// <param name="password">密码</param>
    /// <param name="plainText">解密成功，plainText 被设置为明文，否则为空字符串。</param>
    /// <param name="usingMaxKeySize">是否使用算法支持的最大密钥长度</param>
    /// <param name="useMaxBlockSize">使用支持的最大块大小(BlockSize)</param>
    /// <returns>解密成功返回true，否则返回false</returns>
    public static Boolean TryDecrypt<T>(String ciphertext, String password, out String plainText, Boolean usingMaxKeySize = false, Boolean useMaxBlockSize = false) where T : SymmetricAlgorithm, new()
    {
        if (String.IsNullOrEmpty(ciphertext) || String.IsNullOrEmpty(password))
        {
            plainText = String.Empty;
            return false;
        }

        Byte[] plainTextData;
        Int32 decryptedByteCount;
        var ciphertextData = Convert.FromBase64String(ciphertext);

        try
        {
            using (var ms = new MemoryStream(ciphertextData))
            {
                var ivLength = new Byte[4];
                ms.Read(ivLength, 0, ivLength.Length);

                var iv = new Byte[BitConverter.ToInt32(ivLength, 0)];
                ms.Read(iv, 0, iv.Length);

                using (var cipher = new T())
                {
                    cipher.Mode = CipherMode.CBC;
                    cipher.BlockSize = useMaxBlockSize ? cipher.LegalBlockSizes[0].MaxSize : cipher.LegalBlockSizes[0].MinSize;

                    var currentSalt = GenerateSalt(iv);
                    var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, currentSalt, Iterations);
                    var keySize = usingMaxKeySize ? cipher.LegalKeySizes[0].MaxSize : cipher.LegalKeySizes[0].MinSize;
                    var key = rfc2898DeriveBytes.GetBytes(keySize / 8);

                    using (var decryptor = cipher.CreateDecryptor(key, iv))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            plainTextData = new Byte[ciphertextData.Length];
                            decryptedByteCount = cs.Read(plainTextData, 0, plainTextData.Length);
                        }
                    }

                    cipher.Clear();
                }
            }
        }
        catch (Exception exception)
        {
			UnityEngine.Debug.LogWarning(String.Format("SimpleSymmetricCryptography.TryDecrypt() failed. SymmetricAlgorithm: {0} ; Exception: {1}", typeof(T), exception));

            plainText = String.Empty;
            return false;
        }

        plainText = Encoding.UTF8.GetString(plainTextData, 0, decryptedByteCount);
        return true;
    }

    /// <summary>
    /// 将对象序列化数据通过指定加密算法加密后保存到文件
    /// </summary>
    /// <typeparam name="TSymmetricAlgorithm">使用的对称算法类型</typeparam>
    /// <typeparam name="TType">序列化对象的类型</typeparam>
    /// <param name="serializeToCryptoStream">将对象序列化到加密流的方法委托</param>
    /// <param name="obj">序列化对象</param>
    /// <param name="fileFullName">保存序列化数据的文件名</param>
    /// <param name="password">密码</param>
    /// <param name="usingMaxKeySize">是否使用算法支持的最大密钥长度</param>
    /// <param name="useMaxBlockSize">使用支持的最大块大小(BlockSize)</param>
    public static void Serialize<TSymmetricAlgorithm, TType>(Action<CryptoStream, TType> serializeToCryptoStream,
        TType obj, String fileFullName, String password, Boolean usingMaxKeySize = false,
        Boolean useMaxBlockSize = false)
        where TSymmetricAlgorithm : SymmetricAlgorithm, new()
    {
        try
        {
            using (var cipher = new TSymmetricAlgorithm())
            {
                cipher.Mode = CipherMode.CBC;
                cipher.GenerateIV();
                cipher.BlockSize = useMaxBlockSize
                    ? cipher.LegalBlockSizes[0].MaxSize
                    : cipher.LegalBlockSizes[0].MinSize;

                var currentSalt = GenerateSalt(cipher.IV);
                var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, currentSalt, Iterations);
                var keySize = usingMaxKeySize ? cipher.LegalKeySizes[0].MaxSize : cipher.LegalKeySizes[0].MinSize;
                var key = rfc2898DeriveBytes.GetBytes(keySize / 8);

                using (var encryptor = cipher.CreateEncryptor(key, cipher.IV))
                {
                    using (var ms = new FileStream(fileFullName, FileMode.Create, FileAccess.Write))
                    {
                        var ivLength = BitConverter.GetBytes(cipher.IV.Length);
                        ms.Write(ivLength, 0, ivLength.Length);
                        ms.Write(cipher.IV, 0, cipher.IV.Length);

                        using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            serializeToCryptoStream(cs, obj);
                            cs.FlushFinalBlock();
                        }
                    }
                }
                cipher.Clear();
            }
        }
        catch (Exception exception)
        {
			UnityEngine.Debug.LogWarning(
                String.Format(
                    "SimpleSymmetricCryptography.Serialize() failed. SymmetricAlgorithm: {0} ; Serialize Type: {1} Exception: {2}",
                    typeof(TSymmetricAlgorithm), typeof(TType), exception));

            if (File.Exists(fileFullName))
            {
                File.Delete(fileFullName);
            }
            throw;
        }
    }

    /// <summary>
    /// 从加密的序列化数据文件将对象反序列化
    /// </summary>
    /// <typeparam name="TSymmetricAlgorithm">使用的对称算法类型</typeparam>
    /// <typeparam name="TType">序列化对象的类型</typeparam>
    /// <param name="deserializeFromCryptoStream">从解密流执行反序列化的方法委托</param>
    /// <param name="fileFullName">保存序列化数据的文件名</param>
    /// <param name="password">密码</param>
    /// <param name="obj">如果发生异常，obj将被赋值为其类型对应的默认值，否则 deserializeFromCryptoStream 返回的结果将赋值给obj</param>
    /// <param name="usingMaxKeySize">是否使用算法支持的最大密钥长度</param>
    /// <param name="useMaxBlockSize">使用支持的最大块大小(BlockSize)</param>
    /// <returns>反序列操作成功则返回true，否则返回false</returns>
    public static Boolean TryDeserialize<TSymmetricAlgorithm, TType>(
        Func<CryptoStream, Type, TType> deserializeFromCryptoStream, String fileFullName, String password, out TType obj,
        Boolean usingMaxKeySize = false, Boolean useMaxBlockSize = false)
        where TSymmetricAlgorithm : SymmetricAlgorithm, new()
    {
        try
        {
            using (var ms = new FileStream(fileFullName, FileMode.Open, FileAccess.Read))
            {
                var ivLength = new Byte[4];
                ms.Read(ivLength, 0, ivLength.Length);

                var iv = new Byte[BitConverter.ToInt32(ivLength, 0)];
                ms.Read(iv, 0, iv.Length);

                using (var cipher = new TSymmetricAlgorithm())
                {
                    cipher.Mode = CipherMode.CBC;
                    cipher.BlockSize = useMaxBlockSize
                        ? cipher.LegalBlockSizes[0].MaxSize
                        : cipher.LegalBlockSizes[0].MinSize;

                    var currentSalt = GenerateSalt(iv);
                    var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, currentSalt, Iterations);
                    var keySize = usingMaxKeySize ? cipher.LegalKeySizes[0].MaxSize : cipher.LegalKeySizes[0].MinSize;
                    var key = rfc2898DeriveBytes.GetBytes(keySize / 8);

                    using (var decryptor = cipher.CreateDecryptor(key, iv))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            obj = deserializeFromCryptoStream(cs, typeof(Type));
                        }
                    }

                    cipher.Clear();
                }
            }
        }
        catch (Exception exception)
        {
			UnityEngine.Debug.LogWarning(
                String.Format(
                    "SimpleSymmetricCryptography.TryDeserialize() failed. SymmetricAlgorithm: {0} ; Deserialize Type: {1} Exception: {2}",
                    typeof(TSymmetricAlgorithm), typeof(TType), exception));
            obj = default(TType);
            return false;
        }

        return true;
    }

    /// <summary>
    /// 将字节数组转16进制字符串
    /// </summary>
    /// <param name="bytes">一个字节数组，要对该数组调用转换函数</param>
    /// <param name="separator">字节字符串之间的分隔符，默认为空</param>
    /// <returns></returns>
    public static String ToHexString(this Byte[] bytes, String separator = null)
    {
        return String.Join(separator ?? String.Empty, bytes.Select(b => b.ToString("X2")).ToArray());
    }

    /// <summary>
    /// 计算直接数组的 Hash（MD5），并将其转换为16进制字符串。
    /// </summary>
    /// <param name="bytes">一个字节数组，要对该数组调用转换函数</param>
    /// <returns>源字节数组Hash的16进制字符串</returns>
    public static String ComputeHashToHexString(this Byte[] bytes)
    {
        using (var md5 = MD5.Create())
        {
            return md5.ComputeHash(bytes).ToHexString();
        }
    }
}