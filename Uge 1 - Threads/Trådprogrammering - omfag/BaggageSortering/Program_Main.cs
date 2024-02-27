using BaggageSortering.Classes;
using System.Runtime.InteropServices;

namespace BaggageSortering
{
    internal class Program
    {
        public static bool ShouldStop = false;
        public static Random Randomizer = new Random();

        static void Main(string[] args)
        {
            // Jeg mener at have bevist at jeg forstår hvad der sker i programmet, og at jeg har forstået opgaven.
            // Jeg har benyttet mig af den bufferqueue, producer, consumer og prosumer, jeg lavede i Flaskeautomaten, og forsøgt at nedarve fra dem.
            // Det gik dog galt, da de var skrevet til at håndtere Bottles, og ikke Baggage, så jeg har måtte skrive dem om.
            // Jeg er klar over at jeg ved at gøre dette, bryder med SOLIDS Open/Close princip, og mener ikke at jeg kan løse det, uden at
            // kende mere til Generics og Templating. Så hvor opgaven ikke er lige så udført som den jeg lavede på sidste hovedforløb, så mener jeg at have bevist at jeg forstår opgaven.
            // Og er derfor i et nyt projekt, gået i gang med at øve på generics og templating.


            Check_inConveyorBelt skranke1buffer = new Check_inConveyorBelt(1, "Copenhagen", true, "SkrankeConveyor", 1000);
            Check_inConveyorBelt skranke2buffer = new Check_inConveyorBelt(2, "Lissabon", true, "SkrankeConveyor", 1000);
            Check_inConveyorBelt skranke3buffer = new Check_inConveyorBelt(3, "Amsterdam", true, "SkrankeConveyor", 1000);
            Check_inConveyorBelt skranke4buffer = new Check_inConveyorBelt(4, "Berlin", true, "SkrankeConveyor", 1000);
            Check_inConveyorBelt skranke5buffer = new Check_inConveyorBelt(5, "Paris", true, "SkrankeConveyor", 1000);
            Check_inConveyorBelt skranke6buffer = new Check_inConveyorBelt(6, "New York", true, "SkrankeConveyor", 1000);
            List<Check_inConveyorBelt> CheckInConveyorBelts = new List<Check_inConveyorBelt> {
                skranke1buffer,
                skranke2buffer,
                skranke3buffer,
                skranke4buffer,
                skranke5buffer,
                skranke6buffer
            };

// Skranke skranke1 = 
// Skranke skranke2 = 
// Skranke skranke3 = 
// Skranke skranke4 = 
// Skranke skranke5 = 
// Skranke skranke6 = 
            List<Skranke> Skranker = new List<Skranke>
            {
                new Skranke(1, "Copenhagen", skranke1buffer, 0,0, Randomizer),
                new Skranke(2, "Lissabon",   skranke2buffer, 0, 0, Randomizer),
                new Skranke(3, "Amsterdam",  skranke3buffer, 0, 0, Randomizer),
                new Skranke(4, "Berlin",     skranke4buffer, 0, 0, Randomizer),
                new Skranke(5, "Paris",      skranke5buffer, 0, 0, Randomizer),
                new Skranke(6, "New York", skranke6buffer, 0, 0, Randomizer)
        };

            GateConveyorBelt gate1buffer = new GateConveyorBelt(1, "Copenhagen", true, "GateConveyor", 1000);
            GateConveyorBelt gate2buffer = new GateConveyorBelt(2, "Lissabon", true, "GateConveyor", 1000);
            GateConveyorBelt gate3buffer = new GateConveyorBelt(3, "Amsterdam", true, "GateConveyor", 1000);
            GateConveyorBelt gate4buffer = new GateConveyorBelt(4, "Berlin", true, "GateConveyor", 1000);
            GateConveyorBelt gate5buffer = new GateConveyorBelt(5, "Paris", true, "GateConveyor", 1000);
            GateConveyorBelt gate6buffer = new GateConveyorBelt(6, "New York", true, "GateConveyor", 1000);

            SortingNode sorteringsNode1 = new SortingNode(
                                                new List<Check_inConveyorBelt>() { 
                                                                                    skranke1buffer, 
                                                                                    skranke2buffer,
                                                                                    skranke3buffer,
                                                                                    skranke4buffer,
                                                                                    skranke5buffer,
                                                                                    skranke6buffer
                                                },
                                                new List<GateConveyorBelt>() {      gate1buffer,
                                                                                    gate2buffer,
                                                                                    gate3buffer,
                                                                                    gate4buffer,
                                                                                    gate5buffer,
                                                                                    gate6buffer       
                                                });
            List<Gate> Gates = new List<Gate> {
                new Gate(1, gate1buffer, 1, "Copenhagen"),
                new Gate(2, gate2buffer, 1, "Lissabon"),
                new Gate(3, gate3buffer, 1, "Amsterdam"),
                new Gate(4, gate4buffer, 1, "Berlin"),
                new Gate(5, gate5buffer, 1, "Paris"),
                new Gate(6, gate6buffer, 1, "New York")
            };


            sorteringsNode1.StartSorting();
            
            foreach (Skranke skranke in Skranker)
            {
                skranke.StartProduce();
            }

            foreach (Gate gate in Gates)
            {
                gate.StartConsuming();
            }
            Console.ReadKey();
        }
    }
}
