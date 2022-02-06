using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warriors.Tests
{
    public class ArmyTests
    {
        [Theory]
        [ClassData(typeof(ArmyTestData))]
        public void ArmyVsArmy_Fight_ReturnCorrectValue(Army army1, Army army2, bool expected)
        {
            var actual = BattleGround.Fight(army1, army2);

            Assert.Equal(expected, actual);
        }
    }

    class ArmyTestData : IEnumerable<object[]>
    {
        private readonly Army army1 = new();
        private readonly Army army2 = new();
        private readonly Army army3 = new();
        private readonly Army army4 = new();
        private readonly Army army5 = new();
        private readonly Army army6 = new();
        private readonly Army army7 = new();
        private readonly Army army8 = new();
        private readonly Army army9 = new();
        private readonly Army army10 = new();
        private readonly Army army11 = new();
        private readonly Army army12 = new();
        private readonly Army army13 = new();
        private readonly Army army14 = new();
        private readonly Army army15 = new();
        private readonly Army army16 = new();
        private readonly Army army17 = new();
        private readonly Army army18 = new();

        public ArmyTestData()
        {
            army1.AddUnits<Knight>(10);
            army1.AddUnits<Warrior>(5);
            army2.AddUnits<Knight>(10);
            army2.AddUnits<Warrior>(5);

            army3.AddUnits<Warrior>(9);
            army4.AddUnits<Warrior>(10);

            army5.AddUnits<Warrior>(10);
            army6.AddUnits<Warrior>(11);

            army7.AddUnits<Knight>(8);
            army8.AddUnits<Knight>(9);

            army9.AddUnits<Knight>(7);
            army10.AddUnits<Knight>(8);

            army11.AddUnits<Warrior>(5);
            army11.AddUnits<Defender>(4);
            army11.AddUnits<Defender>(5);
            army12.AddUnits<Warrior>(4);

            army13.AddUnits<Defender>(5);
            army13.AddUnits<Warrior>(20);
            army14.AddUnits<Warrior>(21);
            army13.AddUnits<Defender>(4);

            army15.AddUnits<Warrior>(10);
            army15.AddUnits<Defender>(5);
            army16.AddUnits<Warrior>(5);
            army15.AddUnits<Defender>(10);

            army17.AddUnits<Defender>(2);
            army17.AddUnits<Warrior>(1);
            army17.AddUnits<Defender>(1);
            army18.AddUnits<Warrior>(5);
        }
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { army1, army2, true };
            yield return new object[] { army3, army4, false };
            yield return new object[] { army5, army6, true };
            yield return new object[] { army7, army8, true };
            yield return new object[] { army9, army10, false };
            yield return new object[] { army11, army12, true };
            yield return new object[] { army13, army14, true };
            yield return new object[] { army15, army16, true };
            yield return new object[] { army17, army18, false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
