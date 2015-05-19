﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Auto_Servis.Models
{
    public class Vozilo : INotifyPropertyChanged
    {
        public Vozilo()
        {
            proizvodjaci = new List<string>();
            proizvodjaci.Add("Volkswagen");
            proizvodjaci.Add("Audi");
            proizvodjaci.Add("Skoda");
            proizvodjaci.Add("Seat");
        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string brojTablica;
        public string BrojTablica
        {
            get { return brojTablica; }
            set { brojTablica = value; OnPropertyChanged("BrojTablica"); }
        }

        private List<string> proizvodjaci;

        public List<string> Proizvodjaci
        {
            get { return proizvodjaci; }
            set { proizvodjaci = value; }
        }

        private string proizvodjac;

        public string Proizvodjac
        {
            get { return proizvodjac; }
            set { proizvodjac = value; OnPropertyChanged("Proizvodjac"); }
        }

        private DateTime godinaProizvodnje;
        public DateTime GodinaProizvodnje
        {
            get { return godinaProizvodnje; }
            set { godinaProizvodnje = value; OnPropertyChanged("GodinaProizvodnje"); }
        }

        Zahtjev zahtjev;
        internal Zahtjev Zahtjev
        {
            get { return zahtjev; }
            set { zahtjev = value; OnPropertyChanged("Zahtjev"); }
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