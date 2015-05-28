using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auto_Servis.Models;
using Auto_Servis.Baza_podataka;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace Auto_Servis.ViewModel
{
    public class PopravkaViewModel : INotifyPropertyChanged
    {
        public ICommand DodajPopravku { get; set; }
        public ICommand UkloniPopravku { get; set; }
        public ICommand DodajDio { get; set; }
        public ICommand PromijeniPodatke { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private Popravka popravka;
        public Popravka Popravka
        {
            get { return popravka; }
            set { popravka = value; OnPropertyChanged("Popravka"); }
        }

        private Popravka selektovanaPopravka;
        public Popravka SelektovanaPopravka
        {
            get { return selektovanaPopravka; }
            set { selektovanaPopravka = value; OnPropertyChanged("SelektovanaPopravka"); }
        }

        private ObservableCollection<Popravka> popravke;
        public ObservableCollection<Popravka> Popravke
        {
            get { return popravke; }
            set { popravke = value; OnPropertyChanged("Popravke"); }
        }

        private BazaPodataka baza;

        private ObservableCollection<Vozilo> vozila;
        public ObservableCollection<Vozilo> Vozila
        {
            get { return vozila; }
            set { vozila = value; OnPropertyChanged("Vozila"); }
        }

        public void dodajPopravku(object parameter)
        {
            foreach (Popravka p in popravke) if (p == popravka) return;
            if (popravka.IsValid)
            {
                baza.unesiPopravku(popravka);
                popravke.Add(popravka);
            }
            else MessageBox.Show("Niste unijeli ispravne podatke");
        }

        public void ukloniPopravku(object parameter)
        {
            baza.obrisiPopravku(selektovanaPopravka);
            popravke.Remove(selektovanaPopravka);
        }

        private ObservableCollection<Dio> dijelovi;
        public ObservableCollection<Dio> Dijelovi
        {
            get { return dijelovi; }
            set { dijelovi = value; OnPropertyChanged("Dijelovi"); }
        }

        private Dio dioZaDodati;
        public Dio DioZaDodati
        {
            get { return dioZaDodati; }
            set { dioZaDodati = value; OnPropertyChanged("DioZaDodati"); }
        }


        private ObservableCollection<Mehanicar> mehanicari;
        public ObservableCollection<Mehanicar> Mehanicari
        {
            get { return mehanicari; }
            set { mehanicari = value; OnPropertyChanged("Mehanicari"); }
        }

        public void dodajDio(object parameter)
        {
            popravka.Dijelovi.Add(dioZaDodati);
            popravka.Parts += dioZaDodati.ToString();
            popravka.Parts += "\n";
        }

        public void promijeniPodatke(object parameter)
        {
            baza.updatePopravke(selektovanaPopravka);
            MessageBox.Show("Postavili ste datum zavrsetka radova!");
        }

        public PopravkaViewModel()
        {
            baza = new BazaPodataka();
            DodajPopravku = new RelayCommand(dodajPopravku);
            UkloniPopravku = new RelayCommand(ukloniPopravku);
            DodajDio = new RelayCommand(dodajDio);
            PromijeniPodatke = new RelayCommand(promijeniPodatke);
            popravka = new Popravka();
            selektovanaPopravka = new Popravka();
            popravke = new ObservableCollection<Popravka>();
            popravke = baza.dajPopravke();
            vozila = new ObservableCollection<Vozilo>();
            vozila = baza.dajVozila();
            dijelovi = new ObservableCollection<Dio>();
            dijelovi = baza.dajDijelove();
            dioZaDodati = new Dio();
            mehanicari = new ObservableCollection<Mehanicar>();
            mehanicari = baza.dajMehanicare();
            if (mehanicari.Count == 0) MessageBox.Show("Nema nista");
        }

    }
}
