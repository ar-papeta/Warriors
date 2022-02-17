using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public class Army
    {
        private readonly List<Warrior> _army;

        public Warrior this[int i] => _army.Where(w => w.IsAlive).Skip(i).FirstOrDefault();

        public bool IsAlive => AliveUnitsCount > 0;

        public int ArmyHp => _army.Sum(x => x.Health);

        private int AliveUnitsCount => _army.Count(w => w.IsAlive);

        public IEnumerable<Warrior> GetAllAlive() => _army.Where(w => w.IsAlive);

        public Army()
        {
            _army = new();
        }

        /// <summary>Find the first alive unit in army</summary>
        /// <returns>First alive warrior or null if not exist</returns>
        public Warrior TakeFirstAlive()
        {
            return _army.FirstOrDefault(w => w.IsAlive);
        }

        public Warrior TakeSecondAlive()
        {
            return _army.Where(w => w.IsAlive).Skip(1).FirstOrDefault();
        }

        public void AddUnits<T>(int count) where T : Warrior, new()
        {
            while (count-- > 0)
            {
                _army.Add(new T());
            }
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
    }
}
