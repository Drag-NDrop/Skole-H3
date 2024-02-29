using System.Text;

namespace SymmetricEncryptionTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Symmetric encryption test!");
            Console.WriteLine("================================================");
            Console.WriteLine("We will simulate a client server environment, where encrypted messages are \"passed over the internet\".");
            Console.WriteLine("The client will encrypt a message, and the server will decrypt it.");
            Console.WriteLine("The CryptoSecrets class will hold the configured shared secrets - key and IV - used for encryption and decryption.");
            Console.WriteLine("The client will create a message, encrypt it, and send it to the server.");
            Console.WriteLine("The server will receive the encrypted message, decrypt it, and display the original message.");

            Console.WriteLine("===========================================");
            Console.WriteLine("Step 1: Simulate configuration of both client and server secrecy.");
            Console.WriteLine("===========================================");
            Console.WriteLine("Choose a symmetric encryption algorithm:");
            Console.WriteLine("1. AES"); // valid sizes for aes key are 128, 192, 256 bits
            Console.WriteLine("2. DES"); // valid sizes for des key are 64 bits
            Console.WriteLine("3. TripleDES"); // valid sizes for tripledes key are 128, 192 bits
            Console.WriteLine("Enter a number:");
            string algorithmChoice = Console.ReadLine();
            SymmetricAlgorithmEnum algorithm = (SymmetricAlgorithmEnum)int.Parse(algorithmChoice);
            CryptoSecrets secrets = new CryptoSecrets(algorithm);
            Console.WriteLine("Key generated:");
            Console.WriteLine(Encoding.UTF8.GetString(secrets.Key));
            Console.WriteLine("IV generated:");
            Console.WriteLine(Encoding.UTF8.GetString(secrets.Iv));

            Console.WriteLine("Write a message to encrypt:");
            string message = Console.ReadLine();

            
            Client client = new Client(secrets);
            Server server = new Server(secrets);

            Console.WriteLine("=======================================");
            Console.WriteLine("Step 2: Simulate client sending an encrypted message to the server.");
            Console.WriteLine("=======================================");
            Console.WriteLine("Client encrypts message...");
            

            Message clientMessage = new Message(message, algorithm, secrets);
            client.SendEncryptedMessage(clientMessage, server);
            

        }
    }
}
