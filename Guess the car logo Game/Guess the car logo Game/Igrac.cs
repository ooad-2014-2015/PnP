using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_car_logo_Game
{
    public class Igrac
    {
        private string naziv;

        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        private int najboljiRezultat;

        public int NajboljiRezultat
        {
            get { return najboljiRezultat; }
            set { najboljiRezultat = value; }
        }

        private int rezultat;

        public int Rezultat
        {
            get { return rezultat; }
            set { rezultat = value; }
        }

        public Igrac() { }
    }
}
