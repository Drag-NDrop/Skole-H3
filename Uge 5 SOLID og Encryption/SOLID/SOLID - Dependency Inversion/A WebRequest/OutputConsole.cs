﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_WebRequest
{
    internal class OutputConsole : IOutput
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
        }
    }
}
