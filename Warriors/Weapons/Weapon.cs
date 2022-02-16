using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.Weapons
{
    public class Weapon
    {
        /// <value>
        /// Add to the current health and the maximum health of the soldier this modificator
        /// </value>
        private int _health;

        /// <value>
        /// Add to the soldier's attack this modificator
        /// </value>
        private int _attack;

        /// <value>
        /// Add to the soldier's defense this modificator
        /// </value>
        private int _defense;

        /// <value>
        /// Increase the soldier’s vampirism to this number
        /// </value>
        private int _vampirism;

        /// <value>
        /// Increase the amount of health which the healer restore for the allied unit 
        /// </value>
        private int _healPower;

        private Weapon() { }

        public static WeaponBuilder Builder()
        {
            return new WeaponBuilder();
        }

        public override string ToString()
        {
            return $"Weapon has attributes: \n " + 
                   $"  health: {_health} \n " +
                   $"  defense: {_defense} \n " +
                   $"  attack: {_attack} \n " +
                   $"  heal power: {_healPower} \n " +
                   $"  vampirism: {_vampirism} \n ";
           
        }

        public class WeaponBuilder : IWeaponBuilder
        {
            private Weapon _result;

            public WeaponBuilder()
            {
                Reset();
            }
            public IWeaponBuilder Attack(int attack)
            {
                _result._attack = attack;
                return this;
            }

            public IWeaponBuilder Defense(int defense)
            {
                _result._defense = defense;
                return this;
            }

            public Weapon Build()
            {
                return _result;
            }

            public IWeaponBuilder HealPower(int healPower)
            {
                _result._healPower = healPower;
                return this;
            }

            public IWeaponBuilder Health(int health)
            {
                _result._health = health;
                return this;
            }

            public void Reset()
            {
                _result = new();
            }

            public IWeaponBuilder Vampirism(int vampirism)
            {
                _result._vampirism = vampirism;
                return this;
            }
        }
    }
}
