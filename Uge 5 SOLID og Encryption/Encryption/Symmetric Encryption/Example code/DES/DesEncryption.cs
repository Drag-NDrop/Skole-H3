using System.IO;
using System.Security.Cryptography;

namespace CryptographyInDotNet
{
    public class DesEncryption 
    {
        public  byte[] GenerateRandomNumber(int length)
        {
            var randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[length]; // Brug length parameteren til at bestemme antallet af bytes
            randomNumberGenerator.GetBytes(randomBytes);

            return randomBytes;
        }

        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv)
        {
            using (var des = DES.Create())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = key;
                des.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(), 
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {                                
            using (var des = new DESCryptoServiceProvider())
            {
                des.Mode = CipherMode.CBC;
                des.Padding = PaddingMode.PKCS7;

                des.Key = key;
                des.IV = iv;

                using (var memoryStream = new MemoryStream())
                {                       
                    var cryptoStream = new CryptoStream(memoryStream, des.CreateDecryptor(), 
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }                            
        }
    }
}