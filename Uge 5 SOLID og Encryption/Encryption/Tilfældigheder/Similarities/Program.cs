using System.Numerics;

namespace Similarities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benchmark time!");
            Console.WriteLine("Testing pseudo randoms and \"Secure Randoms\" ");
            RandomTests randomTests = new RandomTests();

            RandomTests.RunBenchmark(randomTests.RunPseudoRandomTest, "PseudoRandomTest");
            Console.WriteLine("========================================================");
            RandomTests.RunBenchmark(randomTests.RunSecureRandomTest, "SecureRandomTest");

            Console.WriteLine("Testing Caesar Cipher encryption with the word: \"Hello\"");
            
            CaesarCipher caesarCipher = new CaesarCipher();
            int key = 1;
            string encryptedMessage = caesarCipher.Encrypt("Hello",key);
            
            Console.WriteLine($"Encrypted message: {encryptedMessage}");
            Console.WriteLine("========================================================");
            Console.WriteLine($"Testing Caesar Cipher decryption with the word: \"{encryptedMessage}\"");
            
            string decryptedMessage = caesarCipher.Decrypt(encryptedMessage, key);
            Console.WriteLine( decryptedMessage );



        }
    }
}
