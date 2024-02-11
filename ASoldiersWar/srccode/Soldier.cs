
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
            this.Movement = new EnemyMovement(new Vector2(), Speed, gameBoard);
        }

        public void MoveRight()
        {
            Movement.MoveRight();
        }
        public void MoveLeft()
        {
            Movement.MoveLeft();
        }
        public void MoveUp()
        {
            Movement.MoveUp();
        }
        public void MoveDown()
        {
            Movement.MoveDown();
        }
        public void PrintPosition()
        {
            Console.WriteLine("Position: ({0},{1})", Movement.SoldierPosition.X,Movement.SoldierPosition.Y);
        }
        public void SetPosition(float xCoord, float yCoord)
        {
            MovePlayerToLocation(xCoord,yCoord);
        }

        private Vector2 MovePlayerToLocation(float xCoord, float yCoord)
        {
            return Movement.SoldierPosition = new Vector2(xCoord, yCoord);
        }

        #region Distance Calculation
        public double GetDistanceToSoldier(Soldier other)
        {
            return CalculateDistanceToVector2(other.Movement.SoldierPosition);
        }

        private double CalculateDistanceToVector2(Vector2 p2)
        {
            //d = sqrt((y2-y1)^2+(x2-x1)^2)
            double distance = Math.Sqrt(Math.Pow(p2.Y- Movement.SoldierPosition.Y, 2) + Math.Pow(p2.X-Movement.SoldierPosition.X, 2));
            return distance;
        }
        #endregion
    }
}
