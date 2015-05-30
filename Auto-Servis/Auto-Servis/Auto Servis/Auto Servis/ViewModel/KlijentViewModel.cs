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
    public class KlijentViewModel : INotifyPropertyChanged
    {
        private FormaKlijent fKlijent;
        public FormaKlijent FKlijent
        {
            get { return fKlijent; }
            set { fKlijent = value; }
        }
        public ICommand UnosPrivatnogLica { get; set; }
        public ICommand BrisanjePrivatnogLica { get; set; }
        public ICommand UnosSluzbenogLica { get; set; }
        public ICommand BrisanjeSluzbenogLica { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private PrivatnoLice pL;
        public PrivatnoLice PL 
        {
            get { return pL; }
            set { pL = value; }
        }

        private ObservableCollection<PrivatnoLice> privatnaLica;
        public ObservableCollection<PrivatnoLice> PrivatnaLica
        {
            get { return privatnaLica; }
            set { privatnaLica = value; OnPropertyChanged("PrivatnaLica"); }
        }

        private SluzbenoLice sL;
        public SluzbenoLice SL
        {
            get { return sL; }
            set { sL = value; }
        }

        private ObservableCollection<SluzbenoLice> sluzbenaLica;
        public ObservableCollection<SluzbenoLice> SluzbenaLica
        {
            get { return sluzbenaLica; }
            set { sluzbenaLica = value; OnPropertyChanged("SluzbenaLica"); }
        }

        private BazaPodataka baza;

        public void unosPrivatnogLica(object parameter)
        {
            if (pL.IsValid)
            {
                baza.unesiPrivatnoLice(pL);
                privatnaLica.Add(pL);
                if (MessageBoxResult.OK == MessageBox.Show("Unijeli ste privatno lice"))
                {
                    fKlijent.Close();
                    FormaKlijent Nova = new FormaKlijent();
                    Nova.Show();
                }
            }
        }

        public void unosSluzbenogLica(object parameter)
        {
            if (sL.IsValid)
            {
                baza.unesiSluzbenoLice(sL);
                sluzbenaLica.Add(sL);
                if (MessageBoxResult.OK == MessageBox.Show("Unijeli ste sluzbeno lice"))
                {
                    fKlijent.Close();
                    FormaKlijent Nova = new FormaKlijent();
                    Nova.Show();
                }
            }
        }

        public PrivatnoLice selektovanoPL { get; set; }
        public SluzbenoLice selektovanoSL { get; set; }

        public void brisanjePrivatnogLica(object parameter)
        {
            baza.obrisiPrivatnoLice(selektovanoPL);
            privatnaLica.Remove(selektovanoPL);
        }

        public void brisanjeSluzbenogLica(object parameter)
        {
            baza.obrisiSluzbenoLice(selektovanoSL);
            sluzbenaLica.Remove(selektovanoSL);
        }

        public KlijentViewModel()
        {
            pL = new PrivatnoLice();
            sL = new SluzbenoLice();
            UnosPrivatnogLica = new RelayCommand(unosPrivatnogLica);
            UnosSluzbenogLica = new RelayCommand(unosSluzbenogLica);
            BrisanjePrivatnogLica = new RelayCommand(brisanjePrivatnogLica);
            BrisanjeSluzbenogLica = new RelayCommand(brisanjeSluzbenogLica);
            privatnaLica = new ObservableCollection<PrivatnoLice>();
            sluzbenaLica = new ObservableCollection<SluzbenoLice>();
            selektovanoPL = new PrivatnoLice();
            selektovanoSL = new SluzbenoLice();
            baza = new BazaPodataka();
            privatnaLica = baza.dajPrivatnaLica();
            sluzbenaLica = baza.dajSluzbenaLica();
        }
    }
}
