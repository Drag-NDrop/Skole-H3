using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferQueueT.Classes.UnitTypes
{
    internal abstract class Bottle : Unit
    {
        public Bottle(int id, string name, int producerId) : base(id, name, producerId)
        {
            Type = name;
        }
    }

    internal class Soda : Bottle
    {
        public Soda(int id, string name, int producerId) : base(id, name, producerId)
        {
            Type = name;
        }
    }

    internal class Beer : Bottle
    {
        public Beer(int id, string name, int producerId) : base(id, name, producerId)
        {
            Type = name;
        }
    }
}
