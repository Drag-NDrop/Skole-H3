using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpJakob
{
    public enum MessageCarrier { Smtp, VMessage }
    public static class MessageHandler
    {
  
        public static void ProcessMessage(IMessage message, List<IProvider> providers, bool sendToAll)
        {
            // Does the message body need converting?
            if (message.bodyType == "HTML")
            {
                IConverter converter = new HTMLConverter();
                converter.Convert(message);
            }
            else if (message.bodyType == "JSON")
            {
               // Suppose we have a JsonConverter class
            }

            switch (message.MessageCarrier) // This is the message carrier. It measures the type of message carrier, and acts accordingly. 
            {
                case MessageCarrier.Smtp: { 
                   if (sendToAll == false) {
                        providers.FirstOrDefault(p => p.MessageCarrier == MessageCarrier.Smtp)?.SendMessage(message);
                   }
                   else
                   {
                      providers.FirstOrDefault(p => p.MessageCarrier == MessageCarrier.Smtp)?.sendMessageToAll(message);
                   }
                    break;
                }

                case MessageCarrier.VMessage:{ 
                    if (sendToAll == false)
                    {
                        providers.FirstOrDefault(p => p.MessageCarrier == MessageCarrier.VMessage)?.SendMessage(message);
                    }
                    else
                    {
                        providers.FirstOrDefault(p => p.MessageCarrier == MessageCarrier.VMessage)?.sendMessageToAll(message);
                    }
                }
                break;
            }
        }
    }
}
