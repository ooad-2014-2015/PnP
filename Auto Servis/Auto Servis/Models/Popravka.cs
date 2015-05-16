using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Popravka
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private double cijena;

        public double Cijena
        {
            get { return cijena; }
            set { cijena = value; }
        }

        enum TipoviPopravki { elektronicka, limarijska, redovnoOdrzavanje, mehanicka, velikiServis };

        private TipoviPopravki tipPopravke;

        private TipoviPopravki TipPopravke
        {
            get { return tipPopravke; }
            set { tipPopravke = value; }
        }

        public Popravka() { }
    }
}
