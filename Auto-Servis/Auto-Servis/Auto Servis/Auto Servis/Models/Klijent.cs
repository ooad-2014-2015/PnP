using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Klijent : INotifyPropertyChanged, IDataErrorInfo
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

        protected internal static readonly string[] validateProperties =
        {
            "Ime","Prezime","Adresa", "BrojTelefona"
        };

        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }

        protected internal string getValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Ime":
                    error = validirajString(ime);
                    break;
                case "Prezime":
                    error = validirajString(prezime);
                    break;
                case "Adresa":
                    error = validirajString(adresa);
                    break;
                case "BrojTelefona":
                    error = validirajBroj();
                    break;
            }
            return error;
        }

        protected internal string validirajString(string parametar)
        {
            if (String.IsNullOrEmpty(parametar)) return "Polje mora biti uneseno!";
            return null;
        }

        protected internal string validirajBroj()
        {
            if (brojTelefona.ToString().Length < 8 || brojTelefona.ToString().Length > 9) return "Mora imati 8 ili 9 cifara!";
            return null;
        }

    }
}
