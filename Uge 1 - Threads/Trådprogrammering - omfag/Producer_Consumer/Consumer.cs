using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producer_Consumer
{
    internal class Consumer
    {
        BufferQueue _buffer;
        bool _started = false;
        bool _verbose = false;
        int _amountToConsume = 0;
        int _consumerId;
            

        public Consumer(int consumerId, BufferQueue buffer, int amountToConsume)
        {
            this._consumerId = consumerId;
            this._buffer = buffer;
            this._amountToConsume = amountToConsume;
        }

        internal void StartConsuming() {
            object callback = new object();
            ThreadPool.QueueUserWorkItem(new WaitCallback(this.Consume));
            this._started = true;
        }

        /// <summary>
        /// Remove 1 from internal queue
        /// </summary>
        internal void Consume(object callback)
        {
            for (int i = 0; i < 100000; i++)
            {
                this._buffer.Remove(1);
                Console.WriteLine($"Consumer #{this._consumerId} : Consumed a unit...");
            }
            Console.WriteLine($"➤ Consumer #{this._consumerId} : Is done consuming...");
            this._started = false;
                
        }
    }
}
