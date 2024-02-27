
namespace Flaskeautomaten
{
    internal class ProducerWithPulse
    {
        int _producerId;
        int _rndRangeMin = 0;
        int _rndRangeMax = 10;
        Random _random;
        BufferQueueWithPulse _buffer;


        /// <summary>
        /// Create a producer with a randomized engine, that produces a unit of type Soda or Beer. Can be relatively easily extended to produce other types of units.
        /// </summary>
        /// <param name="producerId"></param>
        /// <param name="bufferQueue"></param>
        /// <param name="rndRangeminimum"></param>
        /// <param name="rndRangeMaximum"></param>
        /// <param name="rndGen"></param>
        public ProducerWithPulse(int producerId, BufferQueueWithPulse bufferQueue, int rndRangeminimum, int rndRangeMaximum, Random rndGen)
        {
            this._producerId      = producerId;
            this._buffer          = bufferQueue;
            this._rndRangeMin     = rndRangeminimum;
            this._rndRangeMax     = rndRangeMaximum;
            this._random = rndGen;
        }

        /// <summary>
        /// Randomized engine, that produces a unit of type Soda or Beer. Can be relatively easily extended to produce other types of units.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="Exception"></exception>
        internal void ProduceUnit(object callback) {
            while (Program.ShouldStop != true)
            {
                Bottle producedUnit = null;
                switch (this._random.Next(_rndRangeMin, _rndRangeMax))
                {
                    case 0:
                        {
                            producedUnit = new Soda(Program.IncProductionCount, "Soda", this._producerId);
                            Console.WriteLine($"Producer #{this._producerId} : produced a soda bottle...");
                            break;
                        }
                    case 1:
                        {
                            producedUnit = new Beer(Program.IncProductionCount,"Beer", this._producerId);
                            Console.WriteLine($"Producer #{this._producerId} : produced a beer bottle...");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Produced an invalid unit");
                            throw new Exception("Invalid unit produced");
                        }
                }
                this._buffer.Add(producedUnit);
            }
            Console.WriteLine($"➤ Producer #{this._producerId} is done producing...");
        }

        /// <summary>
        /// Add x to internal queue.
        /// Thread-safe operation.
        /// </summary>
        internal void StartProduce() {
            object callback = new object();
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProduceUnit));
        }
    }
}
