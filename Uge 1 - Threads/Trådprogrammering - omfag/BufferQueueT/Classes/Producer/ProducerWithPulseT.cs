
using BufferQueueT.Classes.Buffer;
using System.ComponentModel;

namespace BufferQueueT.Classes
{
    internal class ProducerWithPulseT<T>
    {
        int _producerId;
        int _rndRangeMin;
        int _rndRangeMax;
        Random _random;
        BufferQueueT<T> _buffer;
        bool _shouldStop = false;
        bool _verbose = false;
        int _producedUnits = 0;
        string _unitType = typeof(T).Name;



        /// <summary>
        /// Create a producer with a randomized engine, that produces a unit of type Soda or Beer. Can be relatively easily extended to produce other types of units.
        /// </summary>
        /// <param name="producerId"></param>
        /// <param name="bufferQueue"></param>
        /// <param name="rndRangeminimum"></param>
        /// <param name="rndRangeMaximum"></param>
        /// <param name="rndGen"></param>
        /// <param name="shouldStop">A boolean reference that represents when the producer should run. While false, the producer runs.</param>
        public ProducerWithPulseT(int producerId, BufferQueueT<T> bufferQueue, int rndRangeminimum, int rndRangeMaximum, Random rndGen, bool shouldStop, bool verbose)
        {
            this._producerId  = producerId;
            this._buffer      = bufferQueue;
            this._rndRangeMin = rndRangeminimum;
            this._rndRangeMax = rndRangeMaximum;
            this._random      = rndGen;
            this._shouldStop  = shouldStop;
            this._verbose     = verbose;
        }

        public int ProducerId
        {
            get
            {
                return _producerId;
            }

            private set
            {
                _producerId = value;
            }
        }

        public int ProducedUnits
        {
            get
            {
                return _producedUnits;
            }

            private set
            {
                _producedUnits = _producedUnits++;
            }
        }

        /// <summary>
        /// Randomized engine, that produces a unit of type Soda or Beer. Can be relatively easily extended to produce other types of units.
        /// </summary>
        /// <param name="callback"></param>
        /// <exception cref="Exception"></exception>
        internal virtual void ProduceUnit(object callback) {
            while (this._shouldStop != true)
            {
                
                try {
                    throw new NotImplementedException();
                    /* Implement your own production method by overriding this one 
                        this._buffer.Add(producedUnit);
                        Console.WriteLine($"Producer #{this._producerId} : produced a {_unitType}");
                    */
                }
                catch(Exception e)
                {
                    Console.WriteLine("Error while producing a unit");
                    Console.WriteLine(e.InnerException);
                    Console.WriteLine(e.Message);
                    throw new Exception("Production error");
                }
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
