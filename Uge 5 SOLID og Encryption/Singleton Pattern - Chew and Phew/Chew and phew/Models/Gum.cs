using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chew_and_phew.Models
{
    abstract internal class Gum
    {
        public string Flavor { get; set; }
        public string Color { get; set; }
        public int AmountInRefillPackage { get; set; }
    }
}
