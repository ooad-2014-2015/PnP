using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Auto_Servis.Models;
using Auto_Servis.Baza_podataka;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Auto_Servis.View;

namespace Auto_Servis.ViewModel
{
    public class PopravkaViewModel : INotifyPropertyChanged
    {
        private static Thread nitUnos, nitBrisanje;
        private FormaPopravka fPopravka;
        public FormaPopravka FPopravka
        {
            get { return fPopravka; }
            set { fPopravka = value; }
        }

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
                nitUnos = new Thread(() => baza.unesiPopravku(popravka));
                nitUnos.IsBackground = true;
                nitUnos.Start();
                popravke.Add(popravka);
                if (MessageBoxResult.OK == MessageBox.Show("Unijeli ste popravku"))
                {
                    fPopravka.Close();
                    FormaPopravka Nova = new FormaPopravka();
                    Nova.Show();
                }
            }
            else MessageBox.Show("Niste unijeli ispravne podatke");
        }

        public void ukloniPopravku(object parameter)
        {
            nitBrisanje = new Thread(() => baza.obrisiPopravku(selektovanaPopravka));
            nitBrisanje.IsBackground = true;
            nitBrisanje.Start();
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
            selektovanaPopravka.Zavrsena = true;
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
        }

    }
}
