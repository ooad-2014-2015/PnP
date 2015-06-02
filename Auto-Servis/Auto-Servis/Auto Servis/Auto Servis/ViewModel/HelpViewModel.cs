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
using Auto_Servis.View;
using System.IO;
using System.Windows.Xps.Packaging;

namespace Auto_Servis.ViewModel
{
    public class HelpViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private XpsDocument help;
        public XpsDocument Help
        {
            get { return help; }
            set { help = value; OnPropertyChanged("Help"); }
        }

        public HelpViewModel(Object view)
        {
            help = new XpsDocument(@"Help.xps", FileAccess.Read);
            if (help == null) MessageBox.Show("Nije ucitalo");
            (view as FormaHelp).doc.Document = help.GetFixedDocumentSequence();
        }


        
    }
}
