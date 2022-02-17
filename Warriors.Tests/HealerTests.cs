using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warriors.Tests
{
    /// <seealso cref="ArmyTests"> 
    /// Here is tests army vs army with healer units.
    /// </seealso>
    public class HealerTests
    {
        [Fact]
        public void DealDamage_Healer_HaveNoEffect()
        {
            Warrior w = new();
            Warrior h = new Healer();
            h.DealDamage(w, h.Attack);
            Assert.Equal(w.MaxHealth, w.Health);
        }

        [Fact]
        public void Fight_WithHealer_OutFromInfinitLoop()
        {
            Army army1 = new();
            army1.AddUnits<Defender>(1);
            army1.AddUnits<Healer>(1);

            Army army2 = new();
            army2.AddUnits<Vampire>(1);
            army2.AddUnits<Healer>(1);

            var actual = BattleGround.Fight(army1, army2);
            Assert.True(actual);
        }

        [Theory]
        [MemberData(nameof(HealerTestDataData))]
        public void Heal_UnitInArmy_AddCorrectHpCount(Army army1, Army army2, int expected)
        {
            army1.Attack(army2);
            var actual = army1.TakeFirstAlive().Health;
            Assert.Equal(expected, actual);
        }

        public static IEnumerable<object[]> HealerTestDataData()
        {

            Army army1 = new();
            Army army2 = new();
            army1.AddUnits<Lancer>(1);
            army2.AddUnits<Healer>(1);
            army2.AddUnits<Knight>(1);

            Army army3 = new();
            Army army4 = new();
            army3.AddUnits<Lancer>(1);
            army3.TakeFirstAlive().TakeDamage(20);
            army3.AddUnits<Healer>(1);
            army4.AddUnits<Warrior>(1);

            Army army5 = new();
            Army army6 = new();
            army5.AddUnits<Lancer>(1);
            army5.TakeFirstAlive().TakeDamage(1);
            army5.AddUnits<Healer>(1);
            army6.AddUnits<Warrior>(1);

            return new List<object[]>
            {
                new object[] { army1, army2, 50 },
                new object[] { army3, army4, 32 },
                new object[] { army6, army5, 50 },
            };
        }
    }
}
