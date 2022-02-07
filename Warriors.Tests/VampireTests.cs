using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warriors.Tests
{
    /// <seealso cref="ArmyTests"> 
    /// Here is tests army vs army with vampire units.
    /// </seealso>
    public class VampireTests : Warrior
    {
        [Theory]
        [MemberData(nameof(VampireTestDataData))]
        public void Fight_VampireVsEnemy_CorrectVampirism(Warrior vampire, Warrior other, int expected)
        {
            var startHp = vampire.Health;
            vampire.DealDamage(other);
            var actual = vampire.Health - startHp;

            Assert.Equal(expected, actual);
        }
        public static IEnumerable<object[]> VampireTestDataData()
        {
            Warrior vampireFullHp = new Vampire();

            Warrior vampire = new Vampire();
            vampire.TakeDamage(new Warrior());
            vampire.TakeDamage(new Warrior());

            Warrior defender = new Defender();
            Warrior warrior = new();
            Warrior custom = new VampireTests() { Health = 1 };
            
            return new List<object[]>
            {
                new object[] { vampire, defender, 1 },
                new object[] { vampire, warrior, 2 },
                new object[] { vampire, custom, 0 },
                new object[] { vampireFullHp, warrior, 0 },
            };
        }

        

        [Theory]
        [MemberData(nameof(FightData))]
        public void Fight_VampireVsEnemy_ReturnCorrectValue(Warrior first, Warrior second, bool expected)
        {
            bool result = BattleGround.Fight(first, second);

            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> FightData =>
        new List<object[]>
        {
            new object[] { new Defender(), new Vampire(), true },
            new object[] { new Warrior(), new Vampire(), true },
            new object[] { new Knight(), new Vampire(), true },
            new object[] { new Vampire(), new Knight(), false },
        };

    }
}
