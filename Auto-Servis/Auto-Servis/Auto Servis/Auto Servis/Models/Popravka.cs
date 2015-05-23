using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Popravka : INotifyPropertyChanged
    {
        public Popravka()
        {
            tipovi = new List<string>();
            tipovi.Add("Limarijska");
            tipovi.Add("Elektronicka");
            tipovi.Add("Redovno odrzavanje");
            tipovi.Add("Veliki servis");
            tipovi.Add("Mehanicka");
            dijelovi = new ObservableCollection<Dio>();
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private double cijena;
        public double Cijena
        {
            get { return cijena; }
            set { cijena = value; OnPropertyChanged("Cijena"); }
        }

        private DateTime datumPrijemaZahtjeva;
        public DateTime DatumPrijemaZahtjeva
        {
            get { return datumPrijemaZahtjeva; }
            set { datumPrijemaZahtjeva = value; OnPropertyChanged("DatumPrijemaZahtjeva"); }
        }

        private List<string> tipovi;
        public List<string> Tipovi
        {
            get { return tipovi; }
            set { tipovi = value; }
        }

        public string tipPopravke;
        public string TipPopravke
        {
            get { return tipPopravke; }
            set { tipPopravke = value; OnPropertyChanged("TipPopravke"); }
        }

        private Zahtjev zahtjev;
        public Zahtjev Zahtjev
        {
            get { return zahtjev; }
            set { zahtjev = value; OnPropertyChanged("Zahtjev"); }
        }

        private Mehanicar mehanicar;
        public Mehanicar Mehanicar
        {
            get { return mehanicar; }
            set { mehanicar = value; OnPropertyChanged("Mehanicar"); }
        }

        private Vozilo vozilo;
        public Vozilo Vozilo
        {
            get { return vozilo; }
            set { vozilo = value; OnPropertyChanged("Vozilo"); }
        }

        private ObservableCollection<Dio> dijelovi;
        public ObservableCollection<Dio> Dijelovi
        {
            get { return dijelovi; }
            set { dijelovi = value; OnPropertyChanged("Dijelovi"); }
        }

        private string parts;
        public string Parts
        {
            get { return parts; }
            set { parts = value; OnPropertyChanged("Parts"); }
        }

        private DateTime datumZavrsetkaRadova;
        public DateTime DatumZavrsetkaRadova
        {
            get { return datumZavrsetkaRadova; }
            set { datumZavrsetkaRadova = value; OnPropertyChanged("DatumZavrsetkaRadova"); }
        }

        public override string ToString()
        {
            return "Popravka:" + id + " " + cijena + " " + datumPrijemaZahtjeva.ToShortDateString() + " Vozilo:" + vozilo.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
