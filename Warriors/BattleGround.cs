using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.Loger;
using Warriors.Validation;

namespace Warriors
{
    public static class BattleGround
    {
        public static bool Fight(Warrior first, Warrior second)
        {
            Validator.ValidateFight(first, second);

            int round = 1;
            while(first.IsAlive && second.IsAlive)
            {
                if (round % 2 != 0)
                {
                    first.DealDamage(second, first.Attack);
                    first.Regeneration();
                }
                else
                {
                    second.DealDamage(first, second.Attack);
                    second.Regeneration();
                }
                Log.LogDebug($"\t\t{round}r:\t{first.Health}\t{second.Health}");
                round++;
            }
            var winner = first.IsAlive ? first : second;
            Log.LogInfo($"Fight end , winner is {winner}");
            return first.IsAlive;
        }

        public static bool Fight(Army firstArmy, Army secondArmy)
        {
            Validator.ValidateFight(firstArmy, secondArmy);

            PrepareArmy(firstArmy);
            PrepareArmy(secondArmy);

            Log.LogInfo($"\nStart fight army : First {firstArmy} Second {secondArmy}");

            while (firstArmy.IsAlive && secondArmy.IsAlive)
            {
                var firstUnit = firstArmy.TakeFirstAlive();
                var secondUnit = secondArmy.TakeFirstAlive();

                Log.LogDebug($"Start fight: {firstUnit.GetType()} vs {secondUnit.GetType()}");

                int round = 1;
                while (firstUnit.IsAlive && secondUnit.IsAlive)
                {
                    if (round % 2 != 0)
                    {
                        firstArmy.Attack(secondArmy);
                    }
                    else
                    {
                        secondArmy.Attack(firstArmy);
                    }
                    Log.LogDebug($"\t\t{round}r:\t{firstUnit.Health}\t{secondUnit.Health}");
                    round++;
                }
            }
            var winner = firstArmy.IsAlive ? firstArmy : secondArmy;
            Log.LogInfo($"Fight end , winner is {winner}");

            return firstArmy.IsAlive;
        }

        public static bool StraightFight(Army firstArmy, Army secondArmy)
        {
            Validator.ValidateFight(firstArmy, secondArmy);

            PrepareArmy(firstArmy);
            PrepareArmy(secondArmy);

            while (firstArmy.IsAlive && secondArmy.IsAlive)
            {
                
                var armyPairs = firstArmy.TakeAllAlive().Zip(secondArmy.TakeAllAlive());

                foreach (var (First, Second) in armyPairs)
                {

                    Log.LogInfo($"Start fight: {First.GetType()} vs {Second.GetType()}");

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
            var winner = firstArmy.IsAlive ? firstArmy : secondArmy;
            Log.LogInfo($"Fight end , winner is {winner}");

            return firstArmy.IsAlive;
        }

        public static bool StraightFightParallel(Army firstArmy, Army secondArmy)
        {
            Validator.ValidateFight(firstArmy, secondArmy);

            PrepareArmy(firstArmy);
            PrepareArmy(secondArmy);

            while (firstArmy.IsAlive && secondArmy.IsAlive)
            {

                var armyPairs = firstArmy.TakeAllAlive().Zip(secondArmy.TakeAllAlive());

                Parallel.ForEach<(Warrior, Warrior)>(
                    armyPairs,
                    x =>
                    {
                        Log.LogInfo($"Start fight: {x.Item1.GetType()} vs {x.Item2.GetType()}");

                        bool res = Fight(x.Item1, x.Item2);
                        if (res)
                        {
                            secondArmy.MoveUnits();
                        }
                        else
                        {
                            firstArmy.MoveUnits();
                        }
                    }
                    );
            }
            var winner = firstArmy.IsAlive ? firstArmy : secondArmy;
            Log.LogInfo($"Fight end , winner is {winner}");

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
    }
}
