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

        }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private float cijena;
        public float Cijena
        {
            get { return cijena; }
            set { cijena = value; OnPropertyChanged("Cijena"); }
        }

        public enum TipoviPopravki
        {
            Elektronicka,
            limarijska,
            RedovnoOdrzavanje,
            Mehanicka,
            VelikiServis,
        };

        private TipoviPopravki tipPopravke;
        public TipoviPopravki TipPopravke
        {
            get { return tipPopravke; }
            set { tipPopravke = value; OnPropertyChanged("TipPopravke"); }
        }

        Mehanicar mehanicar;
        internal Mehanicar Mehanicar
        {
            get { return mehanicar; }
            set { mehanicar = value; OnPropertyChanged("Mehanicar"); }
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
