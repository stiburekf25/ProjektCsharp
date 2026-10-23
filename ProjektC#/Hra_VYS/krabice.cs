using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra_VYS
{
    internal class Krabice
    {



        public int pozice_krabice_x { get; private set; }
        public int pozice_krabice_y { get; private set; }

        public int velikost_krabice_x { get; private set; } = 50;

        public int velikost_krabice_y { get; private set; } = 50;


        Random nahoda = new Random();

        


        public Krabice()
        {
            pozice_krabice_x = nahoda.Next(1 + velikost_krabice_x, 1600 - velikost_krabice_y);
            pozice_krabice_y = nahoda.Next(1 + velikost_krabice_x, 900) - velikost_krabice_y;

    
            
        }


    }
}
