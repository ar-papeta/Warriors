using System;
using System.Linq;
using Warriors.Weapons;

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
            Army army5 = new();

            army5.AddUnits<Warrior>(2);
            army5.AddUnits<Knight>(3);
            //army5.AddUnits<Lancer>(3);
            army5.AddUnits<Defender>(1);
            army5.AddUnits<Healer>(3);
            army5.AddUnits<Warlord>(1);
            
            army5.MoveUnits();

            Console.WriteLine(army5);
        }
    }
}
