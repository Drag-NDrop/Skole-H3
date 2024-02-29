using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Chew_and_phew.Models
{
    internal class BlueberryGum : Gum
    {
        public BlueberryGum() : base()
        {
                this.Flavor = "Blueberry";
                this.Color = "Blue";
                this.AmountInRefillPackage = 14;
        }
    }
}
