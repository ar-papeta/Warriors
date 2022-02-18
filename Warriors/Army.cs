using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Army
    {
        private List<Warrior> _army;

        private int _lastDeadUnitsCount;
        
        public Warrior this[int i] => _army.Where(w => w.IsAlive).Skip(i).FirstOrDefault();
        public int Capacity => _army.Count;
        public bool IsAlive => AliveUnitsCount > 0;

        public bool HasWarlord() => TakeAllAlive().Any(x => x is Warlord);

        public Warlord WarlordOfArmy => TakeAllAlive().OfType<Warlord>().FirstOrDefault();

        public int ArmyHp => TakeAllAlive().Sum(x => x.Health);

        public int AliveUnitsCount => _army.Count(w => w.IsAlive);

        public List<Warrior> TakeAllDead() => _army.Where(w => !w.IsAlive).ToList();
        public int DeadUnitsCount => _army.Count(w => !w.IsAlive);
        public List<Warrior> TakeAllAlive() => _army.Where(w => w.IsAlive).ToList();

        public Army()
        {
            _army = new();
        }

        /// <summary>Find the first alive unit in army</summary>
        /// <returns>First alive warrior or null if not exist</returns>
        public Warrior TakeFirstAlive() => _army.FirstOrDefault(w => w.IsAlive);

        public Warrior TakeSecondAlive() => _army.Where(w => w.IsAlive).Skip(1).FirstOrDefault();

        public void AddUnits<T>(int count) where T : Warrior, new()
        {
            if (typeof(T).Equals(typeof(Warlord)))
            {
                if (HasWarlord())
                {
                    return;
                }
                _army.Add(new Warlord());
                return;
            }
            while (count-- > 0)
            { 
                _army.Add(new T());
            }
        }

        public bool HasNewDeadUnits()
        {
            bool HasNewDead = _lastDeadUnitsCount != DeadUnitsCount;
            if (HasNewDead)
            {
                _lastDeadUnitsCount = AliveUnitsCount;
            }
            return HasNewDead;
        }

        public void Attack(Army enemy)
        {
            var unit = TakeFirstAlive();

            unit.DealDamage(enemy);

            HealArmy();

        }

        private void HealArmy()
        {
            for (int i = 1; i < AliveUnitsCount; i++)
            {
                if(this[i] is Healer healer)
                {
                    var unitForHeal = this[i - 1];

                    if(unitForHeal is not null && unitForHeal.Health != unitForHeal.MaxHealth)
                    {
                        healer.Heal(unitForHeal);
                    }
                }
            }
        }

        public void MoveUnits()
        {
            if (HasWarlord())
            {
                List<Warrior> sortedArmy = WarlordOfArmy.MoveUnits(this);
                _army = sortedArmy;
            }
        }

        public override string ToString()
        {
            StringBuilder str = new();
            int i = 1;
            str.Append($"Army has units: \n");
            foreach (var unit in TakeAllAlive())
            {
                str.Append($"{i++}: {unit.GetType()} \n");
            }
            return str.ToString();
        }
    }
}
