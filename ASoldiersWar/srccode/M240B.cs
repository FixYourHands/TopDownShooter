using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.WarriorFight
{
    class M240B : Weapon
    {
        public int specialData { get; set; }
        public M240B(string name = "M240B", int magSize = 100, int reserves = 400)
        {
            this.name = name;
            MAX_MAGAZINE_SIZE = magSize;
            currentMagazine = magSize;
            reserveMagazine = reserves;
            reservesEmpty = false;
            magazineEmpty = false;
            weaponDamage = 27.0;
        }
    }
}
