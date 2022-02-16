using System;
using Warriors.Weapons;

namespace Warriors
{
    class Program
    {
        static void Main(string[] args)
        {
            Weapon me4 = Weapon.Builder()
                                .Vampirism(10)
                                .Health(4)
                                .Attack(-12)
                                .Build();
            
            Console.WriteLine(me4.ToString());

        }
    }
}
