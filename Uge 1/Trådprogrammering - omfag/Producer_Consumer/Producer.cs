
namespace Producer_Consumer
{
    internal class Producer
    {
        int _producerId;
        BufferQueue _buffer;
        public bool Started = false;
        int _rndRangeMin = 0;
        int _rndRangeMax = 10;
        Random _integerProducer;

        public Producer(int producerId, BufferQueue bufferQueue, int rndRangeminimum, int rndRangeMaximum, Random rndGen)
        {
            this._producerId      = producerId;
            this._buffer          = bufferQueue;
            this._rndRangeMin     = rndRangeminimum;
            this._rndRangeMax     = rndRangeMaximum;
            this._integerProducer = rndGen;
        }

        internal void ProduceUnit(object callback) {
            int producedUnit = this._integerProducer.Next(this._rndRangeMin, this._rndRangeMax);
            this._buffer.Add(producedUnit);
            Console.WriteLine($"Producer #{this._producerId} : produced a unit...");
        }

        /// <summary>
        /// Add x to internal queue.
        /// Thread-safe operation.
        /// </summary>
        internal void StartProduce() {
            this.Started = true;
            for (int i = 0; i < 1000; i++)
            {
                object callback = new object();
                ThreadPool.QueueUserWorkItem(new WaitCallback(this.ProduceUnit));
            }
            Console.WriteLine($"➤ Producer #{this._producerId} is done producing...");
            this.Started = false;
        }
    }
}
