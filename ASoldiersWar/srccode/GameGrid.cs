using Microsoft.Xna.Framework;
using ASoldiersWar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.WarriorFight
{
    public class GameGrid
    {
        private readonly int[,] grid;
        public int GridHeight { get; }
        public int GridWidth { get; }
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }

        public int this[Coordinate position]
        {
            get => grid[position.Y, position.X];
            set => grid[position.Y, position.X] = value;
        }
        public GameGrid(int height, int width)
        {
            if (height <= 0 || width <= 0)
                throw new ArgumentException("Grid dimensions must be positive!");
            this.grid = new int[height, width];
            GridHeight = height;
            GridWidth = width;
        }

        public int GetTileValue(int x, int y)
        {
            return grid[y, x];
        }

        public bool IsPositionEmpty(int x, int y)
        {
            return grid[y, x] == 0;
        }
    }
}
