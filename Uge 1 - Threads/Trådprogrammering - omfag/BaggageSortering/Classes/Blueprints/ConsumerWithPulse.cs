using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortering.Classes.Blueprints
{
    internal abstract class ConsumerWithPulse
    {
        BufferQueueWithPulse _buffer;
        bool _verbose = false;
        int _amountToConsume = 0;
        int _consumerId;
        int _unitsConsumed = 0;

        /// <summary>
        /// Gets the amount of units consumed by this consumer.
        /// Sets the consumed units to +1, in a thread-safe manner.
        /// </summary>
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
            _consumerId = consumerId;
            _buffer = buffer;
            _amountToConsume = amountToConsume;
        }

        /// <summary>
        /// Starts a thread that consumes units from the internal buffer
        /// </summary>
        internal void StartConsuming()
        {
            object callback = new object();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Consume));
        }

        /// <summary>
        /// Remove a unit from the allocated internal buffer
        /// </summary>
        internal void Consume(object callback)
        {
            while (Program.ShouldStop != true)
            {
                Unit unit = _buffer.Remove();
                UnitsConsumed++;
                Console.WriteLine($"Consumer #{_consumerId} : Consumed a {unit.Type}...");
            }
            Console.WriteLine($"➤ Consumer #{_consumerId} : Is done consuming...");
        }
    }
}
