using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public static class BattleGround
    {
        public static bool Fight(Warrior first, Warrior second)
        {
            if (first is null)
                throw new ArgumentNullException(nameof(first), "Warrior can not be null");
            if (second is null)
                throw new ArgumentNullException(nameof(second), "Warrior can not be null");

            int round = 1;
            while(first.IsAlive && second.IsAlive)
            {
                if (round % 2 != 0)
                {
                    first.DealDamage(second);
                }
                else
                {
                    second.DealDamage(first);
                }
                round++;
            }

            return first.IsAlive;
        }
    }
}
