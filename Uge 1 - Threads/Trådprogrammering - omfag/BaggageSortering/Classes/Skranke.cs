using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortering.Classes
{
    internal class Skranke : BaggageSortering.Classes.ProducerWithPulse
    {
        string _name = "Skranke- ";
        string _destination = "Country";

        /// <summary>
        ///     Creates a baggage producer
        /// </summary>
        /// <param name="producerId">The ID of the producer</param>
        /// <param name="destination">The destination of the produced units</param>
        /// <param name="bufferQueue">The allocated output buffer</param>
        /// <param name="rndRangeminimum">the minimum range, if a randomizing function is needed</param>
        /// <param name="rndRangeMaximum">the maximum range, if a randomizing function is needed</param>
        /// <param name="rndGen">An object of type Random</param>
        public Skranke(int producerId, string destination, BufferQueueWithPulse bufferQueue, int rndRangeminimum, int rndRangeMaximum, Random rndGen) : base(producerId, destination, bufferQueue, rndRangeminimum, rndRangeMaximum, rndGen)
        {
            this._name += producerId;
            this._destination = destination;
        }

        internal override void ProduceUnit(object callback)
        {
            while (Program.ShouldStop != true)
            {
                Baggage baggage = new Baggage(this.IncProductionCount, "Baggage", this.ProducerId, this._destination);
                this.Buffer.Add(baggage);
                Console.WriteLine($"Skranke_{_destination} : Produced a unit destined for {_destination}...");
                //Thread.Sleep(this._random.Next(_rndRangeMin, _rndRangeMax));
            }
        }

    }
}
