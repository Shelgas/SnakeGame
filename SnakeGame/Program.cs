
namespace SnakeGame
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var windowSize = 56;


            Console.SetWindowSize(windowSize, windowSize);
            Console.SetBufferSize(windowSize, windowSize);


            var p = new GameField(18, 18);
            Console.ReadKey();

 

        }
    }
}
