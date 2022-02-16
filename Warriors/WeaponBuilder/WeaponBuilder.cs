using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.WeaponBuilder
{
    public class WeaponBuilder : IWeaponBuilder
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
            throw new NotImplementedException();
        }

        public void SetDefense()
        {
            throw new NotImplementedException();
        }

        public void SetHealPower()
        {
            throw new NotImplementedException();
        }

        public void SetHealth()
        {
            throw new NotImplementedException();
        }

        public void SetVampirism()
        {
            throw new NotImplementedException();
        }
    }
}
