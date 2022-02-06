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
        public virtual int Health { get; protected set; } = 50;

        /// <value>
        /// Warrior's base attack damage 
        /// </value>
        public virtual int Attack { get; protected set; } = 5;

        /// <value>
        /// Warrior's base defense 
        /// </value>
        public virtual int Defense { get; protected set; } = 0;

        /// <value>
        /// If warrior's HP is greater than 0 return true otherwise false
        /// </value>
        public bool IsAlive => Health > 0;

        private int DamageTaken(int incomingDamage) => Math.Clamp(incomingDamage - Defense, 0, incomingDamage);
        
        public virtual int TakeDamage(Warrior attacker)
        {
            var realDamage = DamageTaken(attacker.Attack);
            Health -= realDamage;

            return realDamage;
        }
        
        public virtual void DealDamage(Warrior target)
        {
            target.TakeDamage(this);
        }
    }
}
