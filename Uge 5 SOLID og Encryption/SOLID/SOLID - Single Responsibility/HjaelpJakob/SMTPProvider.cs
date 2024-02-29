using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpJakob
{
    internal class SMTPProvider : IProvider
    {
        public string ProviderName { get; set; }
        public MessageCarrier MessageCarrier { get; set; }


        public bool SendMessage(IMessage m)
        {
            // This sends the message to the recipient via the provider specified in the message
            try
            {
                Console.WriteLine("Sent message via SMTP Carrier as " + m.bodyType);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, message disintegrated..");
                return false;
            }
            
         
        }

        public bool sendMessageToAll(IMessage m)
        {
            // This sends the message to the recipient via the provider specified in the message
            try
            {
                Console.WriteLine("Sent message via SMTP Carrier, to everyone, as " + m.bodyType);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Something went wrong, message disintegrated..");
                return false;
            }
        }
    }
}
