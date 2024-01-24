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
            for (int i = 0; i < 100000; i++)
            {
                Bottle unit = this._buffer.Remove();
                Console.WriteLine($"Consumer #{this._consumerId} : Consumed a {unit.Type}...");
            }
            Console.WriteLine($"➤ Consumer #{this._consumerId} : Is done consuming...");
                
        }
    }
}
