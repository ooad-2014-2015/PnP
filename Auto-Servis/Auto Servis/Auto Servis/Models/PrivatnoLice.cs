using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class PrivatnoLice : Klijent
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public PrivatnoLice() : base() { }
    }
}
