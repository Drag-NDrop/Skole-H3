using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    public abstract class Bird
    {
        public virtual string Name { get; set; }
        public abstract void SetLocation(double longitude, double latitude);
        public abstract void Draw();
    }
}
