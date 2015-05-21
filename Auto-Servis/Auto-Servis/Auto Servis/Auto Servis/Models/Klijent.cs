using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Klijent : INotifyPropertyChanged
    {
        public Klijent()
        {

        }

        private string ime;
        public string Ime
        {
            get { return ime; }
            set { ime = value; OnPropertyChanged("Ime"); }
        }

        private string prezime;
        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; OnPropertyChanged("Prezime"); }
        }

        private string adresa;
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; OnPropertyChanged("Adresa"); }
        }

        private int brojTelefona;
        public int BrojTelefona
        {
            get { return brojTelefona; }
            set { brojTelefona = value; OnPropertyChanged("BrojTelefona"); }
        }

        public override string ToString()
        {
            return ime + " " + prezime; 
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
