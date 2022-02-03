using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warriors.Tests
{
    public class ArmyBattleTests
    {
        [Theory]
        [ClassData(typeof(ArmyTestData))]
        public void Fight_Return_Correct_Value(Army army1, Army army2, bool expected)
        {
            var actual = BattleGround.Fight(army1, army2);

            Assert.Equal(expected, actual);
        }
    }

    class ArmyTestData : IEnumerable<object[]>
    {
        private static readonly Army army1 = new();
        private static readonly Army army2 = new();
        private static readonly Army army3 = new();
        private static readonly Army army4 = new();
        private static readonly Army army5 = new();
        private static readonly Army army6 = new();
        private static readonly Army army7 = new();
        private static readonly Army army8 = new();
        private static readonly Army army9 = new();
        private static readonly Army army10 = new();

        static ArmyTestData()
        {
            army1.AddUnits(UnitType.Knight, 10);
            army1.AddUnits(UnitType.Warrior, 5);
            army2.AddUnits(UnitType.Knight, 10);
            army2.AddUnits(UnitType.Warrior, 5);

            army3.AddUnits(UnitType.Warrior, 9);
            army4.AddUnits(UnitType.Warrior, 10);

            army5.AddUnits(UnitType.Warrior, 10);
            army6.AddUnits(UnitType.Warrior, 11);

            army7.AddUnits(UnitType.Knight, 8);
            army8.AddUnits(UnitType.Knight, 9);

            army9.AddUnits(UnitType.Knight, 7);
            army10.AddUnits(UnitType.Knight, 8);
        }
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { army1, army2, true };
            yield return new object[] { army3, army4, false };
            yield return new object[] { army5, army6, true };
            yield return new object[] { army7, army8, true };
            yield return new object[] { army9, army10, false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
