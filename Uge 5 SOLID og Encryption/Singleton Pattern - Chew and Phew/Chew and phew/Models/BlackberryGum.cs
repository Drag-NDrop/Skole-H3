using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chew_and_phew.Models
{
    internal class BlackberryGum : Gum
    {
        public BlackberryGum() : base()
        {
            this.Flavor = "Blackberry";
            this.Color = "Black";
            this.AmountInRefillPackage = 11;
        }
    }
}
