using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.WeaponBuilder
{
    public class Weapon
    {
        /// <value>
        /// Add to the current health and the maximum health of the soldier this modificator
        /// </value>
        public int Health { get; set; }

        /// <value>
        /// Add to the soldier's attack this modificator
        /// </value>
        public int Attack { get; set; }

        /// <value>
        /// Add to the soldier's defense this modificator
        /// </value>
        public int Defense { get; set; }

        /// <value>
        /// Increase the soldier’s vampirism to this number
        /// </value>
        public int Vampirism { get; set; }

        /// <value>
        /// Increase the amount of health which the healer restore for the allied unit 
        /// </value>
        public int HealPower { get; set; }
    }
}
