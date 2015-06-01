using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace AutoServisMobilnaAplikacija
{
    public partial class ListaPopravki : PhoneApplicationPage
    {
        public ListaPopravki()
        {
            InitializeComponent();
            using (ASBazaPodatakaContext db = new ASBazaPodatakaContext(ASBazaPodatakaContext.ConnectionString))
            {
                db.CreateIfNotExists();

                Table<Popravke> popravke = db.GetTable<Popravke>();
                var popravkeUpit = from j in popravke.ToList() select j;
                foreach (var popravka in popravkeUpit)
                {
                    PivotItem p = new PivotItem();
                    Kontrola popravkeKontrola = new Kontrola();
                    popravkeKontrola.id.Text = "Id popravke:  " + popravka.Id;
                    popravkeKontrola.cijena.Text = "Cijena:  " + popravka.Cijena + " KM";
                    popravkeKontrola.datumPrijema.Text = "Datum prijema zahtjeva:  " + popravka.DatumPrijema.ToShortDateString();
                    popravkeKontrola.tip.Text = "Vrsta popravke:  " + popravka.Tip;
                    popravkeKontrola.vozilo.Text = "Naziv vozila:  " + popravka.Vozilo;
                    popravkeKontrola.dijelovi.Text = "Lista dijelova:  " + popravka.Dijelovi;
                    popravkeKontrola.datumZavrsetka.Text = "Datum zavrsetka popravke:  " + popravka.DatumZavrsetka.ToShortDateString();

                    p.Header = "Br popravke " + popravka.Id;
                    p.Content = popravkeKontrola;
                    mojPivot.Items.Add(p);
                }
            }
        }

        
    }
}