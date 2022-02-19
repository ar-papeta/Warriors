using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.Validation
{
    public static class Validator
    {
        public static void ValidateFight(Warrior first, Warrior second)
        {
            NullCheck(first);
            NullCheck(second);

            CheckHealersFight(first, second);
            CheckBothUnitsDead(first, second);
        }

        public static void ValidateFight(Army first, Army second)
        {
            NullCheck(first);
            NullCheck(second);

            CheckBothUnitsDead(first, second);
        }

        private static void CheckBothUnitsDead(Army unit1, Army unit2)
        {
            if (!unit1.IsAlive && !unit2.IsAlive)
            {
                throw new ArgumentException("Can not create fight with two dead armies!");
            }
        }

        private static void CheckBothUnitsDead(Warrior unit1, Warrior unit2)
        {
            if (!unit1.IsAlive && !unit2.IsAlive)
            {
                throw new ArgumentException("Can not create fight with two dead warriors!");
            }
        }

        private static void CheckHealersFight(Warrior unit1, Warrior unit2)
        {
            if (unit1 is Healer && unit2 is Healer)
            {
                throw new ArgumentException("Can not create fight with two Healers");
            }
        }

        private static void NullCheck(Warrior unit)
        {
            if (unit is null)
            {
                throw new ArgumentNullException(nameof(unit), "Warrior can not be null");
            }
        }

        private static void NullCheck(Army unit)
        {
            if (unit is null)
            {
                throw new ArgumentNullException(nameof(unit), "Warrior can not be null");
            }
        }
    }
}
