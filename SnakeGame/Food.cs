using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SnakeGame
{
    internal class Food
    {

        public readonly Point Coardinate;

        public Food(Snake snake)
        {

            var rnd = new Random();
            do
            {
                Coardinate = new Point(rnd.Next(0, GameField.Width/3 - 1), rnd.Next(1, GameField.Height/3 - 1), ConsoleColor.Green);
            } while (snake.HeadPoint.X == Coardinate.X && snake.HeadPoint.Y == Coardinate.Y ||
                     snake.BodyPoints.Any(b => b.X == Coardinate.X && b.Y == Coardinate.Y));
            Coardinate.Draw();
        }

    }
}
