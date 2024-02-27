using Chew_and_phew.Models;

namespace Chew_and_phew
{
    internal class Program
    {
 

        
        static void Main(string[] args)
        {

            
            Console.WriteLine("Welcome to the Gumball Bonanza!!");

            

            Console.WriteLine("Amount of gums: " + ChewNPhew_v2.Instance.GetGumCount());

            ChewNPhew_v2.Instance.Refill();
            Console.WriteLine("Amount of gums: " + ChewNPhew_v2.Instance.GetGumCount());

            ChewNPhew_v2.Instance.ShuffeGums();

            Console.WriteLine(ChewNPhew_v2.Instance.GetGumList());


        }
    }
}
