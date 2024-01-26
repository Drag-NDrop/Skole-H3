using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortering.Classes
{
    internal class SortingNode : ProsumerWithPulse
    {

        public SortingNode(List<Check_inConveyorBelt> InputBuffers, List<GateConveyorBelt> OutputBuffers) : base(InputBuffers, OutputBuffers)
        {
        }
    }
}
