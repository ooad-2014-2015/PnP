using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auto_Servis.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Auto_Servis.Models;

namespace Auto_Servis.ViewModel
{
    class VoziloViewModel 
    {
        public ICommand OdabirVozila { get; set; }
        public ICommand DodajVozilo { get; set; }
        public ICommand ObrisiVozilo { get; set; }
        public Action CloseAction { get; set; }

        private Vozilo vozilo;
        public Vozilo Vozilo
        {
            get { return vozilo; }
            set { vozilo = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<Vozilo> vozila; 
        public ObservableCollection<Vozilo> Vozila
        {
            get { return vozila; }
            set { vozila = value; OnPropertyChanged("Vozila"); }
        }

        public VoziloViewModel()
        {
            vozilo = new Vozilo();
            voziloZaBrisanje = new Vozilo();
            vozila = new ObservableCollection<Vozilo>();
            DodajVozilo = new RelayCommand(dodajVozilo);
            ObrisiVozilo = new RelayCommand(obrisiVozilo);
            Baza_podataka.BazaPodataka bp = new Baza_podataka.BazaPodataka();
            vozila = bp.dajVozila();
        }

        public void dodajVozilo(object parametar)
        {
            Baza_podataka.BazaPodataka bp = new Baza_podataka.BazaPodataka();
            bp.unesiVozilo(vozilo);
            vozila.Add(vozilo);
        }

        private Vozilo voziloZaBrisanje;

        public Vozilo VoziloZaBrisanje
        {
            get { return voziloZaBrisanje; }
            set { voziloZaBrisanje = value; OnPropertyChanged("VoziloZaBrisanje"); }
        }

        public void obrisiVozilo(object parameter)
        {
            Baza_podataka.BazaPodataka bp = new Baza_podataka.BazaPodataka();
            bp.obrisiVozilo(voziloZaBrisanje);
            MessageBox.Show(voziloZaBrisanje.Id.ToString());
            vozila.Remove(voziloZaBrisanje);
        }

    }
}
