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
    /// Interaction logic for FormaRacun.xaml
    /// </summary>
    public partial class FormaRacun : Window
    {
        public FormaRacun()
        {
            InitializeComponent();
            RacunViewModel rViewModel = new RacunViewModel();
            DataContext = rViewModel;
            rViewModel.FRacun = this;
            racuniDataGrid.DataContext = rViewModel;
            racuniDataGrid.SetBinding(ItemsControl.ItemsSourceProperty, new Binding("Racuni"));
        }
    }
}
