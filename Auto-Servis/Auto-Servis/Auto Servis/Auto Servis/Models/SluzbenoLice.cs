using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Auto_Servis.Models
{
    public class SluzbenoLice : Klijent, INotifyPropertyChanged
    {
        private string nazivFirme;
        public string NazivFirme
        {
            get { return nazivFirme; }
            set { nazivFirme = value; OnPropertyChanged("NazivFirme"); }
        }

        private int idFirme;
        public int IdFirme
        {
            get { return idFirme; }
            set { idFirme = value; OnPropertyChanged("IdFirme"); }
        }

        public override string ToString()
        {
            return idFirme + " " + nazivFirme + " " + base.ToString();
        }

        public SluzbenoLice() : base() { }
    }
}
