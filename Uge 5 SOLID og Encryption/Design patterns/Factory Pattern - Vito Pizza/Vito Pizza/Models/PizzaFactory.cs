using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Vito_Pizza.Models
{
    internal class PizzaFactory
    {
        Random random = new Random();
        public  PizzaFactory()
        {
            
        }

        public PizzaBase CreatePizzaFactory() // Factory pattern
        {
            int pizzaType = random.Next(1, 4);
            switch (pizzaType)
            {
                case 1:
                    return new Margarita("Margarita", 75, new List<string>() { "Oregano" });
                case 2:
                    return new Vesuvio("Vesuvio", 85, new List<string>() { "Eggs", "Basil" });
                case 3:
                    return new Anchovy("Anchovy", 95, new List<string>() { "Anchovy", "Red Onion", "Basil" });
                default:
                    return null;
            }
        }
    }
}
