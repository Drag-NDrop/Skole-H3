namespace BirdsFlyingAround
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Birds flying around!");

            // Below i attempt to prove, that a bird can be a tucan. I downcast the tucan to a bird. Knowing i wont be allowed to access the flight code.
            Bird tucan = new Tucan(); // polymorphic
            tucan.Name = "Tucan";
            tucan.SetLocation(1, 2);
            tucan.Draw();

            // Below i demonstrate that a earthbird can be an earthbird. I downcast the earthbird to a bird.
            Bird kiwi = new EarthBird(); // polymorphic
            kiwi.Name = "Kiwi";
            kiwi.SetLocation(3, 4);
            kiwi.Draw();

            // Below i demonstrate that a Toucan can be an airbird. I downcast the tucan to an airbird. I am now allowed to access the altitude code.
            AirBird airBird = new Tucan(); // polymorphic
            airBird.Name = "AirBird";
            airBird.SetLocation(5, 6);
            airBird.SetAltitude(7); // This altitude is only available for AirBirds
            airBird.Draw();

            // Below i loop through a list of birds and calculate x and y for each bird.
            // Then i set the altitude for each airbird.
            // Then i call the draw method on each bird.
            Random rnd = new Random();
            List<Bird> birds = new List<Bird> { new Tucan(), new Kiwi()};
            foreach (Bird bird in birds)
            {
                bird.SetLocation(rnd.Next(0,10),rnd.Next(0,10));
                
                if (bird is AirBird)
                {
                    (bird as AirBird).SetAltitude(rnd.Next(0,10));
                }

                bird.Draw();
            }


        }
    }
}
