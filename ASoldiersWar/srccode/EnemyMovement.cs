using Microsoft.Xna.Framework;
using ConsoleApp1.WarriorFight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class EnemyMovement
    {
        enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public Vector2 SoldierPosition { get; set; }
        private Board Board;
        private float Speed;
        public EnemyMovement(Vector2 origin,float speed, Board board)
        {
            this.SoldierPosition = new Vector2(origin.X,origin.Y);
            this.Speed = speed;
            this.Board = board;
        }
        public void MoveLeft()
        {
            if (CheckBoundaries(Direction.Left))
            {
                SoldierPosition += new Vector2(-1, 0) * this.Speed;
            }
        }

        public void MoveRight()
        {
            if (CheckBoundaries(Direction.Right))
            {
                SoldierPosition += new Vector2(1, 0) * this.Speed;
            }
        }

        public void MoveUp()
        {
            if (CheckBoundaries(Direction.Up))
            {
                SoldierPosition += new Vector2(0, -1) * this.Speed;
            }
        }

        public void MoveDown()
        {
            if (CheckBoundaries(Direction.Down))
            {
                SoldierPosition += new Vector2(0, 1) * this.Speed;
            }
        }

        public String GetCurrentTileName()
        {
            return Board[(int)SoldierPosition.X, (int)SoldierPosition.Y].Name;
        }
        private bool CheckBoundaries(Direction direction)
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
    }
}
