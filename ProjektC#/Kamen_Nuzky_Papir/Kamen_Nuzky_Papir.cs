namespace Kamen_Nuzky_Papir
{
    internal class Kamen_Nuzky_Papir
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vítej ve hře, kámen nůžky papír");
            Console.WriteLine("Zadej svůj výběr: rock, scissors nebo paper");

            string VyberUzivatele = Console.ReadLine();


            if (VyberUzivatele == "paper" || VyberUzivatele == "rock" || VyberUzivatele == "scissors")
            {
                Console.WriteLine("Vybral jsi: " + VyberUzivatele);
            }
            else
            {
                Console.WriteLine("Neplatný výběr, zkus to znovu.");
            }


        }
    }
}
