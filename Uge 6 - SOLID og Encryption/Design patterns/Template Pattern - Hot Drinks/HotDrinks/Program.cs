using HotDrinks.Models;

namespace HotDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<Cup> cups = new List<Cup>()
            {
                new CupOfCoffee(),
                new CupOfCoffee(),
                new CupOfCoffee(),
                new CupOfCoffee(),
                new CupOfCoffee(),
                new CupOfTea()
            };

            List<BeverageBrewer> beverageBrewers = new List<BeverageBrewer>() {
                new CoffeePot(),
                new TeaPot()
            };

            foreach (BeverageBrewer pot in beverageBrewers)
            {
                switch (pot)
                {
                    // If it's a CoffeePot, insert coffee, boil, and brew.
                    // If it's a TeaPot, insert tea, boil, and brew.
                    // Finally, pour the contents of the pots into the cups.

                    case CoffeePot:
                        pot.InsertIngredient("Coffee");
                        pot.Boil();
                        pot.Brew();
                        foreach (CupOfCoffee cup in cups.Where(cup => cup is CupOfCoffee).ToList())
                        {
                            pot.Pour(cup);
                            cup.AddMilkAndSugar();
                        }
                        break;
                    case TeaPot:
                        pot.InsertIngredient("Tea");
                        pot.Boil();
                        pot.Brew();
                        foreach (CupOfTea cup in cups.Where(cup => cup is CupOfTea).ToList())
                        {
                            pot.Pour(cup);
                            cup.AddLemon();
                        }
                        break;

                    default:
                        break;
                }
            }

            // Print the contents of the cups
            foreach (Cup cup in cups)
            {
                cup.PrintContents();
            }

        }
    }
}
