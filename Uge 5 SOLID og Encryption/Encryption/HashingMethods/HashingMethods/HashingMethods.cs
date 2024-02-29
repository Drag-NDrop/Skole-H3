using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashingMethods
{
    internal class HashingMethods
    {

        public static void PrintSHA512Hash(string input)
        {
            using (var sha512 = System.Security.Cryptography.SHA512.Create())
            {
                Console.WriteLine("Hashing text: " + input);
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha512.ComputeHash(bytes);
                Console.WriteLine("SHA512 hash of the text: " + input);
                Console.WriteLine(BitConverter.ToString(hash).Replace("-", "").ToLower());
            }
        }

        public string CreateSHA512Hash(string input)
        {
            using (var sha512 = System.Security.Cryptography.SHA512.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha512.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public static string PrintHMACSHA512Hash(string input, string key)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(Encoding.UTF8.GetBytes(key)))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = hmac.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        public static double CalculatePasswordEntropy(string password, int characterSetSize)
        {
            int length = password.Length;
            double entropy = length * Math.Log2(characterSetSize);
            return entropy;
        }



        public string CreateSalt(int size)
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[size];
            rng.GetBytes(buffer);
            return Convert.ToBase64String(buffer);
        }

        public string Create2898PBKDF2Hash(string input, string salt, int iterations)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            byte[] currentSalt = Convert.FromBase64String(salt);
            
            using (var pbkdf2 = new Rfc2898DeriveBytes(bytes, currentSalt, iterations, HashAlgorithmName.SHA512))
            {
                byte[] hash = pbkdf2.GetBytes(20);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }

        }
    
    
    
    }
}
