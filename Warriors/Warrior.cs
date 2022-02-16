using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.WeaponBuilder;

namespace Warriors
{
    public class Warrior
    {
        private readonly List<Weapon> _equipment;
        /// <value>
        /// Warrior's base health points 
        /// </value>
        public int MaxHealth { get; protected set; }

        /// <value>
        /// Warrior's current health points 
        /// </value>
        public int Health { get; protected set; }

        /// <value>
        /// Warrior's base attack damage 
        /// </value>
        public int Attack { get; protected set; }

        /// <value>
        /// If warrior's HP is greater than 0 return true otherwise false
        /// </value>
        public bool IsAlive => Health > 0;

        public Warrior()
        {
            Attack = 5;
            MaxHealth = 50;
            Health = MaxHealth;
            _equipment = new();
        }
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

        public virtual void DealDamage(Army enemy)
        {
            var enemyUnit = enemy.TakeFirstAlive();

            _ = DealDamage(enemyUnit, Attack);
        }

        public void TakeHeal(int healPower)
        {
            Health = Math.Clamp(Health + healPower, 0, MaxHealth);
        }
        
        public virtual void EquipWeapon(Weapon weapon)
        {
            _equipment.Add(weapon);
        }
    }
}
