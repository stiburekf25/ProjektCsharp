namespace Piškvorky
{
    internal class Piškvorky
    {
        static char[,] pole = new char[3, 3];

        static void Main(string[] args)
        {
            for (int radek = 0; radek < 3; radek++)
            {
                for (int sloupec = 0; sloupec < 3; sloupec++)
                {
                    pole[radek, sloupec] = '.';
                }
            }

            Console.WriteLine("Vítej v piškvorkách, vyber si X nebo O");
            string UzivatelVyber = Console.ReadLine().ToUpper();

            while (UzivatelVyber != "X" && UzivatelVyber != "O")
            {
                Console.WriteLine("JAJ, zkus to znovu");
                UzivatelVyber = Console.ReadLine().ToUpper();
            }

            Console.WriteLine("Výborně, jdeme hrát :)");

            char hrac = UzivatelVyber[0];   // kdo je zrovna na tahu
            int pocetTahu = 0;

            while (true)
            {
                VykresliPole();
                Console.WriteLine("Hraje " + hrac);

                Console.WriteLine("vyber řádek (1-3)");
                int radekHrace = int.Parse(Console.ReadLine()) - 1;

                Console.WriteLine("vyber sloupec (1-3)");
                int sloupecHrace = int.Parse(Console.ReadLine()) - 1;

                // je políčko v poli?
                if (radekHrace < 0 || radekHrace > 2 || sloupecHrace < 0 || sloupecHrace > 2)
                {
                    Console.WriteLine("Takové políčko neexistuje, zkus to znovu");
                    continue;
                }

                // je políčko volné?
                if (pole[radekHrace, sloupecHrace] != '.')
                {
                    Console.WriteLine("Tohle políčko je obsazené, vyber jiné");
                    continue;
                }

                pole[radekHrace, sloupecHrace] = hrac;
                pocetTahu++;

                if (Vyhral(hrac))
                {
                    VykresliPole();
                    Console.WriteLine("Vyhrál " + hrac + "!");
                    break;
                }

                if (pocetTahu == 9)
                {
                    VykresliPole();
                    Console.WriteLine("Remíza!");
                    break;
                }

                // prohození hráče
                if (hrac == 'X')
                {
                    hrac = 'O';
                }
                else
                {
                    hrac = 'X';
                }
            }
        }

        static void VykresliPole()
        {
            for (int radek = 0; radek < 3; radek++)
            {
                for (int sloupec = 0; sloupec < 3; sloupec++)
                {
                    Console.Write(pole[radek, sloupec] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool Vyhral(char h)
        {
            for (int i = 0; i < 3; i++)
            {
                // řádek i
                if (pole[i, 0] == h && pole[i, 1] == h && pole[i, 2] == h) return true;
                // sloupec i
                if (pole[0, i] == h && pole[1, i] == h && pole[2, i] == h) return true;
            }

            // úhlopříčky
            if (pole[0, 0] == h && pole[1, 1] == h && pole[2, 2] == h) return true;
            if (pole[0, 2] == h && pole[1, 1] == h && pole[2, 0] == h) return true;

            return false;
        }
    }
}