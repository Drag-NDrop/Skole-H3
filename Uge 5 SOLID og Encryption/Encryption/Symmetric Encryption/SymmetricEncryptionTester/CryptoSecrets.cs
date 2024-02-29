using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryptionTester
{
    internal class CryptoSecrets
    {
        private byte[] _key;
        private byte[] _iv;
        public SymmetricAlgorithmEnum _encryptionAlgorithm;

        public byte[] Iv
        {
            get
            {
                return _iv;
            }

            private set
            {
                _iv = value;
            }
        }

        public byte[] Key
        {
            get
            {
                return _key;
            }

            private set
            {
                _key = value;
            }
        }

        public CryptoSecrets(SymmetricAlgorithmEnum encryptionAlgorithm)
        {
            int key;
            int iv;
            switch(encryptionAlgorithm)
            {
                case SymmetricAlgorithmEnum.AES:
                    _key = GenerateRandomNumber(32);
                    _iv = GenerateRandomNumber(16);
                    _encryptionAlgorithm = SymmetricAlgorithmEnum.AES;
                    break;
                case SymmetricAlgorithmEnum.DES:
                    _key = GenerateRandomNumber(8);
                    _iv = GenerateRandomNumber(8);
                    _encryptionAlgorithm = SymmetricAlgorithmEnum.DES;
                    break;
                case SymmetricAlgorithmEnum.TRIPLEDES:
                    _key = GenerateRandomNumber(24);
                    _iv = GenerateRandomNumber(8);
                    _encryptionAlgorithm = SymmetricAlgorithmEnum.TRIPLEDES;
                    break;
                default:
                    throw new ArgumentException("Invalid encryption algorithm");
            }   

              
        }
        public void PrintSecrets()
        {
            Console.WriteLine("Key: " + Key);
            Console.WriteLine("IV: " + Iv);
            Console.WriteLine("Encryption Algorithm: " + _encryptionAlgorithm);
        }


        public byte[] GenerateRandomNumber(int length)
        {
            var randomNumberGenerator = RandomNumberGenerator.Create();
            byte[] randomBytes = new byte[length]; // Brug length parameteren til at bestemme antallet af bytes
            randomNumberGenerator.GetBytes(randomBytes);

            return randomBytes;
        }
    }
}
