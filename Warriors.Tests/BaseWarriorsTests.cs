using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Warriors.Tests
{
    public class BaseWarriorsTests
    {
        private readonly string AssemblyName = "Warriors";

        [Theory]
        [InlineData("Defender")]
        [InlineData("Knight")]
        [InlineData("Warrior")]
        [InlineData("Army")]
        [InlineData("Vampire")]
        [InlineData("Lancer")]
        [InlineData("Healer")]
        [InlineData("BattleGround")]
        [InlineData("Warlord")]
        [InlineData("Weapons.Weapon")]
        public void Class_IsClassExist(string className)
        {
            var type = Type.GetType($"{AssemblyName}.{className}, {AssemblyName}");
            
            Assert.NotNull(type);
        }

        [Theory]
        [InlineData("Warrior", "Defender")]
        [InlineData("Warrior", "Knight")]
        [InlineData("Warrior", "Vampire")]
        [InlineData("Warrior", "Lancer")]
        [InlineData("Warrior", "Healer")]
        [InlineData("Warrior", "Warlord")]
        [InlineData("Defender", "Warlord")]
        public void Class_IsClassInheritsFromClass(string parentClassName, string childClassName)
        {
            var parentType = Type.GetType($"{AssemblyName}.{parentClassName}, {AssemblyName}");
            var childType = Type.GetType($"{AssemblyName}.{childClassName}, {AssemblyName}");

            Assert.NotNull(parentType);
            Assert.NotNull(childType);

            if (!childType.IsSubclassOf(parentType))
            {
                Assert.True(false, $"Class '{childType}' doesn't inherit from '{parentType}'");
            }
        }

        [Theory]
        [MemberData(nameof(NullWarriorData))]
        public void Fight_NullWarrior_ThrowArgumentNullException(Warrior first, Warrior second)
        {
            var expectedException = typeof(ArgumentNullException);
            var actException = Assert.Throws<ArgumentNullException>(() => BattleGround.Fight(first, second));

            Assert.Equal(expectedException, actException.GetType());
        }

        public static IEnumerable<object[]> NullWarriorData =>
        new List<object[]>
        {
            new object[] { null, new Warrior() },
            new object[] { new Knight(), null },
            new object[] { null, null },
        };


    }
}
