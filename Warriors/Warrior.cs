using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.Weapons;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Warriors.Scrolls;

namespace Warriors
{
    public class Warrior
    {
        protected readonly ObservableCollection<Weapon> Equipment;

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
        /// Warrior's base hp regeneration (0 by default) 
        /// </value>
        public int HpRegeneration { get; protected set; }

        /// <value>
        /// If warrior's HP is greater than 0 return true otherwise false
        /// </value>
        public bool IsAlive => Health > 0;

        public Warrior()
        {
            Attack = 5;
            MaxHealth = 50;
            Health = MaxHealth;
            Equipment = new();
            Equipment.CollectionChanged += EquipmentChanged;
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

            if (enemy.HasNewDeadUnits())
            {
                enemy.MoveUnits();
            }
        }

        public void TakeHeal(int healPower)
        {
            Health = Math.Clamp(Health + healPower, 0, MaxHealth);
        }
        
        public virtual void EquipWeapon(Weapon weapon)
        {
            Equipment.Add(weapon);
        }

        public virtual void Regeneration()
        {
            Health = Math.Clamp(Health + HpRegeneration, 0, MaxHealth);
        }

        public virtual void Reincarnation()
        {
            Health = MaxHealth / 2;
        }

        protected virtual void EquipmentChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems[0] is Weapon nw)
                    {
                        Attack = Math.Max(Attack + nw.Attack, 0);
                        Health = Math.Max(Health + nw.Health, 0);
                        MaxHealth = Math.Max(MaxHealth + nw.Health, 0);
                        HpRegeneration += nw.HpRegen;
                        Console.WriteLine($"Add {nw}");
                    }
                    break;

                case NotifyCollectionChangedAction.Remove: 
                    if (e.OldItems?[0] is Weapon ow)
                    {
                        Attack = Math.Max(Attack - ow.Attack, 0);
                        Health = Math.Max(Health - ow.Health, 0);
                        MaxHealth = Math.Max(MaxHealth - ow.Health, 0);
                        HpRegeneration += ow.HpRegen;
                        Console.WriteLine($"Удален {ow}");
                    }
                    break;
            }
        }

        public void ReadScroll(IScroll scroll)
        {
            scroll.CallOfGod(this);
        }

        public override string ToString()
        {
            return $"Warrior {GetType()}\n" +
                   $"\tHealth: {Health}\n"  +
                   $"\tAttack: {Attack}\n";
        }
    }
}
