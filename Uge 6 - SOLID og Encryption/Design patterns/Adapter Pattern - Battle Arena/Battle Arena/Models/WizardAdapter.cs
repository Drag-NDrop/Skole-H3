using Battle_Arena.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battle_Arena.Models;

namespace Battle_Arena.Models
{
    

    internal class WizardAdapter : IFighter // Adapter pattern
    {
        public int DefenseLeft { get; set;}

        public string Name { get; set; }

        Wizard _wizard;
       
        public WizardAdapter(string name, Wizard wizard)
        {
            this.Name = name;
            this._wizard = wizard;
        }

        public int Attack()
        {
           return  this._wizard.CastFireballSpell();
        }

        public void Defend(int attack)
        {
            this._wizard.Shield(attack);
        }

        public bool HasEscaped()
        {
            Console.WriteLine($"{Name} prepares his escape and opens a portal!");
            return this._wizard.IsPortalOpened();
        }
    }
}
