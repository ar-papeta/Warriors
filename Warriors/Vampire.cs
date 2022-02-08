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

        public override void DealDamage(Warrior target)
        {
            var actualDamage = target.TakeDamage(this);
            int vampirismHeal = actualDamage * Vampirism / 100;
            Health += vampirismHeal;
            if (Health > _startHp)
            {
                Health = _startHp;
            }    
        }
    }
}
