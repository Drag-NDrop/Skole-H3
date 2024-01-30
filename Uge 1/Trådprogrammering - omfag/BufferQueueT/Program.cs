using BufferQueueT.Classes.Buffer;
using BufferQueueT.Classes.UnitTypes;

namespace BufferQueueT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            /* Integer tests
                BufferQueueT<int> bufferQueue = new BufferQueueT<int>(1, "Buffer 1", 2, true , "Buffer<Integers>");
                bufferQueue.Add(1);
                bufferQueue.Add(2);
                bufferQueue.Add(3);
            */

            /* String tests
                BufferQueueT<string> bufferQueue = new BufferQueueT<string>(1, "Buffer 1", 2, true , "Buffer<String>");
                    bufferQueue.Add("Et");
                    bufferQueue.Add("To");
                    bufferQueue.Add("Tre");
            */

            /* Baggage tests
                BufferQueueT<Baggage> bufferQueue = new BufferQueueT<Baggage>(1, "Buffer 1", 2, true, "Buffer<Baggage>");
                    bufferQueue.Add(new Baggage(1, "Baggage", 1, "Oslo"));
                    bufferQueue.Add(new Baggage(2, "Baggage", 1, "Amsterdam"));
                    bufferQueue.Add(new Baggage(3, "Baggage", 1, "London"));
                    bufferQueue.Add(new Baggage(4, "Baggage", 1, "Paris"));
            */

            ///* Bottle Tests
                BufferQueueT<Bottle> bufferQueue = new BufferQueueT<Bottle>(1, "Buffer 1", 4, true, "Buffer<Bottle>");
                    bufferQueue.Add(new Soda(1, "Soda", 1));
                    bufferQueue.Add(new Beer(2, "Beer", 1));
                    bufferQueue.Add(new Soda(3, "Soda", 1));
                    bufferQueue.Add(new Beer(4, "Beer", 1));
            //*/
        }
    }
}
