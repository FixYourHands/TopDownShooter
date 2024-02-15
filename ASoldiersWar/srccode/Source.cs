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
        

        public static void Main(string[] args)
        {
            Dictionary<int,string> mapping = new Dictionary<int, string>();

            Board board1 = new Board(101, 101);

            Soldier billBod = new Soldier(new AK47("AK-47"));
            Soldier Bob = new Soldier(new AK47("AK-47"));
            Bob.Initialize(board1);

            List<Soldier> soldierList = new List<Soldier>();
            soldierList.Add(billBod);
            soldierList.Add(Bob);
            board1[0, 0].PlaceSoldier(Bob);

            Bob.MoveRightIndefinitely();
        }
    }
}
