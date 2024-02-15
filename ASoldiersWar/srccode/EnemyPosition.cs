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
        enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        protected Vector2 SoldierLastPosition;
        public Vector2 SoldierPosition { get; set; }
        public Board Board;
        protected float Speed;
        public EnemyPosition(Vector2 origin,float speed, Board board)
        {
            this.SoldierPosition = new Vector2(origin.X,origin.Y);
            this.SoldierLastPosition = SoldierPosition;
            this.Speed = speed;
            this.Board = board;
        }
        public void MoveLeft()
        {
            if (IsPositionValid(Direction.Left))
            {
                SoldierLastPosition = SoldierPosition;
                SoldierPosition += new Vector2(-1, 0) * this.Speed;
            }
        }

        public void MoveRight()
        {
            if (IsPositionValid(Direction.Right))
            {
                SoldierPosition += new Vector2(1, 0) * this.Speed;
            }
        }

        public void MoveUp()
        {
            if (IsPositionValid(Direction.Up))
            {
                SoldierPosition += new Vector2(0, -1) * this.Speed;
            }
        }

        public void MoveDown()
        {
            if (IsPositionValid(Direction.Down))
            {
                SoldierPosition += new Vector2(0, 1) * this.Speed;
            }
        }

        public String GetCurrentTileName()
        {
            return Board[(int)SoldierPosition.X, (int)SoldierPosition.Y].Name;
        }
        private bool IsPositionValid(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    if (SoldierPosition.X > 0)
                    {
                        return true;
                    }
                    break;
                case Direction.Right:
                    if (SoldierPosition.X < Board.Columns)
                    {
                        return true;
                    }
                    break;
                case Direction.Up:
                    if (SoldierPosition.Y > 0)
                    {
                        return true;
                    }
                    break;
                case Direction.Down:
                    if (SoldierPosition.Y < Board.Rows)
                    {
                        return true;
                    }
                    break;
            }
            Console.WriteLine("Movement failed!");
            return false;
        }

        #region Display
        public void PrintPosition()
        {
            Console.WriteLine("Position: ({0},{1})", SoldierPosition.X, SoldierPosition.Y);
        }
        #endregion
    }
}
