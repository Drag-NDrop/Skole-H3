using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace EncryptionMethods
{
    internal class EncryptionClass
    {


        public int TakeInput() {
            Console.WriteLine("Please select an encryption algorithm:");
            Console.WriteLine("1. SHA512");
            Console.WriteLine("2. HMAC");
            Console.WriteLine("7. Exit");

            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    return 1;
                
                case '2':
                    return 2;
                
                case '7':
                    return 0;
                
                default:
                    return 0;
            }
        }
        public string Sha512(string input)
        {
            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(input));
                Console.WriteLine("Hex value of the SHA512: " + ByteArrayToHexString(hash));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }

        public HMAC CreateHMAC()
        {
            HMAC myMAC;
            Console.WriteLine("Please enter the key for the HMAC:");
            string key = Console.ReadLine();
            myMAC = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            Console.WriteLine("Hex value of the HMACSHA256: " + ByteArrayToHexString(myMAC.Hash));
            return myMAC;
        }

        
        public string Hmac(string input, HMAC hmac)
        {
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(input));

            return BitConverter.ToString(hash).Replace("-", "");
        }

        public string GetHash(int choice, string input)
        {
            
            if (choice == 1)
            {
                return Sha512(input);
            }
            else if (choice == 2)
            {
                HMAC hmac = CreateHMAC();
                return Hmac(input, hmac);
            }
            else
            {
                return "Invalid choice";
            }
        }

        public void PrintHash(string hash)
        {
            Console.WriteLine("The hash is: " + hash);
        }
        public static string ByteArrayToHexString(byte[] bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Length * 2);
            foreach (byte b in bytes)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }
    }


    
}
