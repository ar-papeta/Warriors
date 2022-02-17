using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.Weapons
{
    public interface IWeaponBuilder : IBuilder<Weapon>
    {
        IWeaponBuilder Health(int health);

        IWeaponBuilder Attack(int attack);

        IWeaponBuilder Defense(int defense);

        IWeaponBuilder Vampirism(int vampirism);

        IWeaponBuilder HealPower(int healPower);
    }
}
