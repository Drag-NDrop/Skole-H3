using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortering.Classes
{
    internal class Check_inConveyorBelt : BufferQueueWithPulse
    {
        string _destination;
        public Check_inConveyorBelt(int id, string destination, bool verbose, string type, int maxCapacity) : base(id, destination, verbose, type, maxCapacity)
        {
            _destination = destination;
        }
    }
}
