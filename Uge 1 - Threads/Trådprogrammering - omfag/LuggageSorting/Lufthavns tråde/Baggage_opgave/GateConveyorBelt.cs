using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortering.Classes
{
    internal class GateConveyorBelt : BufferQueueWithPulse
    {
        string _destination;
        public GateConveyorBelt(int id, string destination, bool verbose, string type, int maxCapacity) : base(id, destination, verbose, type, maxCapacity)
        {
            this.Destination = destination;
        }

        public string Destination
        {
            get
            {
                return _destination;
            }

            set
            {
                _destination = value;
            }
        }
    }
}
