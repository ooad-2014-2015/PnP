using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Popravka : INotifyPropertyChanged, IDataErrorInfo
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

        private bool zavrsena;
        public bool Zavrsena
        {
            get { return zavrsena; }
            set { zavrsena = value; OnPropertyChanged("Zavrsena"); }
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

        private string prikaz;
        public string Prikaz
        {
            get 
            { 
                return tipPopravke + " " + cijena + " " + vozilo.ToString();; 
            }
            set { prikaz = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public bool IsValid
        {
            get
            {
                foreach (string property in validateProperties)
                {
                    if (getValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        static readonly string[] validateProperties =
        {
            "Cijena","DatumPrijemaZahtjeva","TipPopravke","Vozilo","Mehanicar"
        };

        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }

        string getValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Cijena":
                    error = validirajCijenu();
                    break;
                case "TipPopravke":
                    error = validirajTip();
                    break;
                case "DatumPrijemaZahtjeva":
                    error = validirajDatumPrijema();
                    break;
                case "Vozilo":
                    error = validirajVozilo();
                    break;
                case "Mehanicar":
                    error = validirajMehanicara();
                    break;
            }
            return error;
        }

        private string validirajCijenu()
        {
            if (cijena <= 0) return "Cijena mora biti veca od 0!";
            return null;
        }

        private string validirajTip()
        {
            if (String.IsNullOrEmpty(tipPopravke)) return "Morate unijeti tip popravke!";
            return null;
        }

        private string validirajDatumPrijema()
        {
            if (datumPrijemaZahtjeva >= DateTime.Now) return "Morate unijeti datum u proslosti!";
            return null;
        }

        private string validirajVozilo()
        {
            if (Vozilo == null) return "Morate odabrati vozilo!";
            return null;
        }

        private string validirajMehanicara()
        {
            if (Mehanicar == null) return "Morate odabrati mehanicara";
            return null;
        }
    }
}
