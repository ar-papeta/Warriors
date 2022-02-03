using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Warrior : IWarrior
    {
        /// <value>
        /// Warrior's current health points
        /// </value>
        public int Health { get; private set; } = 50;

        /// <value>
        /// Warrior's attack damage
        /// </value>
        public int Attack {  get; private set; } = 5;

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
