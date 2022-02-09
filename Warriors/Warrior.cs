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

        public virtual int TakeDamage(int damage)
        {
            damage = Health < damage ? Health : damage;
            Health -= damage;

            return damage;
        }
        
        public virtual int DealDamage(Warrior target, int damage)
        {
            return target.TakeDamage(damage);
        }
    }
}
