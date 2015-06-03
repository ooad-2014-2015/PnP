using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AutoServisMobilnaAplikacija.Resources;
using System.Data.Linq;

namespace AutoServisMobilnaAplikacija
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static bool provjera;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            provjera = false;
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void prijavaButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Prijava.xaml", UriKind.Relative));
        }

        private void popravkeButton_Loaded(object sender, RoutedEventArgs e)
        {
            if (provjera) popravkeButton.IsEnabled = true;
        }

        private void popravkeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ListaPopravki.xaml", UriKind.Relative));
            
            
        }

}


        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
