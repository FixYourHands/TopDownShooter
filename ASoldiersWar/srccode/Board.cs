using ConsoleApp1.WarriorFight;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASoldiersWar
{
    public class Board
    {
        public int Rows { get; }
        public int Columns { get; }
        private Tile[,] Grid;
        public Tile this[Vector2 position]
        {
            get => Grid[(int)position.Y, (int)position.X];
            set => Grid[(int)position.Y, (int)position.X] = value;
        }

        public Tile this[int row, int column]
        {
            get => Grid[row, column];
            set => Grid[(int)row, (int)column] = value;
        }
        public Board(int rows, int columns)
        {
            this.Rows = rows-1;
            this.Columns = columns-1;
            this.Grid = new Tile[rows, columns];
            Initialize();
        }

        //sets the name of all the tiles in the board
        private void Initialize()
        {
            Vector2 indexer = new Vector2(0, 0);
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    Grid[i, j] = new Tile();
                    indexer.X = i;
                    indexer.Y = j;
                    Grid[i, j].SetPosition(indexer);
                    Grid[i,j].Name = "Tile " + i.ToString() + j.ToString();
                    //Grid[i, j].PrintPosition();
                }
            }
        }

    }
}
