using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.WeaponBuilder
{
    public class SecretShop
    {
        private readonly IWeaponBuilder _weaponBuilder;

        //public IWeaponBuilder SetNewBuilder(IWeaponBuilder builder) => _weaponBuilder = builder; 
        public SecretShop(IWeaponBuilder weaponBuilder)
        {
            _weaponBuilder = weaponBuilder;
        }

        public Weapon Sell()
        {
            _weaponBuilder.Reset();

            _weaponBuilder.SetHealth();

            _weaponBuilder.SetAttack();

            _weaponBuilder.SetDefense();

            _weaponBuilder.SetVampirism();

            _weaponBuilder.SetHealPower();

            return _weaponBuilder.GetResult();
        }
    }
}
