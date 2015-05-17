using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Vozilo
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string brojTablica;

        public string BrojTablica
        {
            get { return brojTablica; }
            set { brojTablica = value; }
        }

        public enum Proizvodjaci { Volkswagen, Audi, Skoda, Seat };

        public Proizvodjaci proizvodjac;

        public Proizvodjaci Proizvodjac
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
