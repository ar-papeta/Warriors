using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Warlord : Defender
    {
        private Army _army;
        public Warlord()
        {
            Attack = 4;
            MaxHealth = 100;
            Health = MaxHealth;
        }
    }
}
