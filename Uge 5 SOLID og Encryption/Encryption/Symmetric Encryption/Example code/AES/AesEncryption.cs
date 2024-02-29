using System.IO;
using System.Security.Cryptography;

namespace CryptographyInDotNet
{
    public class AesEncryption 
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
            using (var aes = Aes.Create())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                
                aes.Key = key;
                aes.IV = iv;

                using (var memoryStream = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), 
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToEncrypt, 0, dataToEncrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv)
        {                                
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;

                aes.Key = key;
                aes.IV = iv;

                using (var memoryStream = new MemoryStream())
                {                       
                    var cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), 
                        CryptoStreamMode.Write);

                    cryptoStream.Write(dataToDecrypt, 0, dataToDecrypt.Length);
                    cryptoStream.FlushFinalBlock();

                    var decryptBytes = memoryStream.ToArray();

                    return decryptBytes;
                }
            }                            
        }
    }
}