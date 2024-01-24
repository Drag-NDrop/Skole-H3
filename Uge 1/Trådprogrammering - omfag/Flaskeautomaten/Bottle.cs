using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flaskeautomaten
{
    internal abstract class Bottle
    {
        int _id;
        int _producerId;
        string type = "plain";

        public Bottle(int id, int producerId)
        {
            this.Id = id;
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
                return type;
            }

            internal set
            {
                type = value;
            }
        }
    }

    internal class Soda : Bottle
    {
        public Soda(int id, int producerId) : base(id, producerId)
        {
            this.Type = "Soda";
        }
    }

    internal class Beer : Bottle
    {
        public Beer(int id, int producerId) : base(id, producerId)
        {
            this.Type = "Beer";
        }
    }
}
