
using ASoldiersWar;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.WarriorFight
{
    public class Soldier
    {
        private Shoot ShootAction;
        public string Name { get; }
        public  int Health { get; set; }
        public  int ArmorRating { get; }
        public double AccuracyRating { get; }
        public  Weapon Weapon { get; set; }
        public float Speed { get; set; }
        public int ID { get; }
        public SoldierPosition Position { get; set; }
        public EnemyMovement Movement { get; set; }

        public Soldier(Weapon weapon, string name = "Soldier", int health = 100, int armorRating = 0, double accuracyRating = 1.0)
        {
            if (accuracyRating > 1 || accuracyRating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(accuracyRating), "Accuracy rating must be between 0 and 1.0!");
            }

            // Validate other properties as needed (e.g., health, armorRating)

            this.Name = name;
            this.Health = health;
            this.ArmorRating = armorRating;
            this.AccuracyRating = accuracyRating;
            this.Weapon = weapon;
            this.ID = 1; // Implement GenerateUniqueID() to ensure unique IDs
            this.ShootAction = new Shoot(this.Weapon);
            this.Speed = 2.0f;
            
        }

        public void Initialize(Board gameBoard)
        {
            this.Position = new SoldierPosition(new Vector2(), gameBoard);
            //this.EnemyMovement = new EnemyMovement(Position,Speed);
            this.Movement = new EnemyMovement(GetInstanceOfClass());

        }
        #region Movement
        public void MoveRight()
        {
            Movement.Move(EnemyMovement.Direction.Right);
        }

        public void MoveRightIndefinitely()
        {
            Movement.MoveSoldierToBoundary(EnemyMovement.Direction.Right);
            
        }
        public void MoveLeft()
        {
            Movement.Move(EnemyMovement.Direction.Left);
        }
        public void MoveUp()
        {
            Movement.Move(EnemyMovement.Direction.Up);
        }
        public void MoveDown()
        {
            Movement.Move(EnemyMovement.Direction.Down);
        }
        #endregion

        public void Update()
        {
            MoveDown();
            MoveRight();
            MoveRight();
            MoveDown();
            MoveLeft();
            PrintPosition();
        }

        #region Position
        public void PrintPosition()
        {
            Position.PrintPosition();
        }
        public void SetPosition(float xCoord, float yCoord)
        {
            Movement.Position.RemoveSoldierFromTile(GetInstanceOfClass());
            Movement.MoveSoldierToCoordinates(xCoord, yCoord);
            Movement.Position.AddSoldierToTile(GetInstanceOfClass());
        }

        public void SetPosition(Vector2 coordinates)
        {
            Movement.MoveSoldierToCoordinates(coordinates.X,coordinates.Y);
        }
        #endregion

        #region Distance Calculation
        public double GetDistanceToSoldier(Soldier other)
        {
            return Position.GetDistanceToSoldier(other.Position.CurrentPosition.X,other.Position.CurrentPosition.Y);
        }

        public double GetDistanceToSoldier(Vector2 coord)
        {
            return Position.GetDistanceToSoldier(coord.X,coord.Y);
        }


        #endregion
        private Soldier GetInstanceOfClass() //class returns itself
        {
            return this;
        }
    }
}
