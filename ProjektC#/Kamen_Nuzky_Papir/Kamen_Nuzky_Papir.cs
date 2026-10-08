namespace Kamen_Nuzky_Papir
{
    internal class Kamen_Nuzky_Papir
    {
        static void Main(string[] args)
        {
            bool vyber = true;

            Console.WriteLine("Vítej ve hře, kámen nůžky papír");
            Console.WriteLine("Zadej svůj výběr: rock, scissors nebo paper");

            string VyberUzivatele = Console.ReadLine().ToLower();

            while (vyber)
            {
                if (VyberUzivatele == "paper" || VyberUzivatele == "rock" || VyberUzivatele == "scissors")
                {
                    vyber = false;
                    Console.WriteLine("Vybral jsi: " + VyberUzivatele);
                }
                else
                {
                    Console.WriteLine("Neplatný výběr, zkus to znovu.");
                    VyberUzivatele = Console.ReadLine().ToLower();
                }
            }

            // náhodný výběr počítače
            string[] moznosti = { "rock", "scissors", "paper" };
            Random rnd = new Random();
            string VyberPocitace = moznosti[rnd.Next(3)];

            Console.WriteLine("Počítač vybral: " + VyberPocitace);

            // porovnání
            if (VyberUzivatele == VyberPocitace)
            {
                Console.WriteLine("Remíza!");
            }
            else if ((VyberUzivatele == "rock" && VyberPocitace == "scissors") ||
                     (VyberUzivatele == "scissors" && VyberPocitace == "paper") ||
                     (VyberUzivatele == "paper" && VyberPocitace == "rock"))
            {
                Console.WriteLine("Vyhrál jsi!");
            }
            else
            {
                Console.WriteLine("Prohrál jsi!");
            }
        }
    }
}