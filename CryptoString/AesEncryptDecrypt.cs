using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AesEncryptDecrypt
{
    //32 for key
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("ChiavePippo".PadRight(32, '\0')).Take(32).ToArray();

    //16 bit for initialization vector 
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("VettoreIniziale".PadRight(16, '\0')).Take(16).ToArray();

    public static string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    public static string Decrypt(string cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }

    private static byte[] GenerateRandomKey(int keyLengthInBits)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            byte[] key = new byte[keyLengthInBits / 8];
            rng.GetBytes(key);
            return key;
        }
    }
}
