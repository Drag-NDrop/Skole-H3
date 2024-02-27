using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;

namespace Similarities
{
    internal class RandomTests
    {
        Random random = new Random(); 

        public void RunPseudoRandomTest() {
            
            for (int i = 0; i < 1000000; i++)
            {
                PseudoRandomTest(random);
            }
        }

        public void RunSecureRandomTest()
        {
            for (int i = 0; i < 1000000; i++) {
                SecureRandomTest();
            }
        }
        public void PseudoRandomTest(Random random) // Dependency injection
        {
            random.Next();
        }
        public void SecureRandomTest()
        {
            RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create();// Antal bytes afhænger af datatypen (her bruger vi 4 bytes til et int)
            byte[] randomBytes = new byte[4]; 
            randomNumberGenerator.GetBytes(randomBytes); // Konverterer byte-arrayet til en int
            int randomNumber = BitConverter.ToInt32(randomBytes, 0); 
        }

        public static void RunBenchmark(Action benchmarkMethod, string methodName)
        {
            long startTime = DateTime.Now.Ticks;
            benchmarkMethod();
            long endTime = DateTime.Now.Ticks;
            long elapsedTime = endTime - startTime;
            Console.WriteLine($"{methodName} tid (ticks): {elapsedTime}");
        }
    }
}
