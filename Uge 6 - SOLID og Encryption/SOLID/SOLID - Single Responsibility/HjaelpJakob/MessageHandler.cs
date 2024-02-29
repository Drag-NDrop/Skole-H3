using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpJakob
{
    public enum MessageCarrier { Smtp, VMessage }
    internal class MessageHandler
    {
        public MessageHandler(Message message, List<IProvider> providers, bool sendToAll)
        {
            switch(message.MessageCarrier)
            {
                case MessageCarrier.Smtp:
                    foreach (IProvider provider in providers)
                    {
                        if (provider.MessageCarrier == MessageCarrier.Smtp)
                        {
                            if(sendToAll == false) { 
                                provider.SendMessage(message, true);
                            }
                            else
                            {
                                provider.SendMessageToAll(message, true);
                            }
                        }
                    }
                    break;
                case MessageCarrier.VMessage:
                    foreach (var item in provider)
                    {
                        if (item.MessageCarrier == MessageCarrier.VMessage)
                        {
                            item.SendMessage(MessageCarrier.VMessage, message, true);
                        }
                    }
                    break;
            }
        }

    }
}
