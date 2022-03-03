using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    internal class Snake
    {
        public int BodyLegth { get; set; }
        public Point HeadPoint { get; set; }
        public Queue<Point> BodyPoints { get; set; }
        public int Speed { get; set; }

        private ConsoleColor _snakeColor = ConsoleColor.White;

        public Snake()
        {
            HeadPoint = new Point(6, 4, ConsoleColor.White);
            BodyPoints = new Queue<Point>();
            BodyLegth = 3;
            Speed = 300;

            for (int i = BodyLegth; i >= 0; i--)
            {
                BodyPoints.Enqueue(new Point(HeadPoint.GetCoordinate().Item1 - i - 1, 4, _snakeColor));
            }

            Draw();
        }


        public void Draw()
        {
            HeadPoint.Draw();
            foreach (Point p in BodyPoints) p.Draw();
        }

        public void Move()
        {
            BodyPoints.Peek().Clean();

            BodyPoints.Enqueue(new Point(HeadPoint.GetCoordinate().Item1, 
                HeadPoint.GetCoordinate().Item2, _snakeColor));
            BodyPoints.Dequeue();   
            HeadPoint = new Point(HeadPoint.GetCoordinate().Item1 + 1,
                HeadPoint.GetCoordinate().Item2, _snakeColor);
            Draw();
        }

        public void Clean()
        {
            HeadPoint.Clean();
            foreach (Point p in BodyPoints) p.Clean();
        }
    }
}
