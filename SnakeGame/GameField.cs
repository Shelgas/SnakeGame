using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class GameField
    {

        public Point[,] grid;

        public GameField(int width, int height)
        {
            grid = new Point[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    grid[i, j] = new Point(i, j);
                    if (i == 0 || i == width - 1 || j == 0 || j == height - 1) grid[i, j].Symbol = "▓";
                    grid[i, j].Draw();
                }
            }

        }

    }
}
