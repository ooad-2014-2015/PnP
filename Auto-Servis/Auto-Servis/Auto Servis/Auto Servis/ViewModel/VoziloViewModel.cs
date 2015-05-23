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

namespace Auto_Servis.ViewModel
{
    class VoziloViewModel : INotifyPropertyChanged
    {
        public ICommand OdabirVozila { get; set; }
        public ICommand DodajVozilo { get; set; }
        public ICommand ObrisiVozilo { get; set; }

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

        private ObservableCollection<PrivatnoLice> vlasniciPrivatni;
        public ObservableCollection<PrivatnoLice> VlasniciPrivatni
        {
            get { return vlasniciPrivatni; }
            set { vlasniciPrivatni = value; OnPropertyChanged("VlasniciPrivatni"); }
        }

        private ObservableCollection<SluzbenoLice> vlasniciSluzbeni;
        public ObservableCollection<SluzbenoLice> VlasniciSluzbeni
        {
            get { return vlasniciSluzbeni; }
            set { vlasniciSluzbeni = value; OnPropertyChanged("VlasniciSluzbeni"); }
        }

        public VoziloViewModel()
        {
            vozilo = new Vozilo();
            voziloZaBrisanje = new Vozilo();
            vozila = new ObservableCollection<Vozilo>();
            vlasniciPrivatni = new ObservableCollection<PrivatnoLice>();
            vlasniciSluzbeni = new ObservableCollection<SluzbenoLice>();
            DodajVozilo = new RelayCommand(dodajVozilo);
            ObrisiVozilo = new RelayCommand(obrisiVozilo);
            Baza_podataka.BazaPodataka bp = new Baza_podataka.BazaPodataka();
            vozila = bp.dajVozila();
            vlasniciPrivatni = bp.dajPrivatnaLica();
            vlasniciSluzbeni = bp.dajSluzbenaLica();
        }

        public void dodajVozilo(object parametar)
        {
            Baza_podataka.BazaPodataka bp = new Baza_podataka.BazaPodataka();
            if (vozilo.IsValid)
            {
                bp.unesiVozilo(vozilo);
                vozila.Add(vozilo);
            }
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
            vozila.Remove(voziloZaBrisanje);
        }

    }
}
