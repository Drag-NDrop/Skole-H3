
namespace Producer_Consumer
{
    internal class ProducerWithPulse
    {
        int _producerId;
        BufferQueueWithPulse _buffer;
        int _rndRangeMin = 0;
        int _rndRangeMax = 10;
        Random _integerProducer;

        public ProducerWithPulse(int producerId, BufferQueueWithPulse bufferQueue, int rndRangeminimum, int rndRangeMaximum, Random rndGen)
        {
            this._producerId      = producerId;
            this._buffer          = bufferQueue;
            this._rndRangeMin     = rndRangeminimum;
            this._rndRangeMax     = rndRangeMaximum;
            this._integerProducer = rndGen;
        }

        internal void ProduceUnit(object callback) {
            int producedUnit = this._integerProducer.Next(this._rndRangeMin, this._rndRangeMax);
            for (int i = 0; i < 100000; i++)
            {
                this._buffer.Add(producedUnit);
                Console.WriteLine($"Producer #{this._producerId} : produced a unit...");
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
