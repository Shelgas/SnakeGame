using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SnakeGame
{
    internal class Food
    {

        public readonly Point CoardinateFood;

        public Food(Snake snake)
        {

            var rnd = new Random();
            do
            {
                CoardinateFood = new Point(rnd.Next(0, GameField.Width - 1), rnd.Next(1, GameField.Height - 1), ConsoleColor.Green);
            } while (snake.HeadPoint.X == CoardinateFood.X && snake.HeadPoint.Y == CoardinateFood.Y ||
                     snake.BodyPoints.Any(b => b.X == CoardinateFood.X && b.Y == CoardinateFood.Y));
        }

    }
}
