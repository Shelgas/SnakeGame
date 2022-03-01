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
        private readonly int _x;
        private readonly int _y;
        public string Symbol { get; set; }
        

        public Point(int x, int y)
        { 
            _x = x;
            _y = y;
            Symbol = " ";
        }


        public (int, int) GetCoordinate()
        {
            return new(_x, _y);
        }
        
        public void Draw()
        {
            for (int x = 0; x < pixelSize; x++)
            {
                for (int y = 0; y < pixelSize; y++)
                {
                    Console.SetCursorPosition(_x*pixelSize + x, _y*pixelSize + y);
                    Console.Write(Symbol);
                }
            }
        }

    }
}
