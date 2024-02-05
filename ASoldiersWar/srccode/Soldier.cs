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
        public  Coordinate Position { get; set; }
        public int ID { get; }

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
            this.Position = new Coordinate(); // Assuming Coordinate is a valid type
            this.ID = 1; // Implement GenerateUniqueID() to ensure unique IDs
            this.ShootAction = new Shoot(this.Weapon);
        }



        public double GetDistanceToSoldier(Soldier other)
        {
            return Position.DistanceTo(other);
        }
    }
}
