using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.Weapons;

namespace Warriors
{
    public class Healer : Warrior
    {
        public int HealPower { get; protected set; }
        public int MaxManaPoints { get; private set; }
        public int CurrentManaPoints { get; private set; }
        public Healer()
        {
            MaxManaPoints = 100;
            CurrentManaPoints = MaxManaPoints;
            HealPower = 2;
            MaxHealth = 60;
            Health = MaxHealth;
            Attack = 0;
        }

        public void Heal(Warrior target)
        {
            if(CurrentManaPoints-- > 0)
            {
                target.TakeHeal(HealPower);
            }
        }

        public void SetManaToMax()
        {
            CurrentManaPoints = MaxManaPoints;
        }

        protected override void EquipmentChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            base.EquipmentChanged(sender, e);
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems[0] is Weapon nw)
                    {
                        HealPower = Math.Max(nw.HealPower + HealPower, 0);
                        Attack = 0;
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Weapon ow)
                    {
                        HealPower = Math.Max(HealPower - ow.HealPower, 0);
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString() +
                   $"\tHeal power: {HealPower}";
        }
    }
}
