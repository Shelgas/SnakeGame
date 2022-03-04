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
        public Queue<Point> BodyPoints { get; private set; }
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
                Direction.Up when HeadPoint.Y <= 0 => new Point(HeadPoint.X, GameField.Height / 3 - 1, _snakeColor),
                Direction.Down when HeadPoint.Y < GameField.Height/3 - 1 => new Point(HeadPoint.X, HeadPoint.Y + 1, _snakeColor),
                Direction.Down when HeadPoint.Y >= GameField.Height / 3 - 1 => new Point(HeadPoint.X, 0, _snakeColor),
                Direction.Left when HeadPoint.X == 0 => new Point(GameField.Width / 3 - 1, HeadPoint.Y, _snakeColor),
                Direction.Left when HeadPoint.X > 0 => new Point(HeadPoint.X - 1, HeadPoint.Y, _snakeColor),
                Direction.Right when HeadPoint.X < GameField.Width / 3 -1 => new Point(HeadPoint.X + 1, HeadPoint.Y, _snakeColor),
                Direction.Right when HeadPoint.X == GameField.Width / 3  - 1=> new Point(0, HeadPoint.Y, _snakeColor),
                _ => throw new NotImplementedException(),
            };

            HeadPoint.Draw();
        }

 
        public bool ChekPosition()
        {
            if (BodyPoints.Any(x => x.X == HeadPoint.X && x.Y == HeadPoint.Y))
                return true;
            return false;
        }


        public void Clean()
        {
            HeadPoint.Clean();
            foreach (Point p in BodyPoints) p.Clean();
        }
    }
}
