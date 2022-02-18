using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Warlord : Defender
    {
        public Warlord()
        {
            Defense = 2;
            Attack = 4;
            MaxHealth = 100;
            Health = MaxHealth;
        }

        public List<Warrior> MoveUnits(Army army)
        {
            Warrior[] sortedUnits = new Warrior[army.Capacity];

            int unitsOffset = army.DeadUnitsCount;
            int healersOffset = 0;
            Array.Copy(army.TakeAllDead().ToArray(), 0, sortedUnits, 0, army.DeadUnitsCount);

            if (army.TakeAllAlive().OfType<Lancer>().Any())
            {
                
                Warrior[] lancers = army.TakeAllAlive().Where(x => x is Lancer).ToArray();
                Array.Copy(lancers, 0, sortedUnits, unitsOffset, lancers.Length);
                for (int i = 0; i < lancers.Length; i++)
                {
                    army.DropUnit(army.TakeAllAlive().FirstOrDefault(x => x is Lancer));
                }
                unitsOffset += lancers.Length;
            }
            else
            {
                var firstUnit = army.TakeAllAlive().FirstOrDefault(x => x is not Healer && x is not Warlord);
                
                if(firstUnit is null)
                {
                    firstUnit = army.TakeAllAlive().OfType<Healer>().FirstOrDefault();

                    if (firstUnit is null)
                    {
                        
                        firstUnit = army.TakeAllAlive().OfType<Warlord>().FirstOrDefault();
                    }
                    else
                    {
                        healersOffset++;
                    }
                }
                unitsOffset ++;
                sortedUnits[unitsOffset] = firstUnit;
                //army.DropUnit(firstUnit);

            }

            Warrior[] healers = army.TakeAllAlive().OfType<Healer>().Skip(healersOffset).ToArray();
            Array.Copy(healers, 0, sortedUnits, unitsOffset, healers.Length);
            unitsOffset += healers.Length;
            Warrior[] anotherUnits = army.TakeAllAlive().Select(x => x).Where(x => x is not Healer && x is not Warlord).ToArray();
            Array.Copy(anotherUnits, 0, sortedUnits, unitsOffset, anotherUnits.Length);
            sortedUnits[^1] = army.TakeAllAlive().FirstOrDefault(x => x is Warlord);

            return sortedUnits.ToList();
        }
    }
}
