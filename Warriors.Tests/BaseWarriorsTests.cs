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


    }
}
