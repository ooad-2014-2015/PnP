using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Auto_Servis.Models;
using Auto_Servis.Baza_podataka;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using System.IO;
using Auto_Servis.View;
using System.Diagnostics;

namespace Auto_Servis.ViewModel 
{
    public class RacunViewModel : INotifyPropertyChanged
    {
        private static Thread nitUnos, nitBrisanje, nitPrintanje;
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
        public ICommand IsprintajRacun { get; set; }

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
                nitUnos = new Thread(() => baza.unesiRacun(racun));
                nitUnos.IsBackground = true;
                nitUnos.Start();
                racuni.Add(racun);
                string r = "Datum izdavanja: " + racun.DatumIzdavanja.ToString() + "\n";
                r += "Popravka: " + racun.Popravka.TipPopravke + " " + racun.Popravka.Cijena + "\nDijelovi: ";
                r += racun.Popravka.Parts;
                r += "---------------------------------------------\n";
                r += "Ukupno: " + racun.UkupnaCijena + " KM\n";
                racun.Prikaz = r;
            }
        }

        private void obrisiRacun(object parameter)
        {
            nitBrisanje = new Thread(() => baza.obrisiRacun(selektovaniRacun));
            nitBrisanje.IsBackground = true;
            nitBrisanje.Start();
            racuni.Remove(selektovaniRacun);
        }

        private void isprintajRacun(object parameter)
        {
            FileStream file = new FileStream("racun.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(file);
            int j = 0, k = 0;
            for (int i = 0; i < racun.Prikaz.Length; i++)
            {
                if (racun.Prikaz[i] == '\n')
                {
                    j = i;
                    sw.WriteLine(racun.Prikaz.Substring(k, j - k));
                    k = j;
                }
            }
            sw.Flush();
            sw.Close();
            file.Close();

            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo(@"racun.txt");
            psi.Verb = "PRINT";
            Process.Start(psi);

            if (MessageBoxResult.OK == MessageBox.Show("Isprintali ste racun!"))
            {
                fRacun.Close();
                FormaRacun Nova = new FormaRacun();
                Nova.Show();
            }
        }

        public RacunViewModel()
        {
            baza = new BazaPodataka();
            GenerisiRacun = new RelayCommand(generisiRacun);
            ObrisiRacun = new RelayCommand(obrisiRacun);
            IsprintajRacun = new RelayCommand(isprintajRacun);
            racun = new Racun();
            selektovaniRacun = new Racun();
            racuni = new ObservableCollection<Racun>();
            popravke = new ObservableCollection<Popravka>();
            racuni = baza.dajRacune();
            popravke = baza.dajPopravke();
        }
    }
}
