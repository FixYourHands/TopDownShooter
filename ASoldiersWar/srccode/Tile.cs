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
        private bool occupiedStatus;
        public string Name { get; set; }
        public int ColumnNumber { get; set; }
        public int RowNumber { get; set; }

        private Vector2 position;

        public List<Soldier> Soldiers { get; set; }

        public Tile()
        {
            Name = "Tile : " + TileCounter.ToString();
            TileCounter++;
            Soldiers = new List<Soldier>();
            this.position = new Vector2(0, 0);
            this.occupiedStatus = false;
        }
        #region Place/Remove Soldier
        public void PlaceSoldier(Soldier soldier)
        {
            //maybe have a max count
            Soldiers.Add(soldier);
            occupiedStatus = true;
        }

        public void RemoveSoldier(Soldier soldier)
        {
            if (!Soldiers.Remove(soldier))
            {
                Console.WriteLine("Soldier not found!");
            }
            
            if (Soldiers.Count == 0)
            {
                occupiedStatus = false;
            }
        }

        #endregion

        #region Set Tile Position
        public void SetPosition(Vector2 coordinates)
        {
            this.position = coordinates;
        }

        public void SetPosition(float xCoord, float yCoord)
        {
            this.position = new Vector2(xCoord, yCoord);
        }
        #endregion
        public void PrintPosition()
        {
            Console.WriteLine("Coordinates: ({0},{1})", position.X, position.Y);
        }

        public static void PrintTileInfo(Tile tile)
        {
            tile.PrintPosition();
        }

        public bool GetOccupiedStatus()
        {
            return this.occupiedStatus;
        }
    }
}
