using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Warrior
    {
        /// <value>
        /// Warrior's base health points getter
        /// </value>
        public virtual int Health { get; set; } = 50;

        /// <value>
        /// Warrior's base attack damage getter
        /// </value>
        public virtual int Attack { get; set; } = 5;

        /// <value>
        /// If warrior's HP is greater than 0 return true otherwise false
        /// </value>
        public bool IsAlive => Health > 0;

        public virtual void TakeDamage(Warrior attacker)
        {
            Health -= attacker.Attack;
        }

        public virtual void DealDamage(Warrior target)
        {
            target.TakeDamage(this);
        }
    }
}
