using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Healer : Warrior
    {
        public int HealPower { get; protected set; } = 2;

        public Healer()
        {
            MaxHealth = 60;
            Health = MaxHealth;
            Attack = 0;
        }

        public void Heal(Warrior target)
        {
            target.TakeHeal(HealPower);
        }
    }
}
