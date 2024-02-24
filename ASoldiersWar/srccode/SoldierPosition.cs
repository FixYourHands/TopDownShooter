using Microsoft.Xna.Framework;
using ConsoleApp1.WarriorFight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class SoldierPosition
    {
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public Vector2 PreviousPosition { get; set; }
        public Vector2 CurrentPosition { get; set; }
        public Board Board;
        public SoldierPosition(Vector2 spawnPoint, Board board)
        {
            this.CurrentPosition = spawnPoint;
            this.PreviousPosition = CurrentPosition;
            this.Board = board;
        }

        public String GetCurrentTileName()
        {
            return Board[(int)CurrentPosition.Y, (int)CurrentPosition.X].Name;
        }

        public double GetDistanceToSoldier(float xCoord, float yCoord)
        {
            //d = sqrt((y2-y1)^2+(x2-x1)^2)
            double distance = Math.Sqrt(Math.Pow(yCoord - CurrentPosition.Y, 2) + Math.Pow(xCoord - CurrentPosition.X, 2));
            return distance;
        }

        public double GetDistanceToSoldier(Soldier other)
        {
            //d = sqrt((y2-y1)^2+(x2-x1)^2)
            double distance = Math.Sqrt(Math.Pow(other.Position.CurrentPosition.Y - CurrentPosition.Y, 2) + Math.Pow(other.Position.CurrentPosition.X - CurrentPosition.X, 2));
            return distance;
        }

        public void AddSoldierToTile(Soldier soldier) //will change current Tile occupied status to true 
        {
            Board[soldier.Position.CurrentPosition].PlaceSoldier(soldier);
        }

        public void RemoveSoldierFromTile(Soldier soldier) //needs to be called before changing soldier position
        {
            Board[soldier.Position.CurrentPosition].RemoveSoldier(soldier);
        }
        public Tile GetCurrentTile()
        {
            return Board[CurrentPosition];
        }
        #region Display
        public void PrintPosition()
        {
            Console.WriteLine("Position: ({0},{1})", CurrentPosition.X, CurrentPosition.Y);
        }
        #endregion
    }
}
