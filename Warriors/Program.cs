using System;

namespace Warriors
{
    class Program
    {
        static void Main(string[] args)
        {
            Army army = new();
            Army army2 = new();
            army.AddUnits<Lancer>(1);
            army2.AddUnits<Defender>(1);
            army2.AddUnits<Knight>(1);
            bool b = BattleGround.Fight(army, army2);
            Console.WriteLine(army2);
        }
    }
}
