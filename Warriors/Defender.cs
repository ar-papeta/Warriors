using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Defender : Warrior
    {
        /// <value>
        /// Defender base defense 
        /// </value>
        public int Defense { get; protected set; } 

        public Defender()
        {
            Defense = 2;
            Health = 60;
            Attack = 3;
        }

        private int DamageTaken(int incomingDamage) => Math.Clamp(incomingDamage - Defense, 0, incomingDamage);

        public override int TakeDamage(int damage)
        {
            var realDamage = DamageTaken(damage);
            realDamage = (Health < realDamage) ? Health : realDamage;
            Health -= realDamage;

            return realDamage;
        }

        public override int DealDamage(Warrior target, int damage)
        {
           return target.TakeDamage(damage);
        }
    }
}
