using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.WarriorFight
{
    class GetWeapon 
    {
        public static Weapon GetAK47()
        {
            return new AK47();
        }

        public static Weapon GetAK47(string name = "Ak-47", int magSize = 30, int reserveSize = 240)
        {
            return new AK47(name,magSize,reserveSize);
        }

        public static Weapon GetM240B()
        {
            return new M240B();
        }

        public static Weapon GetM240B(string name = "M240B",int magSize = 100, int reserveSize = 400)
        {
            return new M240B(name,magSize,reserveSize);
        }
    }
}
