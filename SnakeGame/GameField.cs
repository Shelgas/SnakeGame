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
        private readonly int _width;
        private readonly int _height;

        public GameField(int width, int height)
        {
            grid = new Point[width, height];
            _height = height;
            _width = width;
            //DrowBoard();
            var s = new Snake();
            s.Draw();
            s.Move();
            s.Move();
            s.Move();
            s.Move();
            s.Move();
        }

        private void DrowBoard()
        {
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    grid[i, j] = new Point(i, j);
                    if (i == 0 || i == _width - 1 || j == 0 || j == _height - 1) grid[i, j].Color = ConsoleColor.White;
                    grid[i, j].Draw();
                }
            }
        }

    }
}
