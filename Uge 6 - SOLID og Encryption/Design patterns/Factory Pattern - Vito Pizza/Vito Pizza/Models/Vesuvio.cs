using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vito_Pizza.Models
{
    internal class Vesuvio : PizzaBase
    {
        public Vesuvio(string name, int price, List<string> ingredients) : base(name, price, ingredients) 
        { 
        }
    }
    
}
