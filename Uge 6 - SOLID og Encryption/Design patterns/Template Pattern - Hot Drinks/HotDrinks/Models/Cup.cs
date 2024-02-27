using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.Models
{
    internal abstract class Cup
    {

        public bool IsFull { get; private set; } = true;
        public string flavour { get; private set; } = "none";
        public List<string> ingredients = new List<string>();

        public void Fill(string flavour)
        {
            this.flavour = flavour;
            this.IsFull = false;
            Console.WriteLine($"Cup is filled with {flavour}.");
        }

        public void PrintContents() {
            Console.WriteLine("========================================");
            Console.WriteLine($"Cup is filled with {this.flavour}.");
            foreach (string ingredient in this.ingredients)
            {
                Console.WriteLine($"Cup also contains: {ingredient}.");
            }
            Console.WriteLine("========================================");
        }

        public abstract void Add(string ingredient);


    }
}
