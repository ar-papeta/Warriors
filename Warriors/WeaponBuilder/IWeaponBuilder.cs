using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.WeaponBuilder
{
    public interface IWeaponBuilder : IBuilder<Weapon>
    {
        void SetHealth();

        void SetAttack();

        void SetDefense();

        void SetVampirism();

        void SetHealPower();
    }
}
