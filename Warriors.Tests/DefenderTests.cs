using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warriors.Tests
{
    /// <seealso cref="ArmyTests"> 
    /// Here is tests army vs army with defender units.
    /// </seealso>
    public class DefenderTests
    {
        [Fact]
        public void Defender_Defense_IsCorrect()
        {
            var expected = 2;
            Warrior defender = new Defender();
            var actual = defender.Defense;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Defender_Attack_IsCorrect()
        {
            var expected = 3;
            Warrior defender = new Defender();
            var actual = defender.Attack;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Defender_Health_IsCorrect()
        {
            var expected = 60;
            Warrior defender = new Defender();
            var actual = defender.Health;

            Assert.Equal(expected, actual);
        }
    }
}
