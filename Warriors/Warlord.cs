using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.Scrolls;

namespace Warriors
{
    public class Warlord : Defender
    {
        private int _lastReincarnationCounter;
        private static readonly int ReincarnetionCalldown = 3;

        public Warlord()
        {
            Defense = 2;
            Attack = 4;
            MaxHealth = 100;
            Health = MaxHealth;
            _lastReincarnationCounter = 1;
        }

        public bool DeathGodPower { get; set; }

        private void Reincarnate(Army army)
        {
            if (DeathGodPower)
            {
                var unit = army.TakeAllDead().FirstOrDefault(unit => unit is not Vampire);
                if(unit is not null)
                {
                    if(_lastReincarnationCounter > ReincarnetionCalldown)
                    {
                        _lastReincarnationCounter = 1;
                        TakeDamage(7);
                        unit.Reincarnation();
                       
                        Console.WriteLine($"Reincarnetion of \n {unit}");
                    }
                    else
                    {
                        _lastReincarnationCounter++;
                    }
                }
            }
        }

        public List<Warrior> MoveUnits(Army army)
        {
            Reincarnate(army);

            Warrior[] sortedUnits = new Warrior[army.Capacity];

            int unitsOffset = army.DeadUnitsCount;
            int healersOffset = 0;
            int enotherOffset = 0;

            Array.Copy(army.TakeAllDead().ToArray(), 0, sortedUnits, 0, army.DeadUnitsCount);

            Warrior[] lancers = army.TakeAllAlive().Where(x => x is Lancer).ToArray();

            if (army.TakeAllAlive().OfType<Lancer>().Any())
            {
                sortedUnits[unitsOffset] = lancers[0];
                unitsOffset++;
                enotherOffset = 0;
            }
            else
            {
                var firstUnit = army.TakeAllAlive().FirstOrDefault(x => x is not Healer && x is not Warlord);
                
                if(firstUnit is not null)
                {
                    enotherOffset = 1;
                    sortedUnits[unitsOffset] = firstUnit;
                    unitsOffset++;
                }
            }

            Warrior[] healers = army.TakeAllAlive().OfType<Healer>().Skip(healersOffset).ToArray();
            Array.Copy(healers, 0, sortedUnits, unitsOffset, healers.Length);
            unitsOffset += healers.Length;

            if(army.TakeAllAlive().Count(x => x is Lancer) > 1)
            {
                Array.Copy(lancers, 1, sortedUnits, unitsOffset, lancers.Length - 1);
                unitsOffset += lancers.Length - 1;
            }

            Warrior[] anotherUnits = army.TakeAllAlive().Select(x => x).Where(x => x is not Healer && x is not Warlord && x is not Lancer).ToArray();
            Array.Copy(anotherUnits, enotherOffset, sortedUnits, unitsOffset, anotherUnits.Length - enotherOffset);
            
            sortedUnits[^1] = army.TakeAllAlive().FirstOrDefault(x => x is Warlord);
            return sortedUnits.ToList();
        }
    }
}
