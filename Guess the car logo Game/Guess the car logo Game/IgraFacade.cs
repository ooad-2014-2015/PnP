using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guess_the_car_logo_Game
{
    public class IgraFacade
    {
        private Igrac igrac;

        public Igrac Igrac
        {
            get { return igrac; }
            set { igrac = value; }
        }

        private Nivo nivo;

        public Nivo Nivo
        {
            get { return nivo; }
            set { nivo = value; }
        }

        private Tezina tezina;

        public Tezina Tezina
        {
            get { return tezina; }
            set { tezina = value; }
        }

        private List<int> rezultati;

        public List<int> Rezultati
        {
            get { return rezultati; }
            set { rezultati = value; }
        }

        public IgraFacade() 
        {
            igrac = new Igrac();
            nivo = new Nivo();
            tezina = new Tezina();
            rezultati = new List<int>();
        }
    }
}
