using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.WarriorFight
{
    public class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int xCoordinate, int yCoordinate)
        {
            this.X = xCoordinate;
            this.Y = yCoordinate;
        }

        public Coordinate()
        {
            X = 0;
            Y = 0;   
        }

        public void SetPosition(int yCoordinate, int xCoordinate)
        {
            X = xCoordinate;
            Y = yCoordinate;
        }

        public void MoveBy(int deltaY, int deltaX)
        {
            X += deltaX;
            Y += deltaY;
        }

        public double DistanceTo(Coordinate other)
        {
            int xDistance = other.X - X;
            int yDistance = other.Y - Y;

            return Math.Sqrt(xDistance * xDistance + yDistance * yDistance); //a^2 +b^2 = c^2
        }

        /*
        public double DistanceTo(Soldier other)
        {
            int xDistance = other.Position.X - X;
            int yDistance = other.Position.Y - Y;

            return Math.Sqrt(xDistance * xDistance + yDistance * yDistance); //a^2 +b^2 = c^2
        }
        */

        public void PrintPosition()
        {
            Console.WriteLine("Position: ({0},{1})",X,Y);
        }
    }
}
