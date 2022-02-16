using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.WeaponBuilder
{
    public class GreatAxeBuilder : IWeaponBuilder
    {
        private Weapon _result;
        public Weapon GetResult()
        {
            return _result;
        }

        public void Reset()
        {
            _result = new();
        }

        public void SetAttack()
        {
            _result.Attack = 5;
        }

        public void SetDefense()
        {
            _result.Defense = -2;
        }

        public void SetHealPower()
        {
            //_result.HealPower = 0;
        }

        public void SetHealth()
        {
            _result.Health = -15;
        }

        public void SetVampirism()
        {
            _result.Vampirism = 10;
        }
    }
}
