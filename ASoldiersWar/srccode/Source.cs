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
        public static void Manipulate(EnemyMovement pos1, Soldier pos2)
        {
            pos1.MoveSoldierToBoundary(EnemyMovement.Direction.Right);
            Console.WriteLine(pos1.Position.GetDistanceToSoldier(pos2));
            pos1.Position.PrintPosition();
            Console.WriteLine("\n\n");

            pos1.MoveSoldierToBoundary(EnemyMovement.Direction.Left);
            Console.WriteLine(pos1.Position.GetDistanceToSoldier(pos2));
            pos1.Position.PrintPosition();
        }
        

        public static void Main(string[] args)
        {
            Dictionary<int,string> mapping = new Dictionary<int, string>();

            Board board1 = new Board(101, 101);

            Soldier billBod = new Soldier(new AK47("AK-47"));
            Soldier Bob = new Soldier(new AK47("AK-47"));
            Bob.Initialize(board1);
            billBod.Initialize(board1);

            board1[26, 50].PlaceSoldier(Bob);
            Bob.SetPosition(0, 0);
            billBod.SetPosition(100, 00);

            Manipulate(Bob.EnemyMovement, billBod);

            
        }
    }
}
