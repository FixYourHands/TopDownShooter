using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.WarriorFight
{
    class ShootProperties
    {
        Weapon weapon;
        int shotsFired { get; set; }
        int minBulletsFired { get; set; }
        int maxBulletsFired { get; set; }
        int earlyReloadChance { get; set; }
    }
}
