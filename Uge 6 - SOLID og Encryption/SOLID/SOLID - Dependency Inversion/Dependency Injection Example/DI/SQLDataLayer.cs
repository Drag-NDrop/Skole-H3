using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    class SQLDataLayer : DataLayer
    {

        public void SaveCustomer(Customer c) {
            Console.WriteLine("Saving customer to ddatabase");


        }
    }
}
