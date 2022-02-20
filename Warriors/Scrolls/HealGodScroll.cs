using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warriors.Weapons;

namespace Warriors.Scrolls
{
    public class HealGodScroll : IScroll
    {
        public void CallOfGod(Warrior unitSummoner)
        {
            unitSummoner.EquipWeapon(SecretShop.RingOfRegen());
        }
    }
}
