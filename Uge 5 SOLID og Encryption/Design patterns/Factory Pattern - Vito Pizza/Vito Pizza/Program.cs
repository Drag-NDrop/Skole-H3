using Vito_Pizza.Models;

namespace Vito_Pizza
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PizzaFactory pizzaFactory = new PizzaFactory(); // Factory pattern
            for (int i = 0; i < 10; i++) {
                pizzaFactory.CreatePizzaFactory().WritePizza();
            }
        }
    }
}
