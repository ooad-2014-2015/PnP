using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Zahtjev
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime datumPrijema;

        public DateTime DatumPrijema
        {
            get { return datumPrijema; }
            set { datumPrijema = value; }
        }

        public Zahtjev() { }
    }
}
