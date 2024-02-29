using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpJakob
{
    public class Message : IMessage
    {
        private string _to;
        private string _from;
        private string _body;
        private string _subject;
        private string _cc;

        public string To { get; set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Cc { get; set; }

        public MessageCarrier MessageCarrier { get; set; }

        public Message(MessageCarrier carrier, string to, string from, string body, string subject, string cc)
        {
            this._to = to;
            this._from = from;
            this._body = body;
            this._subject = subject;
            this._cc = cc;
            this.MessageCarrier = MessageCarrier;
        }

        public string ConvertBodyToHTML(string plainText)
        {
            return "" + plainText + "";
        }

    }
}
