using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Klijent
    {
        private string ime;

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        private string prezime;

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        private string adresa;

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }

        private string brojTelefona;

        public string BrojTelefona
        {
            get { return brojTelefona; }
            set { brojTelefona = value; }
        }

        public Klijent() { }

    }
}
