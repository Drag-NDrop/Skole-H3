using HjaelpTilLone.Abilities;
using HjaelpTilLone.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpTilLone.Models
{
    internal class Wizard : IWizard
    {
        public string Name { get; set; } = "Wizard";

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

        public void Teleport(int x, int y)
        {
            // Implement the Teleport method
            Console.WriteLine($"{Name} teleported!");
            LogEvent("Teleport");
        }

        public void ThrowFrostNova()
        {
            // Implement the ThrowFrostNova method
            Console.WriteLine($"{Name} cast frost nova!");
            LogEvent("Frost Nova");
        }

        public void ThrowMagicMissile()
        {
            // Implement the ThrowMagicMissile method
            Console.WriteLine($"{Name} cast magic missiles!");
            LogEvent("Magic Missile");
        }
    }
}
