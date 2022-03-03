using System.Diagnostics;


namespace SnakeGame
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            
            Console.SetWindowSize(90, 60);
            Console.SetBufferSize(90, 60);
            Console.CursorVisible = false;


            //var filed = new GameField(30, 20);
            var snake = new Snake();
            var sw = new Stopwatch();

            snake.Draw();

            Direction currentMovement = Direction.Right;

            while (true)
            {
                sw.Restart();
                while(sw.ElapsedMilliseconds < snake.Speed)
                {

                }
                snake.Move();
            }

            Console.ReadKey();

        }
    }
}
