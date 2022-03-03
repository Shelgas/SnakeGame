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
            HeadPoint = new Point(5, 4, ConsoleColor.White);
            BodyPoints = new Queue<Point>();
            BodyLegth = 3;
            Speed = 200;

            for (int i = BodyLegth; i >= 0; i--)
            {
                BodyPoints.Enqueue(new Point(HeadPoint.GetCoordinate().Item1 - i - 1,
                    HeadPoint.GetCoordinate().Item2, _snakeColor));
            }

            Draw();
        }


        public void Draw()
        {
            HeadPoint.Draw();
            foreach (Point p in BodyPoints) p.Draw();
        }

        public void Move(Direction direction)
        {
            BodyPoints.Peek().Clean();

            BodyPoints.Enqueue(new Point(HeadPoint.GetCoordinate().Item1,
               HeadPoint.GetCoordinate().Item2, _snakeColor));
            BodyPoints.Dequeue();


            HeadPoint = direction switch
            {
                Direction.Up when HeadPoint.Y > 0 => new Point(HeadPoint.X, HeadPoint.Y - 1 , _snakeColor),
                Direction.Up when HeadPoint.Y <= 0 => new Point(HeadPoint.X, 29, _snakeColor),
                Direction.Down when HeadPoint.Y < 29 => new Point(HeadPoint.X, HeadPoint.Y + 1, _snakeColor),
                Direction.Down when HeadPoint.Y >= 29 => new Point(HeadPoint.X, 0, _snakeColor),
                Direction.Left when HeadPoint.X == 0 => new Point(29, HeadPoint.Y, _snakeColor),
                Direction.Left when HeadPoint.X > 0 => new Point(HeadPoint.X - 1, HeadPoint.Y, _snakeColor),
                Direction.Right when HeadPoint.X < 29 => new Point(HeadPoint.X + 1, HeadPoint.Y, _snakeColor),
                Direction.Right when HeadPoint.X == 29 => new Point(0, HeadPoint.Y, _snakeColor),
                _ => throw new NotImplementedException(),
            };

            HeadPoint.Draw();
        }

 

        private Point GetLeftPoint(Point curentPoint)
        {
            if (curentPoint.X == 0)
                return new Point(30, curentPoint.Y);
            return new Point(curentPoint.X - 1, curentPoint.Y, _snakeColor);
        }

        private Point GetTopPoint(Point curentPoint)
        {
            if (curentPoint.Y >= 29)
                return new Point(0, curentPoint.Y);
            return new Point(curentPoint.X + 1, curentPoint.Y, _snakeColor);
        }
        private Point GetDownPoint(Point curentPoint)
        {
            if (curentPoint.X >= 29)
                return new Point(0, curentPoint.Y);
            return new Point(curentPoint.X + 1, curentPoint.Y, _snakeColor);
        }


        public void Clean()
        {
            HeadPoint.Clean();
            foreach (Point p in BodyPoints) p.Clean();
        }
    }
}
