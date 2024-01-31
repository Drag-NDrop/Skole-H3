using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortering.Classes
{
    internal class Gate : ConsumerWithPulse
    {
        string _destination;
        public Gate(int consumerId, BufferQueueWithPulse buffer, int amountToConsume, string destination) : base(consumerId, buffer, amountToConsume)
        {
            this.Destination = destination;
        }

        public string Destination
        {
            get
            {
                return _destination;
            }

            private set
            {
                _destination = value;
            }
        }
    }
}
