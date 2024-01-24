namespace Flaskeautomaten
{
    internal class Program
    {
        internal static Random random = new Random();
        private static int productionCount = 0;
        private static int _batchSize = 100000;

        internal static bool ShouldStop = false;
        public static int BatchSize
        {
            get
            {
                return _batchSize;
            }

            private set
            {
                _batchSize = value;
            }
        }

        internal static int IncProductionCount
        {
            get
            {
                Interlocked.Increment(ref productionCount);
                return productionCount;
            }
        }

        internal static int ProductionCount
        {
            get
            {
                return productionCount;
            }
        }



        static void Main(string[] args)
        {
            // InputSlot buffers
            BufferQueueWithPulse inputSlot = new BufferQueueWithPulse(1, true); // Id: 1, Verbose: true
            
                // Get it ready for the prosumer
                List<BufferQueueWithPulse> InputBuffers = new List<BufferQueueWithPulse>
                {
                    inputSlot
                };


            // Producers
            ProducerWithPulse bottleProducer1 = new ProducerWithPulse(1, inputSlot, 0, 2, random); // Id : 1, Buffer: InputSlot, Min: 0, Max: 10, Random: random

                

            // Prosumer buffers

                // Sorting buffers
                BufferQueueWithPulse beerBuffer = new BufferQueueWithPulse(1, true, "Beer"); // Id: 1, Verbose: true
                BufferQueueWithPulse sodaBuffer = new BufferQueueWithPulse(2, true, "Soda"); // Id: 1, Verbose: true
                
                    // Get it ready for the prosumer
                    List<BufferQueueWithPulse> sortingBuffers = new List<BufferQueueWithPulse> {
                        beerBuffer,
                        sodaBuffer
                    };

                        
            // Prosumer (Splitter)
            ProsumerWithPulse prosumer1 = new ProsumerWithPulse(InputBuffers, sortingBuffers);

            ConsumerWithPulse beerConsumer1 = new ConsumerWithPulse(1, beerBuffer, 1); // Id : 1, Buffer: BeerBuffer, Min: 0, Max: 10, Random: random
            ConsumerWithPulse sodaConsumer2 = new ConsumerWithPulse(2, sodaBuffer, 1); // Id : 1, Buffer: BeerBuffer, Min: 0, Max: 10, Random: random

            bottleProducer1.StartProduce();
            prosumer1.StartSorting();

            beerConsumer1.StartConsuming();
            sodaConsumer2.StartConsuming();

            Console.ReadKey();
        }
    }
}
