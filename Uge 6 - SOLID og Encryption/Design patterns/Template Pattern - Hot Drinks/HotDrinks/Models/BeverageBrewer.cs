using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotDrinks.Models
{
    internal abstract class BeverageBrewer
    {
        private bool _waterBoiled = false;
        private string _ingredient;

        public bool WaterBoiled
        {
            get
            {
                return _waterBoiled;
            }

            private set
            {
                _waterBoiled = value;
            }
        }

        public void Boil()
        {
            Console.WriteLine("Water is boiling...");
            this.WaterBoiled = true;
        }
        
        public void InsertIngredient(string ingredient) {
            this._ingredient = ingredient;
        }

        public abstract void Brew();

        public abstract void Pour(Cup cup);
        
    }
}
