using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpJakob
{
    internal class HTMLConverter : IConverter
    {
        public void Convert(IMessage message)
        {
            switch (message.bodyType)
            {
                case "HTML":
                    message.Body = ConvertBodyToHTML(message.Body);
                    break;
                default:
                    break;
            }
        }

        public string ConvertBodyToHTML(string message)
        {
            return "" + message + "";
        }
    }
}
