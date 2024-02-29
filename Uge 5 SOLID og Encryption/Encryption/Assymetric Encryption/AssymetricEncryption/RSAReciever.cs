using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace AssymetricEncryption
{
    public class RSAReciever
    {
        public RSA rsa = RSA.Create();
        public RSAReciever()
        {
            rsa.KeySize = 2048;
            Console.WriteLine("RSA Reciever created with a key size of 2048.");
            
        }

        public byte[] TakeEncryptedInput() {
            Console.WriteLine("Please enter encrypted data:");
            string encryptedData = Console.ReadLine();
            byte[] encryptedBytes = Convert.FromBase64String(encryptedData);
            return encryptedBytes;
        }

        public string DecryptMessage(byte[] encryptedBytes)
        {
            byte[] decryptedBytes = rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1);
            string decryptedMessage = Encoding.UTF8.GetString(decryptedBytes);
            
            return Encoding.UTF8.GetString(Convert.FromBase64String(decryptedMessage));
        }

        public void PrintRSAParameters()
        {
            Console.WriteLine("RSA Reciever, private key Parameters:");
            Console.WriteLine("Key Size: " + rsa.KeySize);
            Console.WriteLine("Exponent: " + Convert.ToBase64String(rsa.ExportParameters(true).Exponent));
            Console.WriteLine("Modulus: " + Convert.ToBase64String(rsa.ExportParameters(true).Modulus));
        }   
    }
}
