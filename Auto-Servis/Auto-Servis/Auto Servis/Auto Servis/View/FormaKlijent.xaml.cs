using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Auto_Servis.ViewModel;

namespace Auto_Servis.View
{
    /// <summary>
    /// Interaction logic for FormaKlijent.xaml
    /// </summary>
    public partial class FormaKlijent : Window
    {
        public FormaKlijent()
        {
            InitializeComponent();
            KlijentViewModel kViewModel = new KlijentViewModel();
            DataContext = kViewModel;
            kViewModel.FKlijent = this;
            PLListBox.DataContext = kViewModel;
            PLListBox.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("PrivatnaLica"));
            SLListBox.DataContext = kViewModel;
            SLListBox.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("SluzbenaLica"));
        }
    }
}
