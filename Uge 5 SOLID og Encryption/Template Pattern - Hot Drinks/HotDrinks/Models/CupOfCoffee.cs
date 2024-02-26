using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.Models
{
    internal class CupOfCoffee : Cup
    {
        public void AddMilkAndSugar()
        {
            this.ingredients.Add("Milk");
            this.ingredients.Add("Sugar");
        }


        public override void Add(string ingredient)
        {
            this.ingredients.Add(ingredient);
        }
    }
}
