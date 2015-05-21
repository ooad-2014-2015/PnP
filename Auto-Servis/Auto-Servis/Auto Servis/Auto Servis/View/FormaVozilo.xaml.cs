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
using Auto_Servis.Models;
using System.Collections.ObjectModel;


namespace Auto_Servis.View
{
    /// <summary>
    /// Interaction logic for FormaVozilo.xaml
    /// </summary>
    public partial class FormaVozilo : Window
    {
        public FormaVozilo()
        {
            InitializeComponent();
            VoziloViewModel vViewModel = new VoziloViewModel();
            DataContext = vViewModel;
            listBox.DataContext = vViewModel;
            listBox.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Vozila"));
        }

        private void TabControl_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
