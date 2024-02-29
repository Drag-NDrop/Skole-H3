using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AssymetricEncryption
{
    internal class RSASender
    {

        public Tuple<byte[],byte[]> TakeInputRSAParameters()
        {
            Console.WriteLine("Please input the base64 public key exponent: ");
            string base64exponent = Console.ReadLine();
            byte[] exponent = Convert.FromBase64String(base64exponent);

            Console.WriteLine("Please input the public key modulus: ");
            string base64modulus = Console.ReadLine();
            byte[] modulus = Convert.FromBase64String(base64modulus);

            Tuple < byte[], byte[]> key = new Tuple<byte[], byte[]>(exponent, modulus);
            return key;
        }



        public RSA CreateRSAKey(Tuple<byte[], byte[]>keyParams) // Create an RSA key based on the input Exponent/Modulus
        {
            RSAParameters rsaParameters = new RSAParameters(); // Create a new RSAParameters object
            rsaParameters.Exponent = keyParams.Item1;          // Set the Exponent property to the input exponent
            rsaParameters.Modulus = keyParams.Item2;           // Set the Modulus property to the input modulus
            RSA rsa = RSA.Create(rsaParameters);               // Create a new RSA object with the RSAParameters object
            Console.WriteLine("RSA Sender created an RSA key based on the input Exponent/Modulus");
            return rsa;
        }

        public string EncryptMessage(RSA rsa)
        {
            Console.WriteLine("Enter a message to encrypt. Keep it short.");
            string message = Console.ReadLine();
            byte[] messageBytes = Encoding.UTF8.GetBytes(message); // Convert the message to bytes
            byte[] encryptedBytes = rsa.Encrypt(messageBytes, RSAEncryptionPadding.Pkcs1); // Encrypt the message using the reciever's public key
            return Convert.ToBase64String(encryptedBytes);
        }

    }
}
