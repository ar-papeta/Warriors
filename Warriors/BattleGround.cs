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
                    first.DealDamage(second, first.Attack);
                }
                else
                {
                    second.DealDamage(first, second.Attack);
                }
                round++;
            }

            return first.IsAlive;
        }

        public static bool Fight(Army firstArmy, Army secondArmy)
        {
            while (firstArmy.IsAlive && secondArmy.IsAlive)
            {
                var firstUnit = firstArmy.TakeFirstAlive();
                var secondUnit = secondArmy.TakeFirstAlive();

                int round = 1;
                while (firstUnit.IsAlive && secondUnit.IsAlive)
                {
                    if (round % 2 != 0)
                    {
                        firstArmy.Attack(secondArmy);
                    }
                    else
                    {
                        secondArmy.Attack(firstArmy);
                    }
                    round++;
                }
            }
            return firstArmy.IsAlive;
        }
    }
}
