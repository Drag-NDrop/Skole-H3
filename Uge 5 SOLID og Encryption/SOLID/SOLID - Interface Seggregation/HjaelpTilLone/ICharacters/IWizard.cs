using HjaelpTilLone.Abilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpTilLone.Characters
{
    public interface IWizard : ICharacter, ITeleport, IThrowMagicMissile, IThrowFrostNova
    {
    }
}
