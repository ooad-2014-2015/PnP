using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_car_logo_Game
{
    public class Nivo
    {
        private int broj;

        public int Broj
        {
            get { return broj; }
            set { broj = value; }
        }

        private int tacanOdgovor;

        public int TacanOdgovor
        {
            get { return tacanOdgovor; }
            set { tacanOdgovor = value; }
        }

        private int rezultat;

        public int Rezultat
        {
            get { return rezultat; }
            set { rezultat = value; }
        }

        private string logo;

        public string Logo
        {
            get { return logo; }
            set { logo = value; }
        }

        public Nivo() { }
    }
}
