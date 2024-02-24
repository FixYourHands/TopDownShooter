using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.WarriorFight
{
    class AK47 : Weapon
    {
        public AK47(string name = "AK-47",int magSize = 30, int reserves = 240)
        {
            this.Name = name;
            MAX_MAGAZINE_SIZE = magSize;
            currentMagazine = magSize;
            reserveMagazine = reserves;
            reservesEmpty = false;
            magazineEmpty = false;
            weaponDamage = 33.0;
        }
    }
}
