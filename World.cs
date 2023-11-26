using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Maze_Game
{
    class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);

        }

        public void Draw()
        {
            for(int x = 0; x < Rows; x++)
            {
                for(int y = 0; y < Cols; y++)
                {
                    string element = Grid[x, y];
                    SetCursorPosition(y, x);
                    Write(element);
                }
            }
        }

        public string GetElementAt(int x, int y)
        {
            return Grid[y,x];
        }
        internal bool IsPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x>= Rows || y>= Cols)
            {
                return false;
            }
            return Grid[y, x] == " " || Grid[y, x] == "X";
        }
        
           
        
    }
}
