using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.Weapons;
using Xunit;

namespace Warriors.Tests
{
    public class WeaponsTests
    {
        [Theory]
        [MemberData(nameof(WeaponsUnitTestData))]
        public void Fight_WarriorsWithWeapon_ReturnCorrectOutcome(Warrior unit1, Warrior unit2, bool fightResult)
        {
            var actualFightResult = BattleGround.Fight(unit1, unit2);

            Assert.Equal(fightResult, actualFightResult);
        }

        public static IEnumerable<object[]> WeaponsUnitTestData()
        {
            Warrior warrior = new();
            Weapon weapon1 = Weapon.Builder().Health(-10).Attack(5).Vampirism(40).Build();
            warrior.EquipWeapon(weapon1);
            Weapon weapon2 = SecretShop.Sword();
            Warrior vampire = new Vampire();
            vampire.EquipWeapon(weapon2);

            Warrior defender = new Defender();
            Weapon weapon3 = SecretShop.Shield();
            defender.EquipWeapon(weapon3);
            Weapon weapon4 = SecretShop.GreatAxe();
            Warrior lancer = new Lancer();
            lancer.EquipWeapon(weapon4);

            Warrior healer = new Healer();
            Weapon weapon5 = SecretShop.MagicWand();
            healer.EquipWeapon(weapon5);
            Weapon weapon6 = SecretShop.Katana();
            Warrior knight = new Knight();
            knight.EquipWeapon(weapon6);

            Warrior defender2 = new Defender();
            Warrior vampire2 = new Vampire();
            Weapon weapon7 = SecretShop.Shield();
            Weapon weapon8 = SecretShop.MagicWand();
            Weapon weapon9 = SecretShop.Shield();
            Weapon weapon10 = SecretShop.Katana();
            defender2.EquipWeapon(weapon7);
            defender2.EquipWeapon(weapon8);
            vampire2.EquipWeapon(weapon9);
            vampire2.EquipWeapon(weapon10);

            return new List<object[]>
            {
                new object[] { warrior, vampire, true },
                new object[] { defender, lancer, false },
                new object[] { healer, knight, false },
                new object[] { defender2, vampire2, false },
            };
        }

        [Theory]
        [MemberData(nameof(WeaponsArmyTestData))]
        public void Fight_ArmyWithWeapon_ReturnCorrectOutcome(Army army1, Army army2, bool fightResult)
        {
            var actualFightResult = BattleGround.Fight(army1, army2);

            Assert.Equal(fightResult, actualFightResult);
        }

        public static IEnumerable<object[]> WeaponsArmyTestData()
        {
            Army army1 = new();
            Army army2 = new();
            army1.AddUnits<Knight>(1);
            army1.AddUnits<Lancer>(1);
            army1[0].EquipWeapon(SecretShop.MagicWand());
            army1[1].EquipWeapon(SecretShop.GreatAxe());
            army2.AddUnits<Vampire>(1);
            army2.AddUnits<Healer>(1);
            army2[0].EquipWeapon(SecretShop.MagicWand());
            army2[1].EquipWeapon(SecretShop.GreatAxe());

            Army army3 = new();
            Army army4 = new();
            army3.AddUnits<Defender>(1);
            army3.AddUnits<Warrior>(1);
            army3[0].EquipWeapon(SecretShop.GreatAxe());
            army3[1].EquipWeapon(SecretShop.GreatAxe());
            army4.AddUnits<Knight>(1);
            army4.AddUnits<Healer>(1);
            army4[0].EquipWeapon(SecretShop.MagicWand());
            army4[1].EquipWeapon(SecretShop.MagicWand());

            return new List<object[]>
            {
               new object[] { army1, army2, true },
               new object[] { army1, army2, true },
            };
        }
    }
}
