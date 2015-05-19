using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Izvjestaj : INotifyPropertyChanged
    {
        public Izvjestaj()
        {

        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private DateTime datumZavrsetkaRadova;
        public DateTime DatumZavrsetkaRadova
        {
            get { return datumZavrsetkaRadova; }
            set { datumZavrsetkaRadova = value; OnPropertyChanged("DatumZavrsetkaRadova"); }
        }

        public void prikazi()
        {
            // fali implementacija
        }

        Zahtjev zahtjev;
        internal Zahtjev Zahtjev
        {
            get { return zahtjev; }
            set { zahtjev = value; OnPropertyChanged("Zahtjev"); }
        }

        Racun racun;
        internal Racun Racun
        {
            get { return racun; }
            set { racun = value; OnPropertyChanged("Racun"); }
        }

        Dio dio;
        internal Dio Dio
        {
            get { return dio; }
            set { dio = value; OnPropertyChanged("Dio"); }
        }

        Popravka popravka;
        internal Popravka Popravka
        {
            get { return popravka; }
            set { popravka = value; OnPropertyChanged("Popravka"); }
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
