namespace ProjektC_
{
    internal class Papousek
    {
        static void Main(string[] args)
        {

        Console.WriteLine("zadej něco :)");
            while (true)
            {
                string CoUzivatelNapsal = Console.ReadLine();


                if (CoUzivatelNapsal == "jsi debil?")
                {
                    Console.WriteLine("ne");
                }

                else if (CoUzivatelNapsal != "jsi debil?" && CoUzivatelNapsal != "Franta smrdi")
                {
                    Console.WriteLine(CoUzivatelNapsal);
                }

                if (CoUzivatelNapsal == "Franta smrdi")
                {
                    Console.WriteLine("ne, je to nadherný chlapec");
                    
                }
            }
            

        }
    }
}
