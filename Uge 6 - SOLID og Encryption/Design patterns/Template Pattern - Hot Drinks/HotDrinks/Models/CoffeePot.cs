using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.Models
{
    internal class CoffeePot : BeverageBrewer
    {

        public override void Brew()
        {
            Console.WriteLine("The Coffee pot is brewing a nice hot coffee...");
        }

        public override void Pour(Cup cup)
        {
            if (this.WaterBoiled)
            {
                Console.WriteLine("Pouring coffee into cup...");
                cup.Fill("Coffee");
            }
            else
            {
                Console.WriteLine("Water is not boiled yet!");
            }
        }
    }
}
