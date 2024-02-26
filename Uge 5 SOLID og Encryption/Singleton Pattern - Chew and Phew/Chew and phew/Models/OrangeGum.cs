using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chew_and_phew.Models
{
    internal class OrangeGum : Gum
    {
        public OrangeGum() : base()
        {
            this.Flavor = "Orange";
            this.Color = "Orange";
            this.AmountInRefillPackage = 8;
        }
    }
}
