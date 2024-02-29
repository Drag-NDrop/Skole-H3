using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.Models
{
    internal class CupOfTea : Cup
    {
        public void AddLemon()
        {
            this.ingredients.Add("Lemon");
        }

        public override void Add(string ingredient)
        {
            this.ingredients.Add(ingredient);
        }
    }
}
