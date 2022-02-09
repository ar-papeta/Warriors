using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Vampire : Warrior
    {
        private readonly int _startHp;

        public int Vampirism { get; set; }

        public Vampire()
        {
            Attack = 4;
            Health = 40;
            _startHp = Health;
            Vampirism = 50;
        }

        public override int DealDamage(Warrior target, int damage)
        {
            var actualDamage = target.TakeDamage(damage);
            int vampirismHeal = actualDamage * Vampirism / 100;
            Health += vampirismHeal;
            if (Health > _startHp)
            {
                Health = _startHp;
            }

            return actualDamage;
        }
    }
}
