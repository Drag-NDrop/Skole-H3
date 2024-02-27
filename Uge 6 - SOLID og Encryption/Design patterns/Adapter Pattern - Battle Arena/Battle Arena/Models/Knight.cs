using Battle_Arena.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Arena.Models
{
    internal class Knight : IFighter
    {
        Random rnd = new Random();
        private bool _hasEscaped = false;
        
        private int _fearFactor = 15; // percentage % chance of escaping
        public string Name { get; set; }
        public int DefenseLeft { get; set; } = 30;

        public int Attack()
        {
            return rnd.Next(1,7);
        }

        public void Defend(int attack)
        {
            this.DefenseLeft -= attack;

            if (rnd.Next(1,101) < _fearFactor)
            {
                this._hasEscaped = true;
            }
        }

        public bool HasEscaped()
        {
            if (_hasEscaped) { 
                Console.WriteLine($"{this.Name} ran away in fear...");
            }
            return _hasEscaped;
        }
        public Knight(string name)
        {
            this.Name = name;
        }
    }
}
