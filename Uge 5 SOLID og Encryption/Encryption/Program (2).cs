using System;

namespace CryptographyInDotNet
{
    class Program
    {
        static void Main()
        {
            Random obj = new Random();

            
            Console.WriteLine("Random Number Demonstration in .NET 7");
            Console.WriteLine("---------------------------------");
            Console.WriteLine();

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine("Random Number " + i + " : " 
                    + Convert.ToBase64String(Random.GenerateRandomNumber(32))); //call Random method
       
            }

            
            
            Console.ReadLine();
        }
    }
}
/* Når du har nogle binære data, som du vil sende på tværs af et netværk, gør du det 
generelt ikke ved bare at streame bits og bytes over ledningen i et raw. 
Hvorfor? fordi nogle medier er lavet til streaming af tekst. Du ved aldrig - nogle protokoller
fortolker muligvis dine binære data som kontroltegn, eller dine binære data kan ødelægges,
fordi den underliggende protokol måske tror, at du har indtastet en speciel tegnkombination 
(som hvordan FTP oversætter linje slutninger).

Så for at omgå dette encodes binære data i tegn. Base64 er en af disse typer kodninger.
Hvorfor 64?
Fordi du generelt kan stole på, at de samme 64 tegn er til stede i mange tegnsæt, 
og du kan være med rimelighed sikker på, at dine data ender på den anden side af ledningen ukorrupt.
 */