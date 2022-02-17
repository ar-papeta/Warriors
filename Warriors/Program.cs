using System;
using System.Linq;
using Warriors.Weapons;

namespace Warriors
{
    class Program
    {
        static void Main(string[] args)
        {
            Warrior defender = new Defender();
            Weapon weapon3 = SecretShop.Shield();
            defender.EquipWeapon(weapon3);
            Weapon weapon4 = SecretShop.GreatAxe();
            Warrior lancer = new Lancer();
            lancer.EquipWeapon(weapon4);

            Console.WriteLine(defender);
            Console.WriteLine(lancer);

            BattleGround.Fight(defender, lancer);
        }
    }
}
