using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warriors.Tests
{
    /// <seealso cref="ArmyTests"> 
    /// Here is tests army vs army with lancer units.
    /// </seealso>
    public class LancerTests 
    {
        [Fact]
        public void Lancer_Attack_IsCorrect()
        {
            var expected = 6;
            Warrior lancer = new Lancer();
            var actual = lancer.Attack;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [MemberData(nameof(LancerTestData))]
        public void Fight_LancerVsUnitsInArmy_ReturnCorrectResidualHp(Army army1, Army army2, bool fightResult, int residualHp)
        {
            var actualFightResult = BattleGround.Fight(army1, army2);
            var actualHp = actualFightResult ? army1.ArmyHp : army2.ArmyHp;
            var expectedHp = residualHp;

            Assert.Equal(fightResult, actualFightResult);
            Assert.Equal(expectedHp, actualHp);
        }

        public static IEnumerable<object[]> LancerTestData()
        {
            
            Army army1 = new();
            Army army2 = new();
            army1.AddUnits<Lancer>(1);
            army2.AddUnits<Warrior>(1);
            army2.AddUnits<Knight>(1);

            Army army3 = new();
            Army army4 = new();
            army3.AddUnits<Lancer>(1);
            army4.AddUnits<Defender>(1);
            army4.AddUnits<Warrior>(1);

            Army army5 = new();
            Army army6 = new();
            army5.AddUnits<Lancer>(1);
            army6.AddUnits<Warrior>(1);
            army6.AddUnits<Warrior>(1);

            return new List<object[]>
            {
                new object[] { army1, army2, false, 11 },
                new object[] { army3, army4, false, 8 },
                new object[] { army6, army5, true, 23 },
            };
        }
    }
}
