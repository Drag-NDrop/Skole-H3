using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SymmetricEncryptionTester
{


    internal class Server
    {
        CryptoSecrets _secrets;

        public Server(CryptoSecrets secrets)
        {
            _secrets = secrets;
        }

        public void ReceiveEncryptedMessage(Message message)
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("Step 3: This textblock is simulating the encrypted data, "); 
            Console.WriteLine("travelling over the internet, to reach its target server");
            Console.WriteLine("============================================================");

            Console.WriteLine( "=================================" );
            Console.WriteLine(" Step 4: Server handling of the encrypted message");
            Console.WriteLine( "=================================" );
            Console.WriteLine("Server receives encrypted message, from a client...");
            message.PrintEncryptedMessage();

            Console.WriteLine("Server decrypts the message using shared secrets");
            message.DecryptMessage(message.EncryptedMessage, _secrets);
            message.PrintDecryptedMessage();
        }


    }
}
