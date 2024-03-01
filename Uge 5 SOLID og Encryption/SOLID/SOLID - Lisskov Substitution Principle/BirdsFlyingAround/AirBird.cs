using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdsFlyingAround
{
    internal class AirBird : Bird, IFly // Yes, i am having fun with naming my birdtypes by natural elements.
    {
        public override void Draw()
        {
            // Draw a bird that can fly
        }

        public override void SetLocation(double longitude, double latitude)
        {
            // Set the location of the bird that can fly
        }

        public virtual void SetAltitude(double altitude)
        {
            // Set the altitude of the bird that can fly
        }

    }
}
