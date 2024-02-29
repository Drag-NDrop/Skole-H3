using System.Security.Cryptography;
using System.Text;

namespace AssymetricEncryption
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assymetric encryption!");
            Console.WriteLine("I'm going to use classes to demonstrate two seperate programs.");
            Console.WriteLine("The first program will encrypt a message and print it to the console.");
            Console.WriteLine("The second program will decrypt the message and print it to the console.");

            Console.WriteLine("Creating a new reciever, and writing its public key:");
            RSAReciever reciever = new RSAReciever();
            reciever.PrintRSAParameters();
            
            // Create a new sender, and load its public key, from the reciever, into the sender
            RSASender sender = new RSASender();
            Console.WriteLine("Please input the public key parameters for the sender.");
            
            // Take input from the user -- This indicates that a client would need to know the public key of the server
            Tuple<byte[], byte[]> keyParams = sender.TakeInputRSAParameters(); // This is the public key parameters for the sender
            // byte[] encryptedBytes = TakeEncryptedInput();
            // Create an RSA key based on the input Exponent/Modulus
            RSA rsa = sender.CreateRSAKey(keyParams); // Create an RSA key based on the input Exponent/Modulus

            // Create an encrypted message on the sender's side, using the public key from the reciever, we just loaded into the sender
            string encryptedMessage = sender.EncryptMessage(rsa);
            Console.WriteLine("Base64 encoded version of the RSA encrypted message: " + encryptedMessage);

            // Reciever decrypts the message
            byte[] encryptedBytes = reciever.TakeEncryptedInput();

            // Decrypt the message
            byte[] decryptedBytes = reciever.rsa.Decrypt(encryptedBytes, RSAEncryptionPadding.Pkcs1); // Decrypt the message using the reciever's private key
            Console.WriteLine("Decrypted message: " + Encoding.UTF8.GetString(decryptedBytes));


        }
    }
}
