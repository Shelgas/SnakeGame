using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Point
    {
        private const int pixelSize = 3;
        public readonly int X;
        public readonly int Y;


        public ConsoleColor Color { get; set; }
        

        public Point(int x, int y)
        { 
            X = x;
            Y = y;
        }


        public Point(int x, int y, ConsoleColor color)
        {
            X = x;
            Y = y;
            Color = color;
        }


        public (int, int) GetCoordinate()
        {
            return new(X, Y);
        }
        
        public void Draw()
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    Console.SetCursorPosition(X * pixelSize + x, Y * pixelSize + y);
                    Console.BackgroundColor = Color;
                    Console.Write(' ');
                }
            }
        }

        public void Clean()
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    Console.SetCursorPosition(X * pixelSize + x, Y * pixelSize + y);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(' ');
                }
            }
        }

    }
}
