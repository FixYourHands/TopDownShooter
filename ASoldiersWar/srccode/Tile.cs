using Microsoft.Xna.Framework;
using ConsoleApp1.WarriorFight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class Tile
    {
        private static int TileCounter = 0;
        public string Name { get; set; }
        public bool Occupied { get; set; } = false;

        public Vector2 Position { get; set; }

        public List<Soldier> Soldiers { get; set; }

        public Tile()
        {
            Name = "Tile " + TileCounter.ToString();
            TileCounter++;
            Soldiers = new List<Soldier>();
            Position = new Vector2(0, 0);
        }

        public void PlaceSoldier(Soldier soldier)
        {
            //maybe have a max count
            Soldiers.Add(soldier);
            Occupied = true;
        }

        public void RemoveSoldier(Soldier soldier)
        {
            Soldiers.Remove(soldier);
            if (Soldiers.Count == 0)
            {
                Occupied = false;
            }
        }

        public void SetPosition(Vector2 coordinates)
        {
            this.Position = coordinates;
        }

        public void SetPosition(float xCoord, float yCoord)
        {
            Position = new Vector2(xCoord, yCoord);
        }
        public void PrintPosition()
        {
            Console.WriteLine("Coordinates: ({0},{1})", Position.X, Position.Y);
        }
    }
}
