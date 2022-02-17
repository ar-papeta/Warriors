using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.Weapons;

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
            MaxHealth = 60;
            Health = MaxHealth;
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

        protected override void EquipmentChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            base.EquipmentChanged(sender, e);
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems[0] is Weapon nw)
                    {
                        Defense = Math.Max(nw.Defense + Defense, 0);
                        Console.WriteLine($"Add {nw}");
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Weapon ow)
                    {
                        Defense = Math.Max(Defense - ow.Defense, 0);
                    }
                    break;
            }
        }
        public override string ToString()
        {
            return base.ToString() +
                   $"  Defense: {Defense}\n";
        }
    }
}
