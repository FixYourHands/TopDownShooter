using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class EnemyMovement
    {
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }
        private float Speed { get; set; }
        public EnemyPosition Position { get; set; }
        public Direction CurrentFacingDirection { get; set; }
        public EnemyMovement(EnemyPosition position, float actorSpeed)
        {
            this.Position = position;
            this.Speed = actorSpeed;
            this.CurrentFacingDirection = Direction.Down;
        }

        public void Move(Direction direction)
        {
            if (IsPositionValid(direction))
            {
                switch (direction)
                {
                    case Direction.Left:
                        Position.SoldierPosition += new Vector2(-1, 0) * Speed;
                        CurrentFacingDirection = Direction.Left;
                        break;
                    case Direction.Right:
                        Position.SoldierPosition += new Vector2(1, 0) * Speed;
                        CurrentFacingDirection=Direction.Right;
                        break;
                    case Direction.Up:
                        Position.SoldierPosition += new Vector2(0, -1) * Speed;
                        CurrentFacingDirection = Direction.Up;
                        break;
                    case Direction.Down:
                        Position.SoldierPosition += new Vector2(0, 1) * Speed;
                        CurrentFacingDirection = Direction.Down;
                        break;
                }
            }
            else
            {
                // Handle invalid movement (e.g., log error, adjust position, etc.)
            }
        }

        public void MoveSoldierToBoundary(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    while (Position.SoldierPosition.X > 0 && IsPositionValid(Direction.Left))
                    {
                        Move(Direction.Left);
                        //perhaps insert collide with other object logic here
                    }
                    break;
                case Direction.Right:
                    while (Position.SoldierPosition.X < Position.Board.Columns && IsPositionValid(Direction.Right))
                    {
                        Move(Direction.Right);
                        //perhaps insert collide with other object logic here
                    }
                    break;
                case Direction.Up:
                    while (Position.SoldierPosition.Y > 0 && IsPositionValid(Direction.Up))
                    {
                        Move(Direction.Up);
                        //perhaps insert collide with other object logic here
                    }
                    break;
                case Direction.Down:
                    while (Position.SoldierPosition.Y < Position.Board.Rows && IsPositionValid(Direction.Down))
                    {
                        Move(Direction.Down);
                        //perhaps insert collide with other object logic here
                    }
                    break;
            }
        }

        public void SetSpeed(float value)
        {
            if (value < 0)
                this.Speed = 0;
            this.Speed = value;
        }

        public void MoveSoldierToCoordinates(float xCoord, float yCoord)
        {
            Position.SoldierPosition = new Vector2(xCoord, yCoord);
        }


        private bool IsPositionValid(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (Position.SoldierPosition.X > 0)
                    {
                        return true;
                    }
                    break;
                case Direction.Right:
                    if (Position.SoldierPosition.X < Position.Board.Columns && ((int)(Position.SoldierPosition.X + (1 * Speed)) <= Position.Board.Columns))
                    {
                        return true;
                    }
                    break;
                case Direction.Up:
                    if (Position.SoldierPosition.Y > 0)
                    {
                        return true;
                    }
                    break;
                case Direction.Down:
                    if (Position.SoldierPosition.Y < Position.Board.Rows)
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
