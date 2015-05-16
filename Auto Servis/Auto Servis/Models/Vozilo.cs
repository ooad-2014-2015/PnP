using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Vozilo
    {
        private string brojTablica;

        public string BrojTablica
        {
            get { return brojTablica; }
            set { brojTablica = value; }
        }

        enum Proizvodjaci { Volkswagen, Audi, Skoda, Seat };

        private Proizvodjaci proizvodjac;

        private Proizvodjaci Proizvodjac
        {
            get { return proizvodjac; }
            set { proizvodjac = value; }
        }

        private DateTime godinaProizvodnje;

        public DateTime GodinaProizvodnje
        {
            get { return godinaProizvodnje; }
            set { godinaProizvodnje = value; }
        }

        public Vozilo() { }
    }
}
