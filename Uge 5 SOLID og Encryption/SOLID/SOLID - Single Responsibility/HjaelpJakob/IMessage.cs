﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpJakob
{
    public interface IMessage
    {
        public MessageCarrier MessageCarrier { get; set; }
        public string To { get;set; }
        public string From { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public string[]? Cc { get; set; }
        public string bodyType { get; set; }
    }
}
