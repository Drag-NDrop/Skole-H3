using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    class FileDataLayer : DataLayer
    {
        public void SaveCustomer(Customer c)
        {
            Console.WriteLine("Saving to file");
        }
    }
}
