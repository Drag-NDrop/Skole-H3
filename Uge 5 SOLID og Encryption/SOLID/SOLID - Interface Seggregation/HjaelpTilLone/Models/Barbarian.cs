using HjaelpTilLone.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpTilLone.Models
{
    internal class Barbarian : IBarbarian
    {
        public string Name { get; set; } = "Barbarian";

        public void Die()
        {
            // Implement the Die method
            Console.WriteLine($"{Name} died!");
            LogEvent($"{Name} died");
        }

        public void Fight()
        {
            // Implement the Fight method
            Console.WriteLine($"{Name} fights!");
            LogEvent($"{Name} fights");
        }

        public void Heal()
        {
            // Implement the Heal method
            Console.WriteLine($"{Name} heals!");
            LogEvent($"{Name} healed");
        }

        public void LogEvent(string eventdescription)
        {
            // Implement the LogEvent method
            Console.WriteLine($"Log:: Wizard event: {eventdescription}");
        }

        public void Bash()
        {
            // Implement the Bash method
            Console.WriteLine($"{Name} bashes!");
            LogEvent($"{Name} bashed");
        }

        public void Cleave()
        {
            // Implement the Cleave method
            Console.WriteLine($"{Name} cleaves!");
            LogEvent($"{Name} cleaved");
        }

        public void Slash()
        {
            // Implement the Slash method
            Console.WriteLine($"{Name} slashes!");
            LogEvent($"{Name} slashed");
        }
    }
}
