using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaggageSortering.Classes
{
    internal class Baggage : Unit
    {
        string _barcode;
        string _destination;
        DateTime _recievedAt;

        public Baggage(int id, string unitType, int producerId, string destination) : base(id, unitType, producerId)
        {
            this.Type = unitType;
            this._destination = destination;
            this._barcode = $"P-{producerId}_I-{id}_{destination}";
            this.RecievedAt = DateTime.Now;
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

        public string Barcode
        {
            get
            {
                return _barcode;
            }

            private set
            {
                _barcode = value;
            }
        }

        public DateTime RecievedAt
        {
            get
            {
                return _recievedAt;
            }

            private set
            {
                _recievedAt = value;
            }
        }
    }
    
}
