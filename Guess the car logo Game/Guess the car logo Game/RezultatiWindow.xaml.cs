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

namespace Guess_the_car_logo_Game
{
    /// <summary>
    /// Interaction logic for RezultatiWindow.xaml
    /// </summary>
    public partial class RezultatiWindow : Window
    {
        private IgraFacade iFacade;
        public RezultatiWindow()
        {
            InitializeComponent();
        }

        public RezultatiWindow(IgraFacade igraFacade)
        {
            InitializeComponent();
            iFacade = igraFacade;
        }
    }
}
