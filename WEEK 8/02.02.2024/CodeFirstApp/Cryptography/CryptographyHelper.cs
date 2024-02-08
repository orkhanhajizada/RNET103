using System.Security.Cryptography;
using System.Text;

namespace CodeFirstApp.Cryptography;

public class CryptographyHelper
{
    const string original = "Server=localhost;Database=CodeFirstApp;User Id=sa;Password=123456";

    const string key = "123";

    const string iv = "123";

    // This method is used to encrypt the connection string
    public static byte[] Encrypt(string plainText, ICryptoTransform cryptoTransform)
    {
        if (plainText == null || plainText.Length <= 0)
            throw new ArgumentNullException(nameof(plainText));

        using (MemoryStream ms = new MemoryStream())
        {
            using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Write))
            {
                using (StreamWriter sw = new StreamWriter(cs))
                {
                    sw.Write(plainText);
                }
            }

            return ms.ToArray();
        }

        // byte[] data = Encoding.UTF8.GetBytes(plainText);
        // using Aes aes = Aes.Create();
        // aes.Key = Encoding.UTF8.GetBytes(key);
        // aes.IV = Encoding.UTF8.GetBytes(iv);
        // using MemoryStream memoryStream = new();
        // using CryptoStream cryptoStream = new(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write);
        // cryptoStream.Write(data, 0, data.Length);
        // cryptoStream.FlushFinalBlock();
        // return Convert.ToBase64String(memoryStream.ToArray());
    }

    // This method is used to decrypt the connection string

    public static string Decrypt(byte[] cipherText, ICryptoTransform cryptoTransform)
    {
        if (cipherText == null || cipherText.Length <= 0)
            throw new ArgumentNullException(nameof(cipherText));

        using (MemoryStream ms = new MemoryStream(cipherText))
        {
            using (CryptoStream cs = new CryptoStream(ms, cryptoTransform, CryptoStreamMode.Read))
            {
                using (StreamReader sr = new StreamReader(cs))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        // byte[] data = Convert.FromBase64String(cipherText);
        // using Aes aes = Aes.Create();
        // aes.Key = Encoding.UTF8.GetBytes(key);
        // aes.IV = Encoding.UTF8.GetBytes(iv);
        // using MemoryStream memoryStream = new();
        // using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
        // cryptoStream.Write(data, 0, data.Length);
        // cryptoStream.FlushFinalBlock();
        // return Encoding.UTF8.GetString(memoryStream.ToArray());
    }

    // public static string Decrypt(string cipherText)
    // {
    //     byte[] data = Convert.FromBase64String(cipherText);
    //     using Aes aes = Aes.Create();
    //     aes.Key = Encoding.UTF8.GetBytes("1234567890123456");
    //     aes.IV = Encoding.UTF8.GetBytes("1234567890123456");
    //     using MemoryStream memoryStream = new();
    //     using CryptoStream cryptoStream = new(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write);
    //     cryptoStream.Write(data, 0, data.Length);
    //     cryptoStream.FlushFinalBlock();
    //     return Encoding.UTF8.GetString(memoryStream.ToArray());
    // }
}

public interface ICryptographyService
{
    string Encrypt(string plainText, string tenancyName);
    string Decrypt(string cipherText, string tenancyName);
}

public class CryptographyService : ICryptographyService
{
    private const string key = "6A7B8C9D0E1F2G3H4I5J6K7L8M9N0O1P";

    private byte[] _keyBytes = new byte[32];
    private byte[] _ivBytes = new byte[16];

    public string Decrypt(string cipherText, string tenancyName)
    {
        string iv = $"{tenancyName}{key}";

        Array.Copy(new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(key)), _keyBytes, _keyBytes.Length);
        Array.Copy(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(iv)), _ivBytes,
            _ivBytes.Length);

        using (var aes = Aes.Create())
        {
            aes.Key = _keyBytes;
            aes.IV = _ivBytes;
            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            return CryptographyHelper.Decrypt(Convert.FromBase64String(cipherText), decryptor);
        }
    }

    public string Encrypt(string plainText, string tenancyName)
    {
        string iv = $"{tenancyName}{key}";

        Array.Copy(new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(key)), _keyBytes, _keyBytes.Length);
        Array.Copy(new MD5CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(iv)), _ivBytes,
            _ivBytes.Length);

        using (var aes = Aes.Create())
        {
            aes.Key = _keyBytes;
            aes.IV = _ivBytes;
            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            return Convert.ToBase64String(CryptographyHelper.Encrypt(plainText, encryptor));
        }
    }
}