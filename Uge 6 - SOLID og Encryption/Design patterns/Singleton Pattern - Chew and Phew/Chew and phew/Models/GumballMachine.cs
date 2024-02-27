using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chew_and_phew.Models
{
    internal abstract class GumballMachine
    {
        List<Gum> gums = new List<Gum>();
        
        List<Gum> compatibleGums = new List<Gum>() {
            new AppleGum(),
            new BlackberryGum(),
            new BlueberryGum(),
            new OrangeGum(),
            new StrawberryGum(),
            new TuttiFruttiGum()
        };
        

        public virtual void Refill()
        {
            foreach(Gum gum in compatibleGums)
            {
                for (int i = 0; i <= gum.AmountInRefillPackage; i++) { 
                    this.gums.Add(gum);
                }
                Console.WriteLine($"Added: {gum.Flavor}");
            }
        }

        public virtual void ShuffeGums()
        {
            Random random = new Random();
            this.gums = this.gums.OrderBy(x => random.Next()).ToList();
            Console.WriteLine($"Shuffled Gums..");
        }

        public virtual string Dispense()
        {
            if (this.gums.Count > 0)
            {
                Gum gum = this.gums[0];
                this.gums.RemoveAt(0);
                return gum.Flavor;
            }
            else
            {
                return "No Gumballs";
            }
        }

        public virtual string GetGumCount()
        {
            return this.gums.Count.ToString();
        }

        public virtual string GetGumList()
        {
            string gumList = "";
            foreach (Gum gum in this.gums)
            {
                gumList += gum.Flavor + "\n";
            }
            return gumList;
        }

        public virtual void Empty()
        {
            this.gums.Clear();
        }

    }
}
