using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.BasicFunction
{
    public class DecryptKit
    {
        public const string privateKeyFileName = "RSA.Private";
        public const string LicenseFileName = "License.lic";
        /// <summary>
        /// 給訂授權資料夾路徑來解密
        /// </summary>
        /// <param name="licenseDirectory"></param>
        /// <returns></returns>
        public static string Decrypt(string licenseDirectory)
        {
            if (File.Exists(Path.Combine(licenseDirectory, LicenseFileName)))
            {
                var encryptedText = File.ReadAllText(Path.Combine(licenseDirectory, LicenseFileName));

                var pathToPrivateKey = Path.Combine(licenseDirectory, privateKeyFileName);

                return Decrypt(encryptedText, pathToPrivateKey);
            }
            else
                return null;

        }


        /// <summary>
        /// Decrypts encrypted text given a RSA private key file path.給定路徑的RSA私鑰文件解密 加密文本
        /// </summary>
        /// <param name="encryptedText">加密的密文</param>
        /// <param name="pathToPrivateKey">用於加密的私鑰路徑.</param>
        /// <returns>未加密數據的字符串</returns>
        public static string Decrypt(string encryptedText, string pathToPrivateKey)
        {
            if (string.IsNullOrEmpty(encryptedText))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(pathToPrivateKey))
            {
                throw new ArgumentException("Invalid Private Key");
            }

            using (var rsaProvider = new RSACryptoServiceProvider())
            {
                var inputBytes = Convert.FromBase64String(encryptedText);

                var privateKey = File.ReadAllText(pathToPrivateKey);
                rsaProvider.FromXmlString(privateKey);
                int bufferSize = rsaProvider.KeySize / 8;
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    {
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var rawBytes = rsaProvider.Decrypt(temp, false);
                        outputStream.Write(rawBytes, 0, rawBytes.Length);
                    }
                    return Encoding.UTF8.GetString(outputStream.ToArray());
                }
            }
        }
    }
}
