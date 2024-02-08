using ConsoleApp1.WarriorFight;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class Source
    {
        static void MoveUnit(Soldier soldier)
        {
            soldier.Position += new Vector2(2,3);
            Console.WriteLine("Position: ({0},{1})",soldier.Position.X,soldier.Position.Y);
        }

        public static void Main(string[] args)
        {
            Soldier billBod = new Soldier(new AK47("AK-47"));
            Soldier Bob = new Soldier(new AK47("AK-47"));
            for (int i = 0; i < 10; i++)
            {
                MoveUnit(billBod);
                Console.WriteLine("Distance {0}",(int)billBod.GetDistanceToSoldier(Bob));
            }
        }
    }
}
