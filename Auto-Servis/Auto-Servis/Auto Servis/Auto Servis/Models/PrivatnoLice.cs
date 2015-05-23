using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Auto_Servis.Models
{
    public class PrivatnoLice : Klijent, INotifyPropertyChanged
    {

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public override string ToString()
        {
            return id + " " + base.ToString();
        }

        private string prikaz;

        public string Prikaz
        {
            get { return ToString(); }
            set { prikaz = value; OnPropertyChanged("Prikaz"); }
        }

        public PrivatnoLice() : base() { }
    }
}
