using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auto_Servis.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Auto_Servis.ViewModel
{
    class VoziloViewModel
    {
        public ICommand OdabirVozila { get; set; }
        public ICommand DodajVozilo { get; set; }
        public Action CloseAction { get; set; }

        private Vozilo vozilo;
        public Vozilo Vozilo
        {
            get { return vozilo; }
            set { vozilo = value; }
        }

        public VoziloViewModel()
        {
            vozilo = new Vozilo();
            DodajVozilo = new RelayCommand(dodajVozilo);
        }
        public void dodajVozilo(object parametar)
        {
            Baza_podataka.BazaPodataka bp = new Baza_podataka.BazaPodataka();
            bp.unesiVozilo(vozilo);
            //CloseAction(); ovo nesto nece da radi
        }
    }
}
