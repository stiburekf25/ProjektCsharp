using Hra_VYS;

namespace _Hra_VYS
{
    class Program
    {
        static void Main(string[] args)
        {
            using var game = new Mojehra();
            game.Run();
        }
    }
}