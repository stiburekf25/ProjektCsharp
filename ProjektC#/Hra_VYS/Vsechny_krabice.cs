using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hra_VYS
{
    internal class Vsechny_krabice
    {


        private Krabice[] _krabice;

        public Vsechny_krabice(int pocet)
        {
            _krabice = new Krabice[pocet];

            for (int i = 0; i < pocet; i++)
            {
                _krabice[i] = new Krabice();
            }
        }

        public void VykreslitKrabice(SpriteBatch spriteBatch, Texture2D pixel)
        {

            for (int i = 0; i < _krabice.Length; i++)
            {
            spriteBatch.Draw(pixel, new Rectangle(_krabice[i].pozice_krabice_x, _krabice[i].pozice_krabice_y, _krabice[i].velikost_krabice_x, _krabice[i].velikost_krabice_y), Color.Blue);
            }

        }

    }
}
