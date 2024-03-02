using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpTilLone.Abilities
{
    public interface ITeleport : IAbility
    {
        public void Teleport(int x, int y);
    }
}
