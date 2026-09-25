namespace Piškvorky
{
    internal class Piškvorky
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vítej v piškvorkách, vyber si X nebo O");
            string UzivatelVyber = Console.ReadLine();

            if (UzivatelVyber == "X" || UzivatelVyber == "O")
                Console.WriteLine("Výborně, jdeme hrát :)");

            else if (UzivatelVyber != "X" || UzivatelVyber != "O")
                Console.WriteLine("JAJ, zkus to znovu");




        }
    }
}
