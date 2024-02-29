using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymmetricEncryptionTester
{
    internal class Client
    {
        CryptoSecrets _secrets;

        public Client(CryptoSecrets secrets)
        {
            _secrets = secrets;
        }

        public void SendEncryptedMessage(Message message, Server targetServer)
        {
            Console.WriteLine("Client sends encrypted message to server...");
            Console.WriteLine("Encrypted message(Base64 Encoded): " + message.EncryptedMessage);
            targetServer.ReceiveEncryptedMessage(message);
        }

    }
}
