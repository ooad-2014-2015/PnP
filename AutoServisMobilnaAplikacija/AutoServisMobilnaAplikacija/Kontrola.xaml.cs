﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AutoServisMobilnaAplikacija
{
    public partial class Kontrola : UserControl
    {
        public Kontrola()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            popravljenoCheckBox.IsChecked = true;
            nijePopravljenoCheckBox.IsChecked = false;
        }
    }
}
