using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpTilLone
{
    public interface IAbility
    {
        public string Name { get; set; }
        public void LogEvent(string eventdescription);
    }
}
