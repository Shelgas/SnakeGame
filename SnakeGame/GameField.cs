using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal static class GameField
    {

        //public static Point[,] grid;
        public static readonly int Width = 60;
        public static readonly int Height = 60;


        //private void DrowBoard()
        //{
        //    for (int i = 0; i < Width; i++)
        //    {
        //        for (int j = 0; j < Height; j++)
        //        {
        //            grid[i, j] = new Point(i, j);
        //            if (i == 0 || i == Width - 1 || j == 0 || j == Height - 1) grid[i, j].Color = ConsoleColor.White;
        //            grid[i, j].Draw();
        //        }
        //    }
        //}


        public static void Clean()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
