using ConsoleApp1.WarriorFight;
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
        private int currentColumn;
        private int currentRow;
        private float Speed { get; set; }
        public SoldierPosition Position { get; set; }
        public Soldier Soldier { get; set; }
        public Direction CurrentFacingDirection { get; set; }
        public EnemyMovement(SoldierPosition position, float actorSpeed)
        {
            this.Position = position;
            this.Speed = actorSpeed;
            this.CurrentFacingDirection = Direction.Down;
        }

        public EnemyMovement(Soldier soldier)
        {
            this.Soldier = soldier;
            this.Position = soldier.Position;
            this.Speed = soldier.Speed;
            this.CurrentFacingDirection = Direction.Down;

            Position.AddSoldierToTile(soldier);
        }

        public void Move(Direction direction)
        {
            if (IsPositionValid(direction))
            {
                switch (direction)
                {
                    case Direction.Left:
                        Position.CurrentPosition += new Vector2(-1, 0) * Speed;
                        CurrentFacingDirection = Direction.Left;
                        break;
                    case Direction.Right:
                        Position.CurrentPosition += new Vector2(1, 0) * Speed;
                        CurrentFacingDirection=Direction.Right;
                        break;
                    case Direction.Up:
                        Position.CurrentPosition += new Vector2(0, -1) * Speed;
                        CurrentFacingDirection = Direction.Up;
                        break;
                    case Direction.Down:
                        Position.CurrentPosition += new Vector2(0, 1) * Speed;
                        CurrentFacingDirection = Direction.Down;
                        break;
                }
            }
            else
            {
                // Handle invalid movement (e.g., log error, adjust position, etc.)
            }
        }

        //perhaps insert while and checklogic (CheckNegative) to decide when to stop
        public void MoveSoldierToBoundary(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    while (Position.CurrentPosition.X > 0 && IsPositionValid(Direction.Left))
                    {
                        Move(Direction.Left);
                        //perhaps insert collide with other object logic here
                    }
                    break;
                case Direction.Right:
                    while (Position.CurrentPosition.X < Position.Board.Columns && IsPositionValid(Direction.Right))
                    {
                        Move(Direction.Right);
                        //perhaps insert collide with other object logic here
                    }
                    break;
                case Direction.Up:
                    while (Position.CurrentPosition.Y > 0 && IsPositionValid(Direction.Up))
                    {
                        Move(Direction.Up);
                        //perhaps insert collide with other object logic here
                    }
                    break;
                case Direction.Down:
                    while (Position.CurrentPosition.Y < Position.Board.Rows && IsPositionValid(Direction.Down))
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
            Position.CurrentPosition = new Vector2(xCoord, yCoord);
            Position.AddSoldierToTile(Soldier);
        }


        private bool IsPositionValid(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    if (Position.CurrentPosition.X > 0)
                    {
                        return true;
                    }
                    break;
                case Direction.Right:
                    if (Position.CurrentPosition.X < Position.Board.Columns)
                    {
                        Console.WriteLine("Columns {0}",Position.Board.Columns);
                        return true;
                    }
                    break;
                case Direction.Up:
                    if (Position.CurrentPosition.Y > 0)
                    {
                        return true;
                    }
                    break;
                case Direction.Down:
                    if (Position.CurrentPosition.Y < Position.Board.Rows)
                    {
                        return true;
                    }
                    break;
            }
            Console.WriteLine("Movement failed!");
            return false;
        }

        public void CheckAreaAboveSoldier()
        {
            Vector2 comp = Position.CurrentPosition;
            UpdateColumnsAndRows();
            //check 4x4 area around Soldier
            if (Position.Board[Position.CurrentPosition].RowNumber >= 3)
            {
                for (int i = 1; i < 3 + 1; i++) //i < SoldierVisionWidth (3)
                {
                    comp = new Vector2(comp.X, comp.Y-1);
                    if (Position.Board[comp].GetOccupiedStatus())
                    {
                        Console.Write("Tile Occupied! ");
                        Position.Board[comp].PrintPosition();
                        break;
                    }
                    
                }
            }
        }

        private void UpdateColumnsAndRows()
        {
            this.currentRow = Position.Board[Position.CurrentPosition].RowNumber;
            this.currentColumn = Position.Board[Position.CurrentPosition].ColumnNumber;
        }
    }
}
