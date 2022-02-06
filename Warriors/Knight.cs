using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Knight : Warrior
    {
        public override int Attack { get; protected set; } = 7;
    }
}
