using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Knight : IWarrior
    {
        public int Attack { get; private set; } = 7;
        public int Health { get; private set; } = 50;
        public void TakeDamage(IWarrior attacker)
        {
            Health -= attacker.Attack;
        }

        public void DealDamage(IWarrior target)
        {
            target.TakeDamage(this);
        }  
    }
}
