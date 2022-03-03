
namespace SnakeGame
{

    public static class Program
    {
        public static void Main(string[] args)
        {
            var windowSize = 33;


            Console.SetWindowSize(90, 60);
            Console.SetBufferSize(90, 60);


            var p = new GameField(30, 20);
            Console.ReadKey();

 

        }
    }
}
