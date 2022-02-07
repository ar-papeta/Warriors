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
        /// Warrior's base health points 
        /// </value>
        public int Health { get; protected set; } = 50;

        /// <value>
        /// Warrior's base attack damage 
        /// </value>
        public int Attack { get; protected set; } = 5;

        /// <value>
        /// If warrior's HP is greater than 0 return true otherwise false
        /// </value>
        public bool IsAlive => Health > 0;

        public virtual int TakeDamage(Warrior attacker)
        {
            var realDamage = attacker.Attack;
            realDamage = (Health < realDamage) ? Health : realDamage;
            Health -= realDamage;

            return realDamage;
        }
        
        public virtual void DealDamage(Warrior target)
        {
            target.TakeDamage(this);
        }
    }
}
