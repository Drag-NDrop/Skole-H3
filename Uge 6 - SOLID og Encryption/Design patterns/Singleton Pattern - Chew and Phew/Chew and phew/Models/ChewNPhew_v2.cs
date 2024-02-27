using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Chew_and_phew;

namespace Chew_and_phew.Models
{
    internal class ChewNPhew_v2 : GumballMachine
    {
        private static ChewNPhew_v2 instance; // Singleton pattern
        public static ChewNPhew_v2 Instance // Singleton pattern
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChewNPhew_v2();
                }
                return instance;
            }
        }
        private ChewNPhew_v2() {

        }
    }
}
