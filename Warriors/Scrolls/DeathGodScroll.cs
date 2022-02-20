using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warriors.Scrolls
{
    public class DeathGodScroll : IScroll
    {
        public void CallOfGod(Warrior unitSummoner)
        {
            if(unitSummoner is Warlord warlord)
            {
                warlord.DeathGodPower = true;
            }
            else
            {
                unitSummoner.TakeDamage(unitSummoner.Health);
            }
        }
    }
}
