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
            Army army1 = new();
            Army army2 = new();
            army1.AddUnits<Warrior>(2);
            army1.AddUnits<Lancer>(3);
            army1.AddUnits<Defender>(1);
            army1.AddUnits<Warlord>(1);
            army2.AddUnits<Warlord>(5);
            army2.AddUnits<Vampire>(1);
            army2.AddUnits<Rookie>(1);
            army2.AddUnits<Knight>(1);
            army1.MoveUnits();
            army2.MoveUnits();
            BattleGround.StraightFight(army1, army2);
            //Console.WriteLine(army1);
        }
    }
}
