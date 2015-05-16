﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class SluzbenoLice : Klijent
    {
        private string nazivFirme;

        public string NazivFirme
        {
            get { return nazivFirme; }
            set { nazivFirme = value; }
        }

        private int idFirme;

        public int IdFirme
        {
            get { return idFirme; }
            set { idFirme = value; }
        }

        public SluzbenoLice() : base() { }
    }
}
