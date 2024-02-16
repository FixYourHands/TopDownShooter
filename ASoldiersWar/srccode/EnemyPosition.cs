using Microsoft.Xna.Framework;
using ConsoleApp1.WarriorFight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class EnemyPosition
    {
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public Vector2 SoldierLastPosition { get; set; }
        public Vector2 SoldierPosition { get; set; }
        public Board Board;
        public EnemyPosition(Vector2 origin, Board board)
        {
            this.SoldierPosition = origin;
            this.SoldierLastPosition = SoldierPosition;
            this.Board = board;
        }

        public String GetCurrentTileName()
        {
            return Board[(int)SoldierPosition.Y, (int)SoldierPosition.X].Name;
        }

        public double GetDistanceToSoldier(float xCoord, float yCoord)
        {
            //d = sqrt((y2-y1)^2+(x2-x1)^2)
            double distance = Math.Sqrt(Math.Pow(yCoord - SoldierPosition.Y, 2) + Math.Pow(xCoord - SoldierPosition.X, 2));
            return distance;
        }

        public double GetDistanceToSoldier(Soldier other)
        {
            //d = sqrt((y2-y1)^2+(x2-x1)^2)
            double distance = Math.Sqrt(Math.Pow(other.Position.SoldierPosition.Y - SoldierPosition.Y, 2) + Math.Pow(other.Position.SoldierPosition.X - SoldierPosition.X, 2));
            return distance;
        }

        public Tile GetCurrentTile()
        {
            return Board[SoldierPosition];
        }
        #region Display
        public void PrintPosition()
        {
            Console.WriteLine("Position: ({0},{1})", SoldierPosition.X, SoldierPosition.Y);
        }
        #endregion
    }
}
