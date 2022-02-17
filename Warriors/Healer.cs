using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
