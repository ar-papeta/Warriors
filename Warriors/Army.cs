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
        public bool IsAlive => AliveUnitsCount > 0;
        public int AliveUnitsCount => _army.Count(w => w.IsAlive);
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

        private void AddUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.Warrior:
                    _army.Add(new Warrior());
                    break;
                case UnitType.Knight:
                    _army.Add(new Knight());
                    break;
                default:
                    throw new ArgumentException($"Unknown type of warrior: {type}");
            }
        }

        public void AddUnits(UnitType type, int count)
        {
            while (count-- > 0)
            {
                AddUnit(type);
            }
        }
    }
}
