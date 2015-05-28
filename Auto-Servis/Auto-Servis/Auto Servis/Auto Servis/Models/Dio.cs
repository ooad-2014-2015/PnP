using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Dio : INotifyPropertyChanged, IDataErrorInfo
    {
        public Dio()
        {

        }

        private string naziv;
        public string Naziv
        {
            get { return naziv; }
            set { naziv = value; OnPropertyChanged("Naziv"); }
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

        private int kolicina;
        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; OnPropertyChanged("Kolicina"); }
        }

        public override string ToString()
        {
            return "Naziv:" + naziv + " Cijena:" + cijena + " Kolicina:" + kolicina;
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
            "Naziv","Cijena","Kolicina"
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
                case "Naziv":
                    error = validirajNaziv();
                    break;
                case "Cijena":
                    error = validirajCijenu();
                    break;
                case "Kolicina":
                    error = validirajKolicinu();
                    break;
            }
            return error;
        }

        string validirajNaziv()
        {
            if(String.IsNullOrEmpty(naziv)) return "Morate unijeti naziv!";
            else return null;
        }

        string validirajCijenu()
        {
            if (cijena <= 0) return "Cijena ne moze biti manja ili jednaka 0!";
            return null;
        }

        string validirajKolicinu()
        {
            if(kolicina < 0) return "Kolicina ne smije biti manja od 0!";
            return null;
        }
    }
}
