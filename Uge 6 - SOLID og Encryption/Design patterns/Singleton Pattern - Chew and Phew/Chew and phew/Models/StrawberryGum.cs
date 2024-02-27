using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chew_and_phew.Models
{
    internal class StrawberryGum : Gum
    {
        public StrawberryGum() : base()
        {
            this.Flavor = "Strawberry";
            this.Color = "Red";
            this.AmountInRefillPackage = 10;
        }
    }
}
