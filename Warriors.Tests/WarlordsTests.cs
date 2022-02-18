using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.Weapons;
using Xunit;

namespace Warriors.Tests
{
    public class WarlordsTests
    {
        private class Rookie : Warrior
        {
            public Rookie()
            {
                Attack = 1;
            }
        }
        [Theory]
        [MemberData(nameof(WarlordsArmyTestData))]
        public void Fight_ArmyWithWarlords_ReturnCorrectOutcome(Army army1, Army army2, bool fightResult)
        {
            var actualFightResult = BattleGround.Fight(army1, army2);

            Assert.Equal(fightResult, actualFightResult);
        }

        public static IEnumerable<object[]> WarlordsArmyTestData()
        {
            Army army1 = new();
            Army army2 = new();
            army1.AddUnits<Warlord>(1);
            army1.AddUnits<Warrior>(2);
            army1.AddUnits<Lancer>(2);
            army1.AddUnits<Healer>(2);
            army2.AddUnits<Warlord>(1);
            army2.AddUnits<Vampire>(1);
            army1.AddUnits<Healer>(2);
            army1.AddUnits<Knight>(2);
            army1.MoveUnits();
            army2.MoveUnits();

            Army army3 = new();
            Army army4 = new();
            army3.AddUnits<Warrior>(2);
            army3.AddUnits<Lancer>(2);
            army3.AddUnits<Defender>(1);
            army3.AddUnits<Warlord>(3);
            army4.AddUnits<Warlord>(2);
            army4.AddUnits<Vampire>(1);
            army4.AddUnits<Healer>(5);
            army4.AddUnits<Knight>(2);
            army3.MoveUnits();
            army4.MoveUnits();

            Army army5 = new();
            Army army6 = new();
            army5.AddUnits<Warrior>(2);
            army5.AddUnits<Lancer>(3);
            army5.AddUnits<Defender>(1);
            army5.AddUnits<Warlord>(4);
            army6.AddUnits<Warlord>(1);
            army6.AddUnits<Vampire>(1);
            army6.AddUnits<Rookie>(1);
            army6.AddUnits<Knight>(1);

            army5[0].EquipWeapon(SecretShop.Sword());
            army6[0].EquipWeapon(SecretShop.Shield());
            army5.MoveUnits();
            army6.MoveUnits();

            return new List<object[]>
            {
               new object[] { army1, army2, true },
               new object[] { army3, army4, false },
               new object[] { army5, army6, true },
            };
        }

        [Theory]
        [MemberData(nameof(WarlordsArmyStraightTestData))]
        public void StraightFight_ArmyWithWarlords_ReturnCorrectOutcome(Army army1, Army army2, bool fightResult)
        {
            var actualFightResult = BattleGround.StraightFight(army1, army2);

            Assert.Equal(fightResult, actualFightResult);
        }

        public static IEnumerable<object[]> WarlordsArmyStraightTestData()
        {
            Army army1 = new();
            Army army2 = new();
            army1.AddUnits<Warrior>(2);
            army1.AddUnits<Lancer>(3);
            army1.AddUnits<Defender>(1);
            army1.AddUnits<Warlord>(1);
            army2.AddUnits<Warlord>(5);
            army2.AddUnits<Vampire>(1);
            army2.AddUnits<Rookie>(1);
            army2.AddUnits<Knight>(1);
            army1.MoveUnits();
            army2.MoveUnits();

            return new List<object[]>
            {
               new object[] { army1, army2, false },

            };
        }

        [Theory]
        [MemberData(nameof(WarlordsVsUnitsTestData))]
        public void Fight_WarlordVsUnits_ReturnCorrectOutcome(Warrior warrior1, Warrior warrior2, bool fightResult)
        {
            var actualFightResult = BattleGround.Fight(warrior1, warrior2);

            Assert.Equal(fightResult, actualFightResult);
        }

        public static IEnumerable<object[]> WarlordsVsUnitsTestData()
        {
            return new List<object[]>
            {
               new object[] { new Defender(), new Warlord(), false },
               new object[] { new Warlord(), new Vampire(), true },
               new object[] { new Warlord(), new Knight(), true },
            };
        }
    }
}
