using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Data.Linq;

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

            using (DatabaseContext db = new DatabaseContext(DatabaseContext.ConnectionString))
            {
                /*db.CreateIfNotExists();

                var query =
                    from j in db.Popravke
                    where j.Id == Convert.ToInt32(id.Text)
                    select j;

                foreach (Popravke j in query)
                {
                    j.StatusPopravke = "Popravljeno";
                    popravljenoCheckBox.IsChecked = true;
                    j.Cijena = 0;
                }

                try
                {
                    db.SubmitChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }*/

                IQueryable<Popravke> entityQuery = from c in db.Popravke where c.Id == 3 select c;
                Popravke entityToUpdate = entityQuery.FirstOrDefault();
                entityToUpdate.StatusPopravke = "Popravljeno";
                db.SubmitChanges();
                
            }
        }
    }
}
