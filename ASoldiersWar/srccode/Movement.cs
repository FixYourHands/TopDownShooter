using ASoldiersWar;
using ConsoleApp1.WarriorFight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Movement
    {
        enum Direction
        { Left, 
          Right,
          Up, 
          Down 
        }
        public Soldier soldier { get; set; }
        public Board grid { get; set; }
        /*
        public Movement(Soldier soldier,GameGrid grid)
        {
            this.soldier = soldier;
            this.grid = grid;
            PlaceCharacter();
        }

        public void MoveRight(int movementAmount)
        {
            if (!IsCharacterColliding(movementAmount,Direction.Right))
            {
                DisplaceCharacter();
                soldier.Position.MoveBy(0, movementAmount);
                PlaceCharacter();
            }
        }

        public void MoveLeft(int movementAmount)
        {
            if (!IsCharacterColliding(movementAmount, Direction.Left))
            {
                DisplaceCharacter();
                soldier.Position.MoveBy(0, movementAmount);
                PlaceCharacter();
            }
        }

        public void MoveUp(int movementAmount)
        {
            if (!IsCharacterColliding(movementAmount, Direction.Up))
            {
                DisplaceCharacter();
                soldier.Position.MoveBy(movementAmount,0);
                PlaceCharacter();
            }
        }

        public void MoveDown(int movementAmount)
        {
            if (!IsCharacterColliding(movementAmount, Direction.Down))
            {
                DisplaceCharacter();
                soldier.Position.MoveBy(movementAmount,0);
                PlaceCharacter();
            }
            
        }
        private bool IsCharacterColliding(int movementAmount, Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    if (soldier.Position.X + movementAmount <= -1)
                        return true;
                    break;
                case Direction.Right:
                    if (soldier.Position.X + movementAmount > grid.GridWidth)
                        return true;
                    break;
                case Direction.Up:
                    if (soldier.Position.Y + movementAmount <= -1)
                        return true;
                    break;
                case Direction.Down:
                    if (soldier.Position.Y + movementAmount > grid.GridHeight)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }
        */
        /*
        private void PlaceCharacter()
        {
            //if placeable
            grid[soldier.Position] += soldier.ID;
        }

        private void DisplaceCharacter()
        {
            //if placeable
            grid[soldier.Position] -= soldier.ID;
        }
        */
    }
}
