using System;

namespace Warriors
{
    class Program
    {
        static void Main(string[] args)
        {
            Army army5 = new();
            Army army6 = new();
            army5.AddUnits<Lancer>(7);
            army5.AddUnits<Vampire>(3);
            army5.AddUnits<Healer>(1);
            army5.AddUnits<Warrior>(4);
            army5.AddUnits<Healer>(1);
            army5.AddUnits<Defender>(2);

            army6.AddUnits<Warrior>(4);
            army6.AddUnits<Defender>(4);
            army6.AddUnits<Healer>(1);
            army6.AddUnits<Vampire>(6);
            army6.AddUnits<Lancer>(4);
            BattleGround.StraightFight(army5, army6);
            
        }
    }
}
