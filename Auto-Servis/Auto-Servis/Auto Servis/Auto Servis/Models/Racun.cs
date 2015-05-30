using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Racun : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private double ukupnaCijena;
        public double UkupnaCijena
        {
            get 
            {
                List<int> brojevi = new List<int>();
                string broj = string.Empty;
                int vrijednost;
                double cijena = popravka.Cijena;
                for (int i = 0; i < popravka.Parts.Length; i++)
                {
                    if (Char.IsDigit(popravka.Parts[i]))
                    {
                        broj = string.Empty;
                        int index = i;
                        while (Char.IsDigit(popravka.Parts[index]))
                        {
                            broj += popravka.Parts[index];
                            index++;  
                        }
                        if (broj.Length > 0)
                        {
                            vrijednost = int.Parse(broj);
                            brojevi.Add(vrijednost);
                        }
                        i += broj.Length;
                    }
                }
                for (int j = 0; j < brojevi.Count; j += 2)
                {
                    int tempCijena = brojevi[j] * brojevi[j + 1];
                    cijena += tempCijena;
                }
                return cijena;
            }
            set { ukupnaCijena = value; OnPropertyChanged("UkupnaCijena"); }
        }

        private DateTime datumIzdavanja;
        public DateTime DatumIzdavanja
        {
            get { return datumIzdavanja; }
            set { datumIzdavanja = value; OnPropertyChanged("DatumIzdavanja"); }
        }

        private Popravka popravka;
        public Popravka Popravka
        {
            get { return popravka; }
            set { popravka = value; OnPropertyChanged("Popravka"); }
        }

        private string prikaz;
        public string Prikaz
        {
            get { return prikaz; }
            set { prikaz = value; OnPropertyChanged("Prikaz"); }
        }

        public void isprintaj()
        {
            // treba implementirati
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
            "Popravka"
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
                case "Popravka":
                    error = validirajPopravku();
                    break;
            }
            return error;
        }

        private string validirajPopravku()
        {
            if (popravka == null) return "Morate odabrati popravku za koju zelite generisati racun!";
            return null;
        }

        public Racun() { }
    }
}
