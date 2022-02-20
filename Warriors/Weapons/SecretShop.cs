using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.Weapons
{
    public static class SecretShop
    {

        public static Weapon Sword()
        {
            return Weapon.Builder()
                         .Health(5)
                         .Attack(2)
                         .Build();
        }

        public static Weapon Shield()
        {
            return Weapon.Builder()
                         .Health(20)
                         .Attack(-1)
                         .Defense(2)
                         .Build();
        }

        public static Weapon GreatAxe()
        {
            return Weapon.Builder()
                         .Health(-15)
                         .Attack(5)
                         .Defense(-2)
                         .Vampirism(10)
                         .Build();
        }

        public static Weapon Katana()
        {
            return Weapon.Builder()
                         .Health(-20)
                         .Attack(6)
                         .Defense(-5)
                         .Vampirism(50)
                         .Build();
        }

        public static Weapon MagicWand()
        {
            return Weapon.Builder()
                         .Health(30)
                         .Attack(3)
                         .HealPower(3)
                         .Build();
        }

        public static Weapon GodBlade()
        {
            return Weapon.Builder()
                         .Health(-30)
                         .Attack(11)
                         .Build();
        }

        public static Weapon RingOfRegen()
        {
            return Weapon.Builder()
                         .Health(10)
                         .Attack(-1)
                         .HpRegen(1)
                         .HealPower(1)
                         .Build();
        }
    }  
}
