﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.Weapons;

namespace Warriors
{
    public class Vampire : Warrior
    {
      
        public int Vampirism { get; private set; }

        public Vampire()
        {
            Attack = 4;
            MaxHealth = 40;
            Health = MaxHealth;
            Vampirism = 50;
        }

        public override int DealDamage(Warrior target, int damage)
        {
            var actualDamage = target.TakeDamage(damage);

            if (!target.IsAlive && target is Defender defender)
            {
                actualDamage = Attack - defender.Defense;
            }

            else if (target is not Defender)
            {
                actualDamage = Attack;
            }
            int vampirismHeal = actualDamage * Vampirism / 100;
            Health += vampirismHeal;
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }

            return actualDamage;
        }

        protected override void EquipmentChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems[0] is Weapon nw)
                    {
                        Health += nw.Health;
                        MaxHealth += nw.Health;
                        Attack += nw.Attack;
                        Vampirism += nw.Vampirism;
                        Console.WriteLine($"Добавлен {nw}");
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems?[0] is Weapon ow)
                    {
                        Health -= ow.Health;
                        MaxHealth -= ow.Health;
                        Attack -= ow.Attack;
                        Vampirism -= ow.Vampirism;
                        Console.WriteLine($"Удален {ow}");
                    }
                    break;
            }
        }

        public override string ToString()
        {
            return base.ToString()  + 
                   $"  vampirism: {Vampirism}";
        }
    }
}
