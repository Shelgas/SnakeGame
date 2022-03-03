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

        public Snake()
        {
            HeadPoint = new Point(6, 4, ConsoleColor.White);
            BodyPoints = new Queue<Point>();
            BodyLegth = 3;

            for (int i = BodyLegth; i >= 0; i--)
            {
                BodyPoints.Enqueue(new Point(HeadPoint.GetCoordinate().Item1 - i - 1, 4, ConsoleColor.White));
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
            Clean();

            BodyPoints.Enqueue(new Point(HeadPoint.GetCoordinate().Item1, HeadPoint.GetCoordinate().Item2, ConsoleColor.White));
            BodyPoints.Dequeue();   
            HeadPoint = new Point(HeadPoint.GetCoordinate().Item1 + 1, HeadPoint.GetCoordinate().Item2, ConsoleColor.White);
            Draw();
        }

        public void Clean()
        {
            HeadPoint.Clean();
            foreach (Point p in BodyPoints) p.Clean();
        }
    }
}
