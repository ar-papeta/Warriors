﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Lancer : Warrior
    {
        public Lancer()
        {
            Attack = 6;
        }

        public override int DealDamage(Warrior target, int damage)
        {
            var realDamage = target.TakeDamage(damage);
            if (!target.IsAlive)
            {
                if(target is Defender defender)
                {
                    realDamage = Attack - defender.Defense;
                }
                else
                {
                    realDamage = Attack;
                }
            }

            return realDamage;
        }
    }
}
