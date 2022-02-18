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

            int healersOffset = 0;

            int deadOffset = army.DeadUnitsCount;
            Array.Copy(army.TakeAllDead().ToArray(), 0, sortedUnits, 0, army.DeadUnitsCount);



            if (army.TakeAllAlive().OfType<Lancer>().Any())
            {
                sortedUnits[deadOffset] = army.TakeAllAlive().FirstOrDefault(x => x is Lancer);
                army.TakeAllAlive().Remove(army.TakeAllAlive().FirstOrDefault(x => x is Lancer));
            }
            else
            {
                var firstUnit = army.TakeAllAlive().FirstOrDefault(x => x is not Healer && x is not Warlord);
                
                if(firstUnit is null)
                {
                    firstUnit = army.TakeAllAlive().OfType<Healer>().FirstOrDefault();
                    healersOffset += 1;

                    if (firstUnit is null)
                    {
                        healersOffset -= 1;
                        firstUnit = army.TakeAllAlive().OfType<Warlord>().FirstOrDefault();
                    }   
                }
                sortedUnits[deadOffset] = firstUnit;

            }

            Warrior[] healers = army.TakeAllAlive().OfType<Healer>().Skip(healersOffset).ToArray();
            Array.Copy(healers, 0, sortedUnits, deadOffset + 1, healers.Length);

            Warrior[] anotherUnits = army.TakeAllAlive().Select(x => x).Where(x => x is not Healer && x is not Warlord).Skip(1).ToArray();
            Array.Copy(anotherUnits, 0, sortedUnits, healers.Length + deadOffset + 1, anotherUnits.Length);
            sortedUnits[^1] = army.TakeAllAlive().FirstOrDefault(x => x is Warlord);

            return sortedUnits.ToList();
        }
    }
}
