using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Defender : Warrior
    {
        public override int  Defense { get; protected set; } = 2;

        public override int Health { get; protected set; } = 60;

        public override int Attack { get; protected set; } = 3;
    }
}
