using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpJakob
{
    internal class VMessageProvider : IProvider
    {
        public string ProviderName { get; set; }
        public MessageCarrier MessageCarrier { get; set; }


        public bool SendMessage(Message m, bool isHTML)
        {
            //herinde sendes der en email ud til modtageren

            if (m.MessageCarrier == MessageCarrier.VMessage)
            {
                if (isHTML)
                    m.ConvertBodyToHTML(m.Body);
                //her implementeres alt koden til at sende via VMessage
                bool sendSuccess = true;
                return sendSuccess;

            }
            else
            {
                return false;
            }
        }
  
        public bool sendMessageToAll(string[] to, Message m, bool isHTML)
        {
            if (isHTML)
            {
                m.ConvertBodyToHTML(m.Body);
            }
            //her implementeres alt koden til at sende til alle i "to"-arrayet, via VMessage
            bool sendSuccess = true;
            return sendSuccess;
        }
    }
}
