﻿using System;
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

namespace Auto_Servis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var f = new Auto_Servis.View.FormaVozilo();
            f.Show();
        }

        private void klijentButton_Click(object sender, RoutedEventArgs e)
        {
            var f = new Auto_Servis.View.FormaKlijent();
            f.Show();
        }

        private void popravkaButton_Click(object sender, RoutedEventArgs e)
        {
            var f = new Auto_Servis.View.FormaPopravka();
            f.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var f = new Auto_Servis.View.FormaDio();
            f.Show();
        }
    }
}
