using System.Diagnostics;


namespace SnakeGame
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            
            Console.SetWindowSize(60, 60);
            Console.SetBufferSize(60, 60);
            Console.CursorVisible = false;


            var snake = new Snake();
            var sw = new Stopwatch();

            snake.Draw();

            Direction currentMovement = Direction.Right;
            Console.BackgroundColor = ConsoleColor.Black;
            var food = new Food(snake);

            while (true)
            {
                sw.Restart();
                Direction oldMovement = currentMovement;

                while (sw.ElapsedMilliseconds < snake.Speed)
                {
                    if (currentMovement == oldMovement)
                        currentMovement = ReadMovement(currentMovement);
                }

                snake.Move(currentMovement);

                if (snake.ChekPosition())
                    break;

                if (snake.HeadPoint.X == food.Coardinate.X && snake.HeadPoint.Y == food.Coardinate.Y)
                {
                    snake.BodyPoints.Enqueue(snake.HeadPoint);
                    food = new Food(snake);
                }
                


            }
            
            GameField.Clean();
            Console.WriteLine("Game over");
            Console.ReadLine();

        }

        static Direction ReadMovement(Direction currentDirection)
        {
            if (!Console.KeyAvailable)
                return currentDirection;

            ConsoleKey key = Console.ReadKey(true).Key;

            currentDirection = key switch
            {
                ConsoleKey.UpArrow when currentDirection != Direction.Down => Direction.Up,
                ConsoleKey.DownArrow when currentDirection != Direction.Up => Direction.Down,
                ConsoleKey.LeftArrow when currentDirection != Direction.Right => Direction.Left,
                ConsoleKey.RightArrow when currentDirection != Direction.Left => Direction.Right,
                _ => currentDirection
            };

            return currentDirection;
        }
    }
}
