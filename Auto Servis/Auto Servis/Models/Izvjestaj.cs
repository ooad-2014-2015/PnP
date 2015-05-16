using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Izvjestaj
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime datumZavrsetkaRadova;

        public DateTime DatumZavrsetkaRadova
        {
            get { return datumZavrsetkaRadova; }
            set { datumZavrsetkaRadova = value; }
        }
    }
}
