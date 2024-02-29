using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    class CustomerManager
    {


        DataLayer dl;
        public CustomerManager(DataLayer dal)
        {
            this.dl = dal;
        }

        public void Save(Customer c) {
            dl.SaveCustomer(c);

        }
    }
}
