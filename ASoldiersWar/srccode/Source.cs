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

            board1[Bob.Position].PlaceSoldier(Bob);

            board1[Bob.Position].RemoveSoldier(Bob);
            billBod.SetPosition(15, 26);
            board1[billBod.Position].PlaceSoldier(billBod);
            Console.WriteLine(board1[15,26].Occupied);
            Console.WriteLine(billBod);
        }
    }
}
