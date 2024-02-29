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


        public bool SendMessage(Message m, bool isHTML)
        {
            // This sends the message to the recipient via the provider specified in the message
            throw new NotImplementedException();
        }

        public void sendMessageToAll(string[] to, Message m, bool isHTML)
        {
            // This sends the message to the recipient via the provider specified in the message
            throw new NotImplementedException();
        }
    }
}
