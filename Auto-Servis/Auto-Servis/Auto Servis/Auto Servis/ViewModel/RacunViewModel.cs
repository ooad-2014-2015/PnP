using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Auto_Servis.Models;
using Auto_Servis.Baza_podataka;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using Auto_Servis.View;

namespace Auto_Servis.ViewModel 
{
    public class RacunViewModel : INotifyPropertyChanged
    {
        private FormaRacun fRacun;
        public FormaRacun FRacun
        {
            get { return fRacun; }
            set { fRacun = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand GenerisiRacun { get; set; }
        public ICommand ObrisiRacun { get; set; }

        private Baza_podataka.BazaPodataka baza;
        public Baza_podataka.BazaPodataka Baza
        {
            get { return baza; }
            set { baza = value; }
        }

        private Racun racun;
        public Racun Racun
        {
            get { return racun; }
            set { racun = value; OnPropertyChanged("Racun"); }
        }

        private Racun selektovaniRacun;
        public Racun SelektovaniRacun
        {
            get { return selektovaniRacun; }
            set { selektovaniRacun = value; OnPropertyChanged("SelektovaniRacun"); }
        }

        private ObservableCollection<Racun> racuni;
        public ObservableCollection<Racun> Racuni
        {
            get { return racuni; }
            set { racuni = value; OnPropertyChanged("Racuni"); }
        }

        private ObservableCollection<Popravka> popravke;
        public ObservableCollection<Popravka> Popravke
        {
            get { return popravke; }
            set { popravke = value; OnPropertyChanged("Popravke"); }
        }

        public void generisiRacun(object parameter)
        {
            racun.DatumIzdavanja = DateTime.Now;
            if (racun.Popravka == null) MessageBox.Show("Popravka nije postavljena");
            foreach (Racun r in racuni) if (r == racun) return;
            if (racun.IsValid)
            {
                baza.unesiRacun(racun);
                racuni.Add(racun);
                //MessageBox.Show(racun.Popravka.Parts);
                string r = "Datum izdavanja: " + racun.DatumIzdavanja.ToString() + "\n";
                r += "Popravka: " + racun.Popravka.TipPopravke + " " + racun.Popravka.Cijena + "\nDijelovi: ";
                r += racun.Popravka.Parts;
                r += "---------------------------------------------\n";
                r += "Ukupno: " + racun.UkupnaCijena + " KM";
                racun.Prikaz = r;
                if (MessageBoxResult.OK == MessageBox.Show("Generisali ste racun!"))
                {
                    fRacun.Close();
                    FormaRacun Nova = new FormaRacun();
                    Nova.Show();
                }
            }
        }

        private void obrisiRacun(object parameter)
        {
            baza.obrisiRacun(selektovaniRacun);
            racuni.Remove(selektovaniRacun);
        }

        public RacunViewModel()
        {
            baza = new BazaPodataka();
            GenerisiRacun = new RelayCommand(generisiRacun);
            ObrisiRacun = new RelayCommand(obrisiRacun);
            racun = new Racun();
            selektovaniRacun = new Racun();
            racuni = new ObservableCollection<Racun>();
            popravke = new ObservableCollection<Popravka>();
            racuni = baza.dajRacune();
            popravke = baza.dajPopravke();
        }
    }
}
