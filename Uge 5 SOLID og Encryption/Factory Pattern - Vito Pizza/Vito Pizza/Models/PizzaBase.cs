using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vito_Pizza.Models
{
    internal abstract class PizzaBase
    {
        private string _name;
        private decimal _price;
        private List<string> _ingredients;
        private List<string> _pizzaBase = new List<string>()
        {
            "Cheese,",
            "Tomato Sauce",
            "Dough"
        };

        public PizzaBase(string name, int price, List<string> ingredients)
        {
                this._name = name;
                this._price = price;
                this._ingredients = _pizzaBase;

            foreach (string ingredient in ingredients)
            {
                this._ingredients.Add(ingredient);
            }  
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public List<string> Ingredients
        {
            get { return _ingredients; }
            set { _ingredients = value; }
        }

        public void WritePizza()
        {
            Console.WriteLine("+++++++++++++++++++++++++++++++++++");
            Console.WriteLine($"{_name} - {_price} kr");
            foreach (string ingredient in _ingredients)
            {
                Console.WriteLine(ingredient);
            }
            Console.WriteLine("____________________________________");
        }
    }
}
