using Battle_Arena.Interfaces;
using Battle_Arena.Models;
namespace Battle_Arena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Battle Arena!!");
        /*
            Knight f1 = new Knight("Sir Lancelot");
            Knight f2 = new Knight("Sir Galahad");
          */
        
            Knight f1 = new Knight("Sir Lancelot");
            Wizard w = new Wizard("Voldemort");
            WizardAdapter f2 = new WizardAdapter("Voldemort", w); // Adapter pattern

            IFighter winner = Fight(f1, f2);
            Console.WriteLine($"The winner of the tournament was: {winner.Name}");

        }

        public static IFighter Fight(IFighter f1, IFighter f2)
        {

            while ((!f1.HasEscaped() && !f2.HasEscaped()) && ((f1.DefenseLeft > 0) && (f2.DefenseLeft > 0)))
            {
                // Første fighter henter attack
                int attack = f1.Attack();
                // Anden fighter skal forsvare sig
                f2.Defend(attack);
                // Anden fighter henter attack
                attack = f2.Attack();
                // Første fighter skal forsvare sig
                f1.Defend(attack);
            }

            IFighter winner = null;

            // kampen er afsluttet
            if ((f1.DefenseLeft > 0) && (!f1.HasEscaped()))
                winner = f1;

            if ((f2.DefenseLeft > 0) && (!f2.HasEscaped()))
                winner = f2;

            // Hvis der returneres null, så har kampen været jævnbyrdig
            return winner;

        }
    }
}
