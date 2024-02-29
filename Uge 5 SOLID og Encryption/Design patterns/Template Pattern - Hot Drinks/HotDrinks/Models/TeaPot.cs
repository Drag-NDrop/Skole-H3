using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.Models
{
    internal class TeaPot : BeverageBrewer
    {
        public override void Brew()
        {
            Console.WriteLine("The Tea kettle is producing a nice hot tea...");
        }

        public override void Pour(Cup cup)
        {
            if (this.WaterBoiled)
            {
                Console.WriteLine("Pouring tea into cup...");
                cup.Fill("Tea");
            }
            else
            {
                Console.WriteLine("Water is not boiled yet!");
            }
        }
    
    }
}
