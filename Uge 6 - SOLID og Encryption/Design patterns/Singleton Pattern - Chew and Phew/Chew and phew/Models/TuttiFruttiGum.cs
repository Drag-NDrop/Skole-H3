using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chew_and_phew.Models
{
    internal class TuttiFruttiGum : Gum
    {
        public TuttiFruttiGum() : base()
        {
            this.Flavor = "Tutti Frutti";
            this.Color = "Rainbow";
            this.AmountInRefillPackage = 6;
        }
    }
}
