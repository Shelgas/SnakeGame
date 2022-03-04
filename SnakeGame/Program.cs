using System.Diagnostics;


namespace SnakeGame
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            
            Console.SetWindowSize(57, 63);
            Console.SetBufferSize(57, 63);
            Console.CursorVisible = false;


            var snake = new Snake();
            var sw = new Stopwatch();

            snake.Draw();

            Direction currentMovement = Direction.Right;

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
            }

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
