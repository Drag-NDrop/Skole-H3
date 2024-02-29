using CryptographyInDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryptionTester
{
    enum CryptoOperation
    {
        encrypt,
        decrypt
    }

    enum SymmetricAlgorithmEnum
    {
        AES = 1,
        DES = 2,
        TRIPLEDES = 3
    }
    internal class Message
    {
        string? _message; // Message to encrypt or decrypt
        string _encryptedMessage; // Encrypted message
        string _decryptedMessage; // Decrypted message
        // NOTICE: The lack of secrets. No key is inherently known. And no IV is known either. This reflects the real world, where both client and server have to agree on a shared secret.
        // And keep the configuration secret.
        // In this case, the CryptoSecrets class is used to hold the shared secret. And is only provided during construction of the Message class.
        // This way the Message class can only encrypt and decrypt messages, if it has the shared secret. Optimally, to better reflect the real world, the logic in this class would be implemented both in the client and server.
        // But then arguments about redundancy and code duplication would arise. So we have to make a tradeoff. This is a demo after all.

        SymmetricAlgorithmEnum _desiredAlgorithm;

        public string EncryptedMessage
        {
            get
            {
                return _encryptedMessage;
            }

            private set
            {
                _encryptedMessage = value;
            }
        }

        public Message(string message, SymmetricAlgorithmEnum desiredAlgorithm, CryptoSecrets secrets)
        {
            _message = message;
            _desiredAlgorithm = desiredAlgorithm;
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            EncryptMessage(messageBytes, secrets);
            this._message = null; // Clear the message from memory, so only the encrypted message is left.
            Console.WriteLine("The message has now been encrypted, and the cleartext version you entered, has been wiped from memory.");
        }

        public void EncryptMessage(byte[] message, CryptoSecrets secrets) {
            byte[] encryptedMessage;

            switch (_desiredAlgorithm)
            {   
                case SymmetricAlgorithmEnum.AES:
                   encryptedMessage = AesEncryption.Encrypt(message, secrets.Key, secrets.Iv);
                   _encryptedMessage = Convert.ToBase64String(encryptedMessage);
                    break;
                case SymmetricAlgorithmEnum.DES:
                    encryptedMessage = DesEncryption.Encrypt(message, secrets.Key, secrets.Iv);
                    _encryptedMessage = Convert.ToBase64String(encryptedMessage);

                    break;
                case SymmetricAlgorithmEnum.TRIPLEDES:
                    encryptedMessage = TripleDesEncryption.Encrypt(message, secrets.Key, secrets.Iv);
                    _encryptedMessage = Convert.ToBase64String(encryptedMessage);
                    break;
                
                default:
                    Console.WriteLine("Unknown algorithm target");
                    break;
            }

        }
        public void PrintEncryptedMessage()
        {
            Console.WriteLine("Encrypted message: " + _encryptedMessage);
        }

        public void DecryptMessage(string encryptedMessage, CryptoSecrets secrets)
        {
            byte[] encryptedMessageBytes = Convert.FromBase64String(encryptedMessage);// Convert from Base64 to byte array

            byte[] decryptedMessage;
            switch (_desiredAlgorithm)
            {
                case SymmetricAlgorithmEnum.AES:
                    decryptedMessage = AesEncryption.Decrypt(encryptedMessageBytes, secrets.Key, secrets.Iv);
                    _decryptedMessage = Encoding.UTF8.GetString(decryptedMessage);

                    break;
                case SymmetricAlgorithmEnum.DES:
                    decryptedMessage = DesEncryption.Decrypt(encryptedMessageBytes, secrets.Key, secrets.Iv);
                    _decryptedMessage = Encoding.UTF8.GetString(decryptedMessage);
                    
                    break;
                case SymmetricAlgorithmEnum.TRIPLEDES:
                    decryptedMessage = TripleDesEncryption.Decrypt(encryptedMessageBytes, secrets.Key, secrets.Iv);
                    _decryptedMessage = Encoding.UTF8.GetString(decryptedMessage);
                    break;

                default:
                    Console.WriteLine("Unknown algorithm target");
                    break;
            }

        }
        public void PrintDecryptedMessage()
        {
            Console.WriteLine("Decrypted message: " + _decryptedMessage);
        }
    }
}
