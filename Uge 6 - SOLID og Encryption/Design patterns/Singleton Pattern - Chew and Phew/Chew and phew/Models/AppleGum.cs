using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chew_and_phew.Models
{
    internal class AppleGum : Gum // AppleGum class inherits from Gum class
    {
        public AppleGum() : base() // Constructor
        {
            this.Flavor = "Apple"; // Flavor property
            this.Color = "Green"; // Color property
            this.AmountInRefillPackage = 7; // AmountInRefillPackage property
        }
    }
}
