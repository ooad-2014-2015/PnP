using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auto_Servis.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace Auto_Servis.ViewModel
{
    class VoziloViewModel
    {
        public ICommand OdabirVozila { get; set; }
        public ICommand DodajVozilo { get; set; }
        public ICommand DajVozila { get; set; }
        public Action CloseAction { get; set; }

        private Vozilo vozilo;
        public Vozilo Vozilo
        {
            get { return vozilo; }
            set { vozilo = value; }
        }

        private List<Vozilo> vozila; // treba promijeniti na ObservableCollection
        public List<Vozilo> Vozila
        {
            get { return vozila; }
            set { vozila = value; }
        }

        public VoziloViewModel()
        {
            vozilo = new Vozilo();
            vozila = new List<Vozilo>();
            DodajVozilo = new RelayCommand(dodajVozilo);
            DajVozila = new RelayCommand(dajVozila);
        }
        public void dodajVozilo(object parametar)
        {
            Baza_podataka.BazaPodataka bp = new Baza_podataka.BazaPodataka();
            bp.unesiVozilo(vozilo);
        }

        public void dajVozila(object parameter)
        {
            Baza_podataka.BazaPodataka bp = new Baza_podataka.BazaPodataka();
            vozila = bp.dajVozila();
        }
    }
}
