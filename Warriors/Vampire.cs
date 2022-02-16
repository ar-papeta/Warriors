using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Vampire : Warrior
    {
      
        public int Vampirism { get; set; }

        public Vampire()
        {
            Attack = 4;
            MaxHealth = 40;
            Health = MaxHealth;
            Vampirism = 50;
        }

        public override int DealDamage(Warrior target, int damage)
        {
            var actualDamage = target.TakeDamage(damage);

            if (!target.IsAlive && target is Defender defender)
            {
                actualDamage = Attack - defender.Defense;
            }

            else if (target is not Defender)
            {
                actualDamage = Attack;
            }
            int vampirismHeal = actualDamage * Vampirism / 100;
            Health += vampirismHeal;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            return actualDamage;
        }
    }
}
