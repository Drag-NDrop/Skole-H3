using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    class Customer
    {
        public int CustomerNo { get; set; }
        public string Name { get; set; }

        public Customer(int cn, string name)
        {
            CustomerNo = cn;
            Name = name;
        }
    }
}
