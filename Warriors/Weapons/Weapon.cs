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
        public int Health { get; private set; }

        /// <value>
        /// Add to the soldier's attack this modificator
        /// </value>
        public int Attack { get; private set; }

        /// <value>
        /// Add to the soldier's defense this modificator
        /// </value>
        public int Defense { get; private set; }

        /// <value>
        /// Increase the soldier’s vampirism to this number
        /// </value>
        public int Vampirism { get; private set; }

        /// <value>
        /// Increase the amount of health which the healer restore for the allied unit 
        /// </value>
        public int HealPower { get; private set; }

        private Weapon() { }

        public static WeaponBuilder Builder()
        {
            return new WeaponBuilder();
        }

        public override string ToString()
        {
            return $"Weapon has attributes: \n " + 
                   $"  health: {Health} \n " +
                   $"  defense: {Defense} \n " +
                   $"  attack: {Attack} \n " +
                   $"  heal power: {HealPower} \n " +
                   $"  vampirism: {Vampirism} \n ";
           
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
                _result.Attack = attack;
                return this;
            }

            public IWeaponBuilder Defense(int defense)
            {
                _result.Defense = defense;
                return this;
            }

            public Weapon Build()
            {
                return _result;
            }

            public IWeaponBuilder HealPower(int healPower)
            {
                _result.HealPower = healPower;
                return this;
            }

            public IWeaponBuilder Health(int health)
            {
                _result.Health = health;
                return this;
            }

            public void Reset()
            {
                _result = new();
            }

            public IWeaponBuilder Vampirism(int vampirism)
            {
                _result.Vampirism = vampirism;
                return this;
            }
        }
    }
}
