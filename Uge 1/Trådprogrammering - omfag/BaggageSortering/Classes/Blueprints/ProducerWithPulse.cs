namespace BaggageSortering.Classes.Blueprints
{
    internal abstract class ProducerWithPulse
    {
        int _producerId;
        int _rndRangeMin = 0;
        int _rndRangeMax = 10;
        int _unitsProduced = 0;
        string _serialNumber = "";
        Random _random;
        BufferQueueWithPulse _buffer;

        private int IncProductionCount
        {
            get
            {
                int _unitsProduced = Interlocked.Increment(ref this._unitsProduced);

                return _unitsProduced;
            }
        }
        internal int ProductionCount
        {
            get
            {
                return _unitsProduced;
            }
            private set
            {
                _serialNumber = $"P{_producerId}-{_unitsProduced}";
                _unitsProduced = value;
            }
        }
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
            _producerId = producerId;
            _buffer = bufferQueue;
            _rndRangeMin = rndRangeminimum;
            _rndRangeMax = rndRangeMaximum;
            _random = rndGen;
        }

        /// <summary>
        /// Randomized engine, that produces a random unit of the types defined. 
        /// Can be relatively easily extended to produce other types of units.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="Exception"></exception>
        internal virtual void ProduceUnit(object callback)
        {
            /* Remember to adjust the prosumer and consumer classes to much the types of units produced.
                while (Program.ShouldStop != true)
                {
                    Unit producedUnit = null;
                    switch (_random.Next(_rndRangeMin, _rndRangeMax))
                    {
                        case 0:
                            {
                                producedUnit = new Soda(this.IncProductionCount, "Soda", _producerId);
                                Console.WriteLine($"Producer #{_producerId} : produced a soda bottle...");
                                break;
                            }
                        case 1:
                            {
                                producedUnit = new Beer(this.IncProductionCount, "Beer", _producerId);
                                Console.WriteLine($"Producer #{_producerId} : produced a beer bottle...");
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Produced an invalid unit");
                                throw new Exception("Invalid unit produced");
                            }
                    }
                    _buffer.Add(producedUnit);
                }
                Console.WriteLine($"➤ Producer #{_producerId} is done producing...");
            */
        }

        /// <summary>
        /// Add a unit to its allocated bufferqueue.
        /// Thread-safe operation.
        /// </summary>
        internal void StartProduce()
        {
            object callback = new object();
            ThreadPool.QueueUserWorkItem(new WaitCallback(ProduceUnit));
        }
    }
}
