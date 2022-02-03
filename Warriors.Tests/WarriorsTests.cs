using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warriors.Tests
{
    public class WarriorsTests
    {
        public static IEnumerable<object[]> FightReturnData =>
        new List<object[]>
        {
            new object[] { new Warrior(), new Warrior(), true },
            new object[] { new Warrior(), new Knight(), false },
            new object[] { new Knight(), new Warrior(), true },
            new object[] { new Knight(), new Knight(), true },
        };

        [Theory]
        [MemberData(nameof(FightReturnData))]
        public void Fight_Return_Correct_Value(Warrior first, Warrior second, bool expected)
        {
                bool result = BattleGround.Fight(first, second);

                Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> CheckIAliveData =>
        new List<object[]>
        {
            new object[] { new Warrior(), new Warrior() },
            new object[] { new Warrior(), new Knight() },
            new object[] { new Knight(), new Warrior() },
            new object[] { new Knight(), new Knight() },
        };

        [Theory]
        [MemberData(nameof(CheckIAliveData))]
        public void Check_Is_Alive_After_Figths(Warrior first, Warrior second)
        {
                bool result = BattleGround.Fight(first, second);
                var expectedAlive = result ? first.IsAlive : second.IsAlive;
                var expectedNotAlive = !result ? first.IsAlive : second.IsAlive;

                Assert.True(expectedAlive, $"For alive warrior ");
                Assert.False(expectedNotAlive, $"For not alive warrior "); 
        }

        public static IEnumerable<object[]> NullWarriorData =>    
        new List<object[]>
        {
            new object[] { null, new Warrior() },
            new object[] { new Knight(), null },
            new object[] { null, null },
        };

        [Theory]
        [MemberData(nameof(NullWarriorData))]
        public void Null_Warrior_In_Fight_Throw_ArgumentNullException(Warrior first, Warrior second)
        {
                var expectedException = typeof(ArgumentNullException);
                var actException = Assert.Throws<ArgumentNullException>(() => BattleGround.Fight(first, second));

                Assert.Equal(expectedException, actException.GetType());
        }

        public static IEnumerable<object[]> HealthPointChangeData =>    
        new List<object[]>
        {
            new object[] { new Warrior(), new Warrior(), 45 },
            new object[] { new Warrior(), new Knight(), 43 },
        };

        [Theory]
        [MemberData(nameof(HealthPointChangeData))]
        public void Health_Point_Change_Correct_After_Attack(Warrior target, Warrior attacker, int expected)
        {
            int attackerHpRemainsMaximum = 50;
            attacker.DealDamage(target);
            var actual = target.Health;

            Assert.Equal(expected, actual);
            Assert.Equal(attackerHpRemainsMaximum, attacker.Health);
        }
    }
}
