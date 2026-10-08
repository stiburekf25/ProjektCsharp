namespace Sibenice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vítej ve hře, šibenice");
            Console.WriteLine("Vyber kategorii: Zvířata, Země, Ovoce");
            string vyber_hrace = Console.ReadLine().ToLower();

            // podle kategorie vybereme soubor se slovy
            string soubor = "";
            while (soubor == "")
            {
                if (vyber_hrace == "zvířata" || vyber_hrace == "zvirata")
                {
                    soubor = "zvirata.txt";
                }
                else if (vyber_hrace == "země" || vyber_hrace == "zeme")
                {
                    soubor = "zeme.txt";
                }
                else if (vyber_hrace == "ovoce")
                {
                    soubor = "ovoce.txt";
                }
                else
                {
                    Console.WriteLine("Taková kategorie není, zkus to znovu");
                    vyber_hrace = Console.ReadLine().ToLower();
                }
            }

            // načtení slov ze souboru a náhodný výběr jednoho z nich
            string[] slova = File.ReadAllLines(soubor);
            Random rnd = new Random();
            string slovo = slova[rnd.Next(slova.Length)].Trim().ToLower();

            // odhalené slovo - na začátku samá podtržítka
            char[] odhalene = new char[slovo.Length];
            for (int i = 0; i < slovo.Length; i++)
            {
                odhalene[i] = '_';
            }

            List<char> hadanaPismena = new List<char>();
            int chyby = 0;
            int maxChyby = 6;
            bool vyhral = false;

            while (chyby < maxChyby)
            {
                VykresliSibenici(chyby);

                // vypsání slova s mezerami: _ _ a _ _
                for (int i = 0; i < odhalene.Length; i++)
                {
                    Console.Write(odhalene[i] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("Hádaná písmena: " + string.Join(", ", hadanaPismena));
                Console.WriteLine("Zbývá pokusů: " + (maxChyby - chyby));

                Console.WriteLine("Hádej písmeno:");
                string vstup = Console.ReadLine().ToLower();

                if (vstup.Length != 1)
                {
                    Console.WriteLine("Zadej jen jedno písmeno.");
                    continue;
                }

                char pismeno = vstup[0];

                if (hadanaPismena.Contains(pismeno))
                {
                    Console.WriteLine("Tohle písmeno už jsi zkoušel.");
                    continue;
                }

                hadanaPismena.Add(pismeno);

                // odhalení všech výskytů písmena ve slově
                bool trefa = false;
                for (int i = 0; i < slovo.Length; i++)
                {
                    if (slovo[i] == pismeno)
                    {
                        odhalene[i] = pismeno;
                        trefa = true;
                    }
                }

                if (trefa)
                {
                    Console.WriteLine("Správně!");
                }
                else
                {
                    Console.WriteLine("Vedle!");
                    chyby++;
                }

                // když už ve slově nejsou podtržítka, hráč vyhrál
                if (new string(odhalene) == slovo)
                {
                    vyhral = true;
                    break;
                }
            }

            VykresliSibenici(chyby);

            if (vyhral)
            {
                Console.WriteLine("Vyhrál jsi! Slovo bylo: " + slovo);
            }
            else
            {
                Console.WriteLine("Prohrál jsi! Slovo bylo: " + slovo);
            }
        }

        static void VykresliSibenici(int chyby)
        {
            string[] obrazky =
            {
                "  +---+\n  |   |\n      |\n      |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n      |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n  |   |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|   |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n      |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n /    |\n      |\n=========",
                "  +---+\n  |   |\n  O   |\n /|\\  |\n / \\  |\n      |\n========="
            };

            Console.WriteLine();
            Console.WriteLine(obrazky[chyby]);
            Console.WriteLine();
        }
    }
}