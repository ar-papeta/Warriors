using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public interface IWarrior
    {
        /// <value>
        /// Warrior unit current helth points
        /// </value>
        public int Health { get; }

        /// <value>
        /// Warrior unit current attack damage
        /// </value>
        public int Attack { get; }

        /// <value>
        /// If warrior's HP is greater than 0 return true otherwise false
        /// </value>
        public bool IsAlive => Health > 0;
        public void TakeDamage(IWarrior attacker);
        public void DealDamage(IWarrior target);


    }
}
