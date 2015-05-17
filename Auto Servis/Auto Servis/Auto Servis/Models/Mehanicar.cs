using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Mehanicar
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

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

        public enum TipoviMehanicara { elektricar, limar, serviser, lakirer };

        public TipoviMehanicara tip;

        public TipoviMehanicara Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public Mehanicar() { }
    }
}
