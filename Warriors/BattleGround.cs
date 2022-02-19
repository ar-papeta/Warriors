using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors
{
    public static class BattleGround
    {
        public static bool Fight(Warrior first, Warrior second)
        {
            if (first is null)
            {
                throw new ArgumentNullException(nameof(first), "Warrior can not be null");
            }   
            if (second is null)
            {
                throw new ArgumentNullException(nameof(second), "Warrior can not be null");
            } 
            if(first is Healer &&  second is Healer)
            {
                throw new ArgumentNullException(nameof(second), "Can not create fight with two Healers");
            }

            int round = 1;
            while(first.IsAlive && second.IsAlive)
            {
                if (round % 2 != 0)
                {
                    first.DealDamage(second, first.Attack);
                    Console.Write(round + "r: " +first.Health + "  ");
                    Console.WriteLine(second.Health + "  ");
                }
                else
                {
                    second.DealDamage(first, second.Attack);
                    Console.Write(round + "r: " + first.Health + "  ");
                    Console.WriteLine(second.Health + "  ");

                }
                round++;
            }
            Console.WriteLine("---end---");
            return first.IsAlive;
        }

        public static bool Fight(Army firstArmy, Army secondArmy)
        {
            PrepareArmy(firstArmy);
            PrepareArmy(secondArmy);
            while (firstArmy.IsAlive && secondArmy.IsAlive)
            {
                var firstUnit = firstArmy.TakeFirstAlive();
                var secondUnit = secondArmy.TakeFirstAlive();

                int round = 1;
                Console.WriteLine(firstUnit.GetType());
                Console.WriteLine(secondUnit.GetType());
                while (firstUnit.IsAlive && secondUnit.IsAlive)
                {
                    if (round % 2 != 0)
                    {
                        firstArmy.Attack(secondArmy);
                        Console.Write(round + "r: " + firstUnit.Health + "  ");
                        Console.WriteLine(secondUnit.Health + "  ");
                    }
                    else
                    {
                        secondArmy.Attack(firstArmy);
                        Console.Write(round + "r: " + firstUnit.Health + "  ");
                        Console.WriteLine(secondUnit.Health + "  ");
                    }
                    
                    round++;
                }
            }
            return firstArmy.IsAlive;
        }

        private static void PrepareArmy(Army army)
        {
            foreach (Healer healer in army.TakeAllAlive().OfType<Healer>())
            {
                healer.SetManaToMax();
            }
            army.MoveUnits();
        }

        public static bool StraightFight(Army firstArmy, Army secondArmy)
        {
            while (firstArmy.IsAlive && secondArmy.IsAlive)
            {
                
                var armyPairs = firstArmy.TakeAllAlive().Zip(secondArmy.TakeAllAlive());
                foreach (var (First, Second) in armyPairs)
                {
                    Console.WriteLine(First.GetType());
                    Console.WriteLine(Second.GetType());
                    bool res = Fight(First, Second);
                    if (res)
                    {
                        secondArmy.MoveUnits();
                    }
                    else
                    {
                        firstArmy.MoveUnits();
                    }
                }
            }
            return firstArmy.IsAlive;
        }
    }
}
