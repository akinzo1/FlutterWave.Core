using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class PayloadEncryptor
{

    public static string Decrypt(string encryptionKey, string encryptedText)
    {
        byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);
        byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

        using (var desProvider = TripleDES.Create())
        {
            desProvider.Mode = CipherMode.ECB;
            desProvider.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform decryptor = desProvider.CreateDecryptor(keyBytes, new byte[8]))
            using (MemoryStream memoryStream = new MemoryStream(encryptedBytes))
            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            using (StreamReader streamReader = new StreamReader(cryptoStream))
            {
                return streamReader.ReadToEnd();
            }
        }
    }

    public static string Encrypt(string encryptionKey, string payload)
    {
        string text = payload;
        byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);
        byte[] textBytes = Encoding.UTF8.GetBytes(text);

        using (var desProvider = TripleDES.Create())
        {
            desProvider.Mode = CipherMode.ECB;
            desProvider.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform encryptor = desProvider.CreateEncryptor(keyBytes, new byte[8]))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(textBytes, 0, textBytes.Length);
                    cryptoStream.FlushFinalBlock();
                }

                byte[] encryptedBytes = memoryStream.ToArray();
                return Convert.ToBase64String(encryptedBytes);
            }
        }
    }

 





}
