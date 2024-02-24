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
        private readonly Tile[,] Grid;
        public Tile this[Vector2 position]
        {
            get => Grid[(int)position.X, (int)position.Y];
            set => Grid[(int)position.X, (int)position.Y] = value;
        }

        public Tile this[int xCoord, int yCoord]
        {
            get => Grid[xCoord, yCoord];
            set => Grid[(int)xCoord, (int)yCoord] = value;
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
            for (int y = 0; y < Rows+1; y++)
            {
                for (int x = 0; x < Columns+1; x++)
                {
                    Grid[x, y] = new Tile();
                    indexer.Y = y;
                    indexer.X = x;
                    Grid[x, y].SetPosition(indexer);
                    Grid[x, y].ColumnNumber = x;
                    Grid[x, y].RowNumber = y;
                    //Grid[i,j].Name = "Tile " + i.ToString() + j.ToString();
                    //Grid[i, j].PrintPosition();
                }
            }
        }

        public Tile GetSoldierTile(Soldier soldier)
        {
            return this[soldier.Position.CurrentPosition];
        }
    }
}
