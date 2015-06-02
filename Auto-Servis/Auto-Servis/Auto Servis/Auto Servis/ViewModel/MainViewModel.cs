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
    public class MainViewModel
    {
        public ICommand Vozilo { get; set; }
        public ICommand Klijent { get; set; }
        public ICommand Popravka { get; set; }
        public ICommand Dio { get; set; }
        public ICommand Racun { get; set; }
        public ICommand Help { get; set; }

        public void vozilo(object parameter)
        {
            var f = new FormaVozilo();
            f.Show();
        }

        public void klijent(object parameter)
        {
            var f = new FormaKlijent();
            f.Show();
        }

        public void popravka(object parameter)
        {
            var f = new FormaPopravka();
            f.Show();
        }

        public void dio(object parameter)
        {
            var f = new FormaDio();
            f.Show();
        }

        public void racun(object parameter)
        {
            var f = new FormaRacun();
            f.Show();
        }

        public void help(object parameter)
        {
            var f = new FormaHelp();
            f.Show();
        }

        public MainViewModel()
        {
            Vozilo = new RelayCommand(vozilo);
            Klijent = new RelayCommand(klijent);
            Popravka = new RelayCommand(popravka);
            Dio = new RelayCommand(dio);
            Racun = new RelayCommand(racun);
            Help = new RelayCommand(help);
        }
    }
}
