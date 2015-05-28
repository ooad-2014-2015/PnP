using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Mehanicar : INotifyPropertyChanged
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

        private List<string> tipovi;
        public List<string> Tipovi
        {
            get { return tipovi; }
            set { tipovi = value; }
        }

        private string tip;
        public string Tip
        {
            get { return tip; }
            set { tip = value; OnPropertyChanged("Tip"); }
        }

        private string prikaz;
        public string Prikaz
        {
            get { return id.ToString() + " " + ime + " " + prezime + " " + tip; }
            set { prikaz = value; }
        }

        public override string ToString()
        {
            return id.ToString() + " " + ime + " " + prezime + " " + tip;
        }

        public Mehanicar()
        {
            tipovi = new List<string>();
            tipovi.Add("Elektricar");
            tipovi.Add("Limar");
            tipovi.Add("Serviser");
            tipovi.Add("Lakirer");
        }
    }
}
