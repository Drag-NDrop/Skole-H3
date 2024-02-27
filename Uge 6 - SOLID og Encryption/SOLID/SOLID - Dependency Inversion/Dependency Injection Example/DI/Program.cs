using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager cm = new CustomerManager(new FileDataLayer());

            Customer c1 = new Customer(111,"Christian");
            Customer c2 = new Customer(666, "Mikkel");
            cm.Save(c1);
            cm.Save(c2);


            Console.ReadKey();
        }
    }
}
