using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warriors.Tests
{
    public class StraightFightTests
    {
        [Theory]
        [MemberData(nameof(StraightFightTestData))]
        public void StraightFight_ArmyVsArmy_ReturnCorrectOutcome(Army army1, Army army2, bool fightResult)
        {
            var actualFightResult = BattleGround.StraightFight(army1, army2);

            Assert.Equal(fightResult, actualFightResult);
        }

        public static IEnumerable<object[]> StraightFightTestData()
        {

            Army army1 = new();
            Army army2 = new();
            army1.AddUnits<Lancer>(5);
            army1.AddUnits<Vampire>(3);
            army1.AddUnits<Warrior>(4);
            army1.AddUnits<Defender>(2);
            army2.AddUnits<Warrior>(4);
            army2.AddUnits<Defender>(4);
            army2.AddUnits<Vampire>(6);
            army2.AddUnits<Lancer>(5);

            Army army3 = new();
            Army army4 = new();
            army3.AddUnits<Lancer>(7);
            army3.AddUnits<Vampire>(3);
            army3.AddUnits<Warrior>(4);
            army3.AddUnits<Defender>(2);
            army4.AddUnits<Warrior>(4);
            army4.AddUnits<Defender>(4);
            army4.AddUnits<Vampire>(6);
            army4.AddUnits<Lancer>(4);

            Army army5 = new();
            Army army6 = new();
            army5.AddUnits<Lancer>(7);
            army5.AddUnits<Vampire>(3);
            army5.AddUnits<Healer>(1);
            army5.AddUnits<Warrior>(4);
            army5.AddUnits<Healer>(1);
            army5.AddUnits<Defender>(2);
            army6.AddUnits<Warrior>(4);
            army6.AddUnits<Defender>(4);
            army6.AddUnits<Healer>(1);
            army6.AddUnits<Vampire>(6);
            army6.AddUnits<Lancer>(4);

            Army army7 = new();
            Army army8 = new();
            army7.AddUnits<Lancer>(4);
            army7.AddUnits<Warrior>(3);
            army7.AddUnits<Healer>(1);
            army7.AddUnits<Warrior>(4);
            army7.AddUnits<Healer>(1);
            army7.AddUnits<Knight>(2);
            army8.AddUnits<Warrior>(4);
            army8.AddUnits<Defender>(4);
            army8.AddUnits<Healer>(1);
            army8.AddUnits<Vampire>(2);
            army8.AddUnits<Lancer>(4);


            return new List<object[]>
            {
                new object[] { army1, army2, false},
                new object[] { army3, army4, true},
                new object[] { army5, army6, false},
                new object[] { army7, army8, true},
            };
        }
    }
}
