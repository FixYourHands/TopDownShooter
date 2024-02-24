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
        public static void TestFunc(Soldier s1, Soldier s2, float distance)
        {
            while (CheckDistanceGreaterThan(s1,s2,distance))
            {
                Console.WriteLine(s1.GetDistanceToSoldier(s2));
                s1.MoveRight();
                
                
            }
            s1.PrintPosition();
            s2.PrintPosition();
        }

        public static bool CheckDistanceLessThan(Soldier s1, Soldier s2, float distance)
        {
            if (s1.GetDistanceToSoldier(s2) < distance)
                return true;
            return false;
        }

        public static bool CheckDistanceGreaterThan(Soldier s1, Soldier s2, float distance)
        {
            if (s1.GetDistanceToSoldier(s2) > distance)
                return true;
            return false;
        }

        public static bool CheckDistanceEqualTo(Soldier s1, Soldier s2, float distance)
        {
            if (s1.GetDistanceToSoldier(s2) == distance)
                return true;
            return false;
        }

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



            Bob.SetPosition(44, 58);
            Bob.PrintPosition();
            Console.WriteLine(board1.GetSoldierTile(Bob).ColumnNumber);
            Console.WriteLine(board1.GetSoldierTile(billBod).ColumnNumber);

            billBod.SetPosition(44, 56);
            Bob.Movement.CheckAreaAboveSoldier();

            Console.WriteLine(board1[44,58].GetOccupiedStatus());
        }
    }
}
