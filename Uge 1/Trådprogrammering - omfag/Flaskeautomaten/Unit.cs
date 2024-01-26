using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    internal abstract class Unit
    {
        int _id;
        int _producerId;
        string _type = "unit";

        public Unit(int id, string unitType, int producerId)
        {
            this.Id = id;
            this._type = unitType;
            this.ProducerId = producerId;
        }

        public int Id
        {
            get
            {
                return _id;
            }

            private set
            {
                _id = value;
            }
        }

        public int ProducerId
        {
            get
            {
                return _producerId;
            }

            private set
            {
                _producerId = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            internal set
            {
                _type = value;
            }
        }


    }
}
