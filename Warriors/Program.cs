using System;
using System.Linq;
using Warriors.Weapons;
using Warriors.Scrolls;

namespace Warriors
{
    class Program
    {
        private class Rookie : Warrior
        {
            public Rookie()
            {
                Attack = 1;
            }
        }
        static void Main(string[] args)
        {
            //Army a1 = new();
            //a1.AddUnits<Warlord>(1);
            //a1.AddUnits<Warrior>(7);
            //a1[0].ReadScroll(new DeathGodScroll());
            //a1[1].ReadScroll(new HealGodScroll());
            //Army a2 = new();
            //a2.AddUnits<Warlord>(1);
            //a2[0].EquipWeapon(SecretShop.Sword());
            //a2[0].EquipWeapon(SecretShop.Sword());
            //a2[0].EquipWeapon(SecretShop.Sword());
            //a2[0].EquipWeapon(SecretShop.Sword());
            //a2[0].EquipWeapon(SecretShop.Sword());
            //BattleGround.Fight(a1, a2);

            //Army army1 = new();
            //Army army2 = new();
            //army1.AddUnits<Lancer>(1);
            //army1.AddUnits<Warrior>(10);
            //army1.AddUnits<Warlord>(1);

            //army2.AddUnits<Warlord>(1);
            //army2.AddUnits<Lancer>(1);
            //army2.AddUnits<Warrior>(10);
            //army2[0].ReadScroll(new DeathGodScroll());
            //BattleGround.Fight(army1, army2);

            Army army5 = new();
            Army army6 = new();
            army5.AddUnits<Lancer>(1);
            army5[0].ReadScroll(new WarGodScroll());
            army6.AddUnits<Warrior>(1);
            army6.AddUnits<Warrior>(1);
            BattleGround.Fight(army5, army6);
        }
    }
}
