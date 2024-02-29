using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjaelpJakob
{
    public interface IConverter
    {
        public void Convert(IMessage message);
    }
}
