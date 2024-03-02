using HjaelpTilLone.Characters;
using HjaelpTilLone.Models;

namespace HjaelpTilLone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hjælp Lone!");

            IKnight     knight = new Knight();
            IBarbarian  barbarian = new Barbarian();
            IWitch      witch = new Witch();
            IWizard     wizard = new Wizard();

            ICharacter character = new Wizard(); // Polymorphism test

            character.Fight();
            character.Die();
            character.Heal();

            
            knight.Fight();
            knight.Die();
            knight.Heal();
            knight.Bash();
            knight.Slash();
            knight.Cleave();
            knight.RaiseShield();
            knight.ShieldGlare();
            
            barbarian.Fight();
            barbarian.Die();
            barbarian.Heal();
            barbarian.Bash();
            barbarian.Slash();
            barbarian.Cleave();

            witch.Fight();
            witch.Die();
            witch.Heal();
            witch.Teleport(1,6);
            witch.RaiseShield();
            witch.ShieldGlare();

            wizard.Fight();
            wizard.Die();
            wizard.Heal();
            wizard.Teleport(1,6);
            wizard.ThrowFrostNova();
            wizard.ThrowMagicMissile();

        
        }
    }
}
