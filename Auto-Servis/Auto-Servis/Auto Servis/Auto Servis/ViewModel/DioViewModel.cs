using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Auto_Servis.Models;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Auto_Servis.View;

namespace Auto_Servis.ViewModel
{
    public class DioViewModel : INotifyPropertyChanged
    {
        private FormaDio fDio;
        public FormaDio FDio
        {
            get { return fDio; }
            set { fDio = value; }
        }

        public ICommand Dodaj { get; set; }
        public ICommand Ukloni { get; set; }
        public ICommand AzurirajKolicinu { get; set; }

        private Baza_podataka.BazaPodataka baza;

        private Dio dio;
        public Dio Dio
        {
            get { return dio; }
            set { dio = value; }
        }

        private Dio selektovaniDio;
        public Dio SelektovaniDio
        {
            get { return selektovaniDio; }
            set { selektovaniDio = value; OnPropertyChanged("SelektovaniDio"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<Dio> dijelovi;
        public ObservableCollection<Dio> Dijelovi
        {
            get { return dijelovi; }
            set { dijelovi = value; OnPropertyChanged("Dijelovi"); }
        }

        public DioViewModel()
        {
            baza = new Baza_podataka.BazaPodataka();
            dio = new Dio();
            selektovaniDio = new Dio();
            dijelovi = new ObservableCollection<Dio>();
            dijelovi = baza.dajDijelove();
            Dodaj = new RelayCommand(dodaj);
            Ukloni = new RelayCommand(ukloni);
            AzurirajKolicinu = new RelayCommand(azurirajKolicinu);
        }

        public void dodaj(object parameter)
        {
            foreach(Dio d in dijelovi) if (d == dio) return;
            if (dio.IsValid)
            {
                baza.unesiDio(dio);
                dijelovi.Add(dio);
                if (MessageBoxResult.OK == MessageBox.Show("Unijeli ste dio"))
                {
                    fDio.Close();
                    FormaDio Nova = new FormaDio();
                    Nova.Show();
                }
            }
            else MessageBox.Show("Niste unijeli ispravne podatke!");
        }

        public void ukloni(object parameter)
        {
            baza.obrisiDio(selektovaniDio);
            dijelovi.Remove(selektovaniDio);
        }

        public void azurirajKolicinu(object parameter)
        {
            baza.updateDijela(selektovaniDio);
            if (selektovaniDio.IsValid) MessageBox.Show("Promijenili ste kolicinu dijela");
            else MessageBox.Show("Neispravni podaci");
        }
    }
}
