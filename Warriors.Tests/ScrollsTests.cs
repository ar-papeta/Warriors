using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Warriors.Scrolls;

namespace Warriors.Tests
{
    public class ScrollsTests
    {
        [Fact]
        public void ReadScroll_DeadGodScrollForNotWarlord_KillUnit()
        {
            Warrior warrior = new();
            warrior.ReadScroll(new DeathGodScroll());

            Assert.False(warrior.IsAlive, "Any unit except Warlors must die after read dead scroll");
        }

        [Fact]
        public void ReadScroll_DeadGodScrollForWarlord_CanReincarnate()
        {
            Warrior warrior = new Warlord();
            warrior.ReadScroll(new DeathGodScroll());
            var warlord = warrior as Warlord;

            Assert.True(warlord.DeathGodPower, "Any unit except Warlors must die after read dead scroll");
        }

        [Theory]
        [MemberData(nameof(ScrollsTestData))]
        public void Fight_ArmyVsArmyWithScrolls_ReturnCorrectOutcome(Army army1, Army army2, bool fightResult)
        {
            var actualFightResult = BattleGround.Fight(army1, army2);
           
            Assert.Equal(fightResult, actualFightResult);
        }

        public static IEnumerable<object[]> ScrollsTestData()
        {

            Army army1 = new();
            Army army2 = new();
            army1.AddUnits<Lancer>(1);
            army1.AddUnits<Warrior>(10);
            army1.AddUnits<Warlord>(1);

            army2.AddUnits<Warlord>(1);
            army2.AddUnits<Lancer>(1);
            army2.AddUnits<Warrior>(10);
            army2[0].ReadScroll(new DeathGodScroll());

            Army army3 = new();
            Army army4 = new();
            army3.AddUnits<Lancer>(1);
            army3[0].ReadScroll(new HealGodScroll());
            army4.AddUnits<Defender>(1);
            army4.AddUnits<Warrior>(1);

            Army army5 = new();
            Army army6 = new();
            army5.AddUnits<Lancer>(1);
            army5[0].ReadScroll(new WarGodScroll());
            army6.AddUnits<Warrior>(1);
            army6.AddUnits<Warrior>(1);

            return new List<object[]>
            {
                new object[] { army1, army2, false},
                new object[] { army3, army4, true},
                new object[] { army5, army6, true},
            };
        }
    }
}
