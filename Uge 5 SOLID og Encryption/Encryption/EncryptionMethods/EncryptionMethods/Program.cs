using System.Security.Cryptography;
using System.Text;

namespace EncryptionMethods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hash calculator!");
            EncryptionClass encryptionClass = new EncryptionClass();

            HMAC myMAC;

            int choice = encryptionClass.TakeInput();
            if (choice == 1)
            {
                Console.WriteLine("You have selected SHA512");
                Console.WriteLine("Please enter the string to hash:");
                string input = Console.ReadLine();
                string result = encryptionClass.GetHash(choice, input);
                Console.WriteLine("Hash value: " + result);
            }
            else if (choice == 2)
            {
                
                Console.WriteLine("You have selected HMAC");
                Console.WriteLine("Please enter the string to hash:");
                string input = Console.ReadLine();
                string result = encryptionClass.GetHash(choice, input);
                Console.WriteLine("Hash value: " + result);
            }
            else if (choice == 0)
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Invalid choice");
            }
        }

    }
}
