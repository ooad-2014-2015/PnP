using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Threading.Tasks;

namespace AutoServisMobilnaAplikacija
{
    public partial class Prijava : PhoneApplicationPage
    {
        public Prijava()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (userNameTextBox.Text != "a" || passwordTextBox.Text != "a")
            {
                errorTextBlock.Text = "Pogresan username ili password!";
            }
            else
            {
                errorTextBlock.Text = "Uspjesna prijava";
                MainPage.provjera = true;
               // var t = Task.Delay(3000);  //1 second/1000 ms
               // t.Wait();
                NavigationService.GoBack();
            }
        }
    }
}