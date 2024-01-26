using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    internal class ConsumerWithPulse
    {
        BufferQueueWithPulse _buffer;
        bool _verbose = false;
        int _amountToConsume = 0;
        int _consumerId;
        int _unitsConsumed = 0;

        public int UnitsConsumed
        {
            get
            {
                return _unitsConsumed;
            }

            set
            {
                Interlocked.Increment(ref _unitsConsumed);
            }
        }

        public ConsumerWithPulse(int consumerId, BufferQueueWithPulse buffer, int amountToConsume)
        {
            this._consumerId = consumerId;
            this._buffer = buffer;
            this._amountToConsume = amountToConsume;
        }

        internal void StartConsuming() {
            object callback = new object();
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Consume));
        }

        /// <summary>
        /// Remove 1 from internal queue
        /// </summary>
        internal void Consume(object callback)
        {
            while(Program.ShouldStop != true)
            {
                Bottle unit = this._buffer.Remove();
                this.UnitsConsumed++;
                Console.WriteLine($"Consumer #{this._consumerId} : Consumed a {unit.Type}...");
            }
            Console.WriteLine($"➤ Consumer #{this._consumerId} : Is done consuming...");
        }
    }
}
