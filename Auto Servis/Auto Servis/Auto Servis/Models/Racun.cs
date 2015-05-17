using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Racun
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private double ukupnaCijena;

        public double UkupnaCijena
        {
            get { return ukupnaCijena; }
            set { ukupnaCijena = value; }
        }

        private DateTime datumIzdavanja;

        public DateTime DatumIzdavanja
        {
            get { return datumIzdavanja; }
            set { datumIzdavanja = value; }
        }

        public Racun() { }
    }
}
