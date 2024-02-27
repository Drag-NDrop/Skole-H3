using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet;
using Microsoft.Diagnostics.Tracing.Parsers.FrameworkEventSource;

namespace Similarities
{
    internal class CaesarCipher
    {
        private readonly string _alphabet = "abcdefghijklmnopqrstuvwxzæøå";


        public string Encrypt(string message, int key){
            string encryptedMessage = "";   
            foreach (char character in message.ToLower())
            {
                int cIndex = _alphabet.IndexOf(character); // character index
                int eIndex = cIndex + key; // encrypted index
                if (eIndex > _alphabet.Length)
                {
                    int diff = eIndex - _alphabet.Length;
                    eIndex = diff;
                }
                encryptedMessage += _alphabet[eIndex];
            }

            return encryptedMessage;
        }

        public string Decrypt(string message, int key)
        {
            string decryptedMessage = "";
            foreach (char character in message.ToLower())
            {
                int cIndex = _alphabet.IndexOf(character); // character index
                int eIndex = (cIndex - key); // encrypted index
                if (eIndex < 0)
                {
                    int diff = _alphabet.Length + eIndex;
                    eIndex = diff;
                }
                decryptedMessage += _alphabet[eIndex];
               
            }

            return decryptedMessage;
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
