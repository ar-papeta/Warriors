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
        [Fact]
        public void Fight_Return_Correct_Value()
        {
            test(new Warrior(), new Warrior(), true);
            test(new Warrior(), new Knight(), false);
            test(new Knight(), new Warrior(), true);
            test(new Knight(), new Knight(), true);

            void test(IWarrior first, IWarrior second, bool expected)
            {
                bool result = BattleGround.Fight(first, second);
                Assert.Equal(expected, result);
            }
        }

        [Fact]
        public void Check_Is_Alive_After_Figths()
        {
            test(new Warrior(), new Warrior());
            test(new Warrior(), new Knight());
            test(new Knight(), new Warrior());
            test(new Knight(), new Knight());

            void test(IWarrior first, IWarrior second)
            {
                bool result = BattleGround.Fight(first, second);
                var expectedAlive = result ? first.IsAlive : second.IsAlive;
                var expectedNotAlive = !result ? first.IsAlive : second.IsAlive;
                Assert.True(expectedAlive, $"For alive warrior ");
                Assert.False(expectedNotAlive, $"For not alive warrior ");
            }
        }

        [Fact]
        public void Null_Warrior_In_Fight_Throw_ArgumentNullException()
        {
            test(null, new Warrior());
            test(new Knight(), null);
            test(null, null);

            void test(IWarrior first, IWarrior second)
            {
                var expectedException = typeof(ArgumentNullException);
                var actException = Assert.Throws<ArgumentNullException>(() => BattleGround.Fight(first, second));

                Assert.Equal(expectedException, actException.GetType());

            }
        }

        [Fact]
        public void Health_Point_Change_Correct_After_Attack()
        {
            IWarrior knight1 = new Knight();
            IWarrior knight2 = new Knight();
            IWarrior warrior1 = new Warrior();

            int attackerHpRemainsMaximum = 50;

            test(new Warrior(), new Warrior(), 45);
            test(new Warrior(), new Knight(), 43);

            test(knight1, knight2, 43);
            test(knight1, knight2, 36);
            test(knight1, knight2, 29);
            test(knight1, knight2, 22);
            test(knight1, warrior1, 17);
            test(knight1, warrior1, 12);
            test(knight1, warrior1, 7);
            test(knight1, warrior1, 2);


            void test(IWarrior target, IWarrior attacker, int expected)
            {
                attacker.DealDamage(target);
                var actual = target.Health;
                Assert.Equal(expected, actual);
                Assert.Equal(attackerHpRemainsMaximum, attacker.Health);
            }
        }
    }
}
