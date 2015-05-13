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
    /// Interaction logic for IgracWindow.xaml
    /// </summary>
    public partial class IgracWindow : Window
    {
        private IgraFacade igraFacade;
        public IgracWindow()
        {
            InitializeComponent();
        }

        public IgracWindow(IgraFacade igraFacade1)
        {
            InitializeComponent();
            igraFacade = igraFacade1;
        }

        private void potvrdiUnosButton_Click(object sender, RoutedEventArgs e)
        {
            if (nazivIgracaTextBox.Text.Length != 0)
            {
                igraFacade.Igrac.Naziv = nazivIgracaTextBox.Text;
                MessageBox.Show("Uspjesno ste unijeli igraca");
                this.Close();
            }
            else MessageBox.Show("Niste unijeli naziv igraca");
        }
    }
}
