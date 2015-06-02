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
    /// Interaction logic for FormaHelp.xaml
    /// </summary>
    public partial class FormaHelp : Window
    {
        public FormaHelp()
        {
            InitializeComponent();
            HelpViewModel hViewModel = new HelpViewModel(this);
            DataContext = hViewModel;
        }
    }
}
