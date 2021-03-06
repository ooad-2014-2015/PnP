﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;

namespace Auto_Servis.Baza_podataka
{
    public class BazaPodataka
    {
        public BazaPodataka() { }

        private MySqlConnection connection;

        private void connect()
        {
            string username = "root";
            string password = "";
            string db = "autoservis";
            string connectionString = "server=localhost;user=" + username + ";pwd=" + password + ";database=" + db;

            connection = new MySqlConnection(connectionString);
            connection.Open();
        }

        private void disconnect()
        {
            connection.Close();
        }

        //Dodavanje

        public bool unesiDio(Auto_Servis.Models.Dio dio)
        {
            try
            {
                connect();
                MySqlCommand insertUpit = new MySqlCommand();
                insertUpit.Connection = connection;
                insertUpit.CommandText = "insert into dijelovi values (@id,@naziv,@cijena,@kolicina)";
                insertUpit.Parameters.AddWithValue("@id", dio.Id);
                insertUpit.Parameters.AddWithValue("@naziv", dio.Naziv);
                insertUpit.Parameters.AddWithValue("@cijena", dio.Cijena);
                insertUpit.Parameters.AddWithValue("@kolicina", dio.Kolicina);
                insertUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool unesiIzvjestaj(Models.Izvjestaj izvjestaj)
        {
            try
            {
                connect();
                MySqlCommand insertUpit = new MySqlCommand();
                insertUpit.Connection = connection;
                insertUpit.CommandText = "insert into izvjestaji values (@id,@datumZavrsetkaRadova)";
                insertUpit.Parameters.AddWithValue("@id", izvjestaj.Id);
                insertUpit.Parameters.AddWithValue("@datumZavrsetkaRadova", @izvjestaj.DatumZavrsetkaRadova);
                insertUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool unesiPrivatnoLice(Models.PrivatnoLice pl)
        {
            try
            {
                connect();
                MySqlCommand insertUpit = new MySqlCommand();
                insertUpit.Connection = connection;
                insertUpit.CommandText = "insert into privatna_lica values (@id,@ime,@prezime,@adresa,@brojTelefona)";
                insertUpit.Parameters.AddWithValue("@id", @pl.Id);
                insertUpit.Parameters.AddWithValue("@ime", @pl.Ime);
                insertUpit.Parameters.AddWithValue("@prezime", @pl.Prezime);
                insertUpit.Parameters.AddWithValue("@adresa", @pl.Adresa);
                insertUpit.Parameters.AddWithValue("@brojTelefona", @pl.BrojTelefona);
                insertUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool unesiSluzbenoLice(Models.SluzbenoLice sl)
        {
            try
            {
                connect();
                MySqlCommand insertUpit = new MySqlCommand();
                insertUpit.Connection = connection;
                insertUpit.CommandText = "insert into sluzbena_lica values (@idFirme,@nazivFirme,@ime,@prezime,@adresa,@brojTelefona)";
                insertUpit.Parameters.AddWithValue("@idFirme", @sl.IdFirme);
                insertUpit.Parameters.AddWithValue("@nazivFirme", @sl.NazivFirme);
                insertUpit.Parameters.AddWithValue("@ime", @sl.Ime);
                insertUpit.Parameters.AddWithValue("@prezime", @sl.Prezime);
                insertUpit.Parameters.AddWithValue("@adresa", @sl.Adresa);
                insertUpit.Parameters.AddWithValue("@brojTelefona", @sl.BrojTelefona);
                insertUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool unesiMehanicara(Models.Mehanicar m)
        {
            try
            {
                connect();
                MySqlCommand insertUpit = new MySqlCommand();
                insertUpit.Connection = connection;
                insertUpit.CommandText = "insert into mehanicari values (@id,@ime,@prezime,@tip)";
                insertUpit.Parameters.AddWithValue("@id", @m.Id);
                insertUpit.Parameters.AddWithValue("@ime", @m.Ime);
                insertUpit.Parameters.AddWithValue("@prezime", @m.Prezime);
                insertUpit.Parameters.AddWithValue("@tip", @m.Tip);
                insertUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool unesiPopravku(Models.Popravka p)
        {
            try
            {
                connect();
                MySqlCommand insertUpit = new MySqlCommand();
                insertUpit.Connection = connection;
                insertUpit.CommandText = "insert into popravke values (@id,@cijena,@tipPopravke,@datumPrijemaZahtjeva,@vozilo_id,@dijelovi,@datumZavrsetka,@mehanicar_id,@zavrsena)";
                insertUpit.Parameters.AddWithValue("@id", @p.Id);
                insertUpit.Parameters.AddWithValue("@cijena", @p.Cijena);
                insertUpit.Parameters.AddWithValue("@tipPopravke", @p.TipPopravke);
                insertUpit.Parameters.AddWithValue("@datumPrijemaZahtjeva", @p.DatumPrijemaZahtjeva);
                insertUpit.Parameters.AddWithValue("@vozilo_id", @p.Vozilo.Id);
                insertUpit.Parameters.AddWithValue("@dijelovi", @p.Parts);
                insertUpit.Parameters.AddWithValue("@datumZavrsetka", DateTime.Now);
                insertUpit.Parameters.AddWithValue("@mehanicar_id", @p.Mehanicar.Id);
                insertUpit.Parameters.AddWithValue("@zavrsena", false);
                insertUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool unesiRacun(Models.Racun r)
        {
            try
            {
                connect();
                MySqlCommand insertUpit = new MySqlCommand();
                insertUpit.Connection = connection;
                insertUpit.CommandText = "insert into racuni values (@id,@ukupnaCijena,@datumIzdavanja,@popravka_id)";
                insertUpit.Parameters.AddWithValue("@id", @r.Id);
                insertUpit.Parameters.AddWithValue("@ukupnaCijena", @r.UkupnaCijena);
                insertUpit.Parameters.AddWithValue("@datumIzdavanja", @r.DatumIzdavanja);
                insertUpit.Parameters.AddWithValue("@popravka_id", @r.Popravka.Id);
                insertUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool unesiVozilo(Models.Vozilo v)
        {
            try
            {
                connect();
                MySqlCommand insertUpit = new MySqlCommand();
                insertUpit.Connection = connection;
                insertUpit.CommandText = "insert into vozila values (@id,@brojTablica,@godinaProizvodnje,@proizvodjac,@vlasnik_privatni_id,@vlasnik_sluzbeni_id)";
                insertUpit.Parameters.AddWithValue("@id", @v.Id);
                insertUpit.Parameters.AddWithValue("@brojTablica", @v.BrojTablica);
                insertUpit.Parameters.AddWithValue("@proizvodjac", @v.Proizvodjac);
                insertUpit.Parameters.AddWithValue("@godinaProizvodnje", @v.GodinaProizvodnje);
                if(v.VlasnikPrivatni == null) insertUpit.Parameters.AddWithValue("@vlasnik_privatni_id", null);
                else insertUpit.Parameters.AddWithValue("@vlasnik_privatni_id", @v.VlasnikPrivatni.Id);
                if(v.VlasnikSluzbeni == null) insertUpit.Parameters.AddWithValue("@vlasnik_sluzbeni_id", null);
                else insertUpit.Parameters.AddWithValue("@vlasnik_sluzbeni_id", @v.VlasnikSluzbeni.IdFirme);
                insertUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool unesiZahtjev(Models.Zahtjev z)
        {
            try
            {
                connect();
                MySqlCommand insertUpit = new MySqlCommand();
                insertUpit.Connection = connection;
                insertUpit.CommandText = "insert into vozila values (@id,@datumPrijema)";
                insertUpit.Parameters.AddWithValue("@id", @z.Id);
                insertUpit.Parameters.AddWithValue("@datumPrijema", @z.DatumPrijema);
                insertUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        //Liste

        public ObservableCollection<Models.Dio> dajDijelove()
        {
            ObservableCollection<Models.Dio> dijelovi = new ObservableCollection<Models.Dio>();
            try
            {
                connect();
                MySqlCommand selectUpit = new MySqlCommand();
                selectUpit.Connection = connection;
                selectUpit.CommandText = "select * from dijelovi";
                MySqlDataReader r = selectUpit.ExecuteReader();
                while (r.Read())
                {
                    Models.Dio d = new Models.Dio();
                    d.Id = r.GetInt32("id");
                    d.Naziv = r.GetString("naziv");
                    d.Cijena = r.GetDouble("cijena");
                    d.Kolicina = r.GetInt32("kolicina");
                    dijelovi.Add(d);
                }
                return dijelovi;
            }
            catch (Exception)
            {
                dijelovi.Clear();
                connection.Close();
                return dijelovi;
            }
        }

        public ObservableCollection<Models.Izvjestaj> dajIzvjestaje()
        {
            ObservableCollection<Models.Izvjestaj> izvjestaji = new ObservableCollection<Models.Izvjestaj>();
            try
            {
                connect();
                MySqlCommand selectUpit = new MySqlCommand();
                selectUpit.Connection = connection;
                selectUpit.CommandText = "select * from izvjestaji";
                MySqlDataReader r = selectUpit.ExecuteReader();
                while (r.Read())
                {
                    Models.Izvjestaj i = new Models.Izvjestaj();
                    i.Id = r.GetInt32("id");
                    i.DatumZavrsetkaRadova = r.GetDateTime("datumZavrsetkaRadova");
                    izvjestaji.Add(i);
                }
                return izvjestaji;
            }
            catch (Exception)
            {
                izvjestaji.Clear();
                connection.Close();
                return izvjestaji;
            }
        }

        public ObservableCollection<Models.PrivatnoLice> dajPrivatnaLica()
        {
            ObservableCollection<Models.PrivatnoLice> privatnaLica = new ObservableCollection<Models.PrivatnoLice>();
            try
            {
                connect();
                MySqlCommand selectUpit = new MySqlCommand();
                selectUpit.Connection = connection;
                selectUpit.CommandText = "select * from privatna_lica";
                MySqlDataReader r = selectUpit.ExecuteReader();
                while (r.Read())
                {
                    Models.PrivatnoLice pl = new Models.PrivatnoLice();
                    pl.Id = r.GetInt32("id");
                    pl.Ime = r.GetString("ime");
                    pl.Prezime = r.GetString("prezime");
                    pl.Adresa = r.GetString("adresa");
                    pl.BrojTelefona = r.GetInt32("brojTelefona");
                    privatnaLica.Add(pl);
                }
                return privatnaLica;
            }
            catch (Exception)
            {
                privatnaLica.Clear();
                connection.Close();
                return privatnaLica;
            }
        }

        public ObservableCollection<Models.SluzbenoLice> dajSluzbenaLica()
        {
            ObservableCollection<Models.SluzbenoLice> sluzbenaLica = new ObservableCollection<Models.SluzbenoLice>();
            try
            {
                connect();
                MySqlCommand selectUpit = new MySqlCommand();
                selectUpit.Connection = connection;
                selectUpit.CommandText = "select * from sluzbena_lica";
                MySqlDataReader r = selectUpit.ExecuteReader();
                while (r.Read())
                {
                    Models.SluzbenoLice sl = new Models.SluzbenoLice();
                    sl.IdFirme = r.GetInt32("idFirme");
                    sl.NazivFirme = r.GetString("nazivFirme");
                    sl.Ime = r.GetString("ime");
                    sl.Prezime = r.GetString("prezime");
                    sl.Adresa = r.GetString("adresa");
                    sl.BrojTelefona = r.GetInt32("brojTelefona");
                    sluzbenaLica.Add(sl);
                }
                return sluzbenaLica;
            }
            catch (Exception)
            {
                sluzbenaLica.Clear();
                connection.Close();
                return sluzbenaLica;
            }
        }

        public ObservableCollection<Models.Mehanicar> dajMehanicare()
        {
            ObservableCollection<Models.Mehanicar> mehanicari = new ObservableCollection<Models.Mehanicar>();
            try
            {
                connect();
                MySqlCommand selectUpit = new MySqlCommand();
                selectUpit.Connection = connection;
                selectUpit.CommandText = "select * from mehanicari";
                MySqlDataReader r = selectUpit.ExecuteReader();
                while (r.Read())
                {
                    Models.Mehanicar m = new Models.Mehanicar();
                    m.Id = r.GetInt32("id");
                    m.Ime = r.GetString("ime");
                    m.Prezime = r.GetString("prezime");
                    m.Tip = r.GetString("tip"); ;
                    mehanicari.Add(m);
                }
                return mehanicari;
            }
            catch (Exception)
            {
                mehanicari.Clear();
                connection.Close();
                return mehanicari;
            }
        }

        public ObservableCollection<Models.Popravka> dajPopravke()
        {
            ObservableCollection<Models.Popravka> popravke = new ObservableCollection<Models.Popravka>();
            try
            {
                ObservableCollection<Models.Vozilo> vozila = this.dajVozila();
                ObservableCollection<Models.Mehanicar> mehanicari = this.dajMehanicare();
                connect();
                MySqlCommand selectUpit = new MySqlCommand();
                selectUpit.Connection = connection;
                selectUpit.CommandText = "select * from popravke";
                MySqlDataReader r = selectUpit.ExecuteReader();
                while (r.Read())
                {
                    Models.Popravka p = new Models.Popravka();
                    p.Id = r.GetInt32("id");
                    p.Cijena = r.GetDouble("cijena");
                    p.TipPopravke = r.GetString("tipPopravke");
                    p.DatumPrijemaZahtjeva = r.GetDateTime("datumPrijemaZahtjeva");
                    foreach (Models.Vozilo v in vozila)
                    {
                        if (!r.IsDBNull(r.GetOrdinal("vozilo_id")))
                        {
                            if (v.Id == Convert.ToInt32(r["vozilo_id"]))
                            {
                                p.Vozilo = v; break;
                            }
                            else p.Vozilo = null;
                        }
                        else continue;
                    }
                    p.Parts = r.GetString("dijelovi");
                    p.DatumZavrsetkaRadova = r.GetDateTime("datumZavrsetka");
                    foreach (Models.Mehanicar m in mehanicari)
                    {
                        if (!r.IsDBNull(r.GetOrdinal("mehanicar_id")))
                        {
                            if (m.Id == Convert.ToInt32(r["mehanicar_id"]))
                            {
                                p.Mehanicar = m; break;
                            }
                            else p.Mehanicar = null;
                        }
                        else continue;
                    }
                    p.Zavrsena = r.GetBoolean("zavrsena");
                    popravke.Add(p);
                }
                return popravke;
            }
            catch (Exception)
            {
                popravke.Clear();
                connection.Close();
                return popravke;
            }
        }

        public ObservableCollection<Models.Racun> dajRacune()
        {
            ObservableCollection<Models.Racun> racuni = new ObservableCollection<Models.Racun>();
            try
            {
                ObservableCollection<Models.Popravka> popravke = this.dajPopravke();
                connect();
                MySqlCommand selectUpit = new MySqlCommand();
                selectUpit.Connection = connection;
                selectUpit.CommandText = "select * from racuni";
                MySqlDataReader r = selectUpit.ExecuteReader();
                while (r.Read())
                {
                    Models.Racun ra = new Models.Racun();
                    ra.Id = r.GetInt32("id");
                    ra.UkupnaCijena = r.GetDouble("ukupnaCijena");
                    ra.DatumIzdavanja = r.GetDateTime("datumIzdavanja");
                    foreach (Models.Popravka p in popravke)
                    {
                        if (!r.IsDBNull(r.GetOrdinal("popravka_id")))
                        {
                            if (p.Id == Convert.ToInt32(r["popravka_id"]))
                            {
                                ra.Popravka = p; break;
                            }
                            else ra.Popravka = null;
                        }
                        else continue;
                    }
                    racuni.Add(ra);
                }
                return racuni;
            }
            catch (Exception)
            {
                racuni.Clear();
                connection.Close();
                return racuni;
            }
        }

        public ObservableCollection<Models.Vozilo> dajVozila()
        {
            ObservableCollection<Models.Vozilo> vozila = new ObservableCollection<Models.Vozilo>();
            try
            {
                connect();
                MySqlCommand selectUpit = new MySqlCommand();
                selectUpit.Connection = connection;
                selectUpit.CommandText = "select * from vozila";
                MySqlDataReader r = selectUpit.ExecuteReader();
                ObservableCollection<Models.PrivatnoLice> pLica = this.dajPrivatnaLica();
                ObservableCollection<Models.SluzbenoLice> sLica = this.dajSluzbenaLica();
                while (r.Read())
                {
                    Models.Vozilo v = new Models.Vozilo();
                    v.Id = r.GetInt32("id");
                    v.BrojTablica = r.GetString("brojTablica");
                    v.Proizvodjac = r.GetString("proizvodjac");
                    v.GodinaProizvodnje = r.GetDateTime("godinaProizvodnje");
                    foreach (Models.PrivatnoLice pl in pLica)
                    {
                        if (!r.IsDBNull(r.GetOrdinal("vlasnik_privatni_id")))
                        {
                            if (pl.Id == Convert.ToInt32(r["vlasnik_privatni_id"]))
                            {
                                v.VlasnikPrivatni = pl; break;
                            }
                            else v.VlasnikPrivatni = null;
                        }
                        else continue;
                    }
                    foreach (Models.SluzbenoLice sl in sLica)
                    {
                        if (!r.IsDBNull(r.GetOrdinal("vlasnik_sluzbeni_id")))
                        {
                            if (sl.IdFirme == Convert.ToInt32(r["vlasnik_sluzbeni_id"]))
                            {
                                v.VlasnikSluzbeni = sl; break;
                            }
                            else v.VlasnikSluzbeni = null;
                        }
                        else continue;
                    }
                    vozila.Add(v);
                }
                return vozila;
            }
            catch (Exception)
            {
                vozila.Clear();
                connection.Close();
                return vozila;
            }
        }

        public ObservableCollection<Models.Zahtjev> dajZahtjeve()
        {
            ObservableCollection<Models.Zahtjev> zahtjevi = new ObservableCollection<Models.Zahtjev>();
            try
            {
                connect();
                MySqlCommand selectUpit = new MySqlCommand();
                selectUpit.Connection = connection;
                selectUpit.CommandText = "select * from zahtjevi";
                MySqlDataReader r = selectUpit.ExecuteReader();
                while (r.Read())
                {
                    Models.Zahtjev z = new Models.Zahtjev();
                    z.Id = r.GetInt32("id");
                    z.DatumPrijema = r.GetDateTime("datumPrijema");
                    zahtjevi.Add(z);
                }
                return zahtjevi;
            }
            catch (Exception)
            {
                zahtjevi.Clear();
                connection.Close();
                return zahtjevi;
            }
        }

        //Brisanje

        public bool obrisiDio(Models.Dio d)
        {
            try
            {
                connect();
                MySqlCommand deleteUpit = new MySqlCommand();
                deleteUpit.Connection = connection;
                deleteUpit.CommandText = "delete from dijelovi where id = @id;";
                deleteUpit.Parameters.AddWithValue("@id", d.Id);
                deleteUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisiIzvjestaj(Models.Izvjestaj i)
        {
            try
            {
                connect();
                MySqlCommand deleteUpit = new MySqlCommand();
                deleteUpit.Connection = connection;
                deleteUpit.CommandText = "delete from izvjestaji where id = @id;";
                deleteUpit.Parameters.AddWithValue("@id", i.Id);
                deleteUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisiPrivatnoLice(Models.PrivatnoLice pl)
        {
            try
            {
                connect();
                MySqlCommand deleteUpit = new MySqlCommand();
                deleteUpit.Connection = connection;
                deleteUpit.CommandText = "delete from privatna_lica where id = @id;";
                deleteUpit.Parameters.AddWithValue("@id", pl.Id);
                deleteUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisiSluzbenoLice(Models.SluzbenoLice sl)
        {
            try
            {
                connect();
                MySqlCommand deleteUpit = new MySqlCommand();
                deleteUpit.Connection = connection;
                deleteUpit.CommandText = "delete from sluzbena_lica where idFirme = @idFirme;";
                deleteUpit.Parameters.AddWithValue("@idFirme", sl.IdFirme);
                deleteUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisiMehanicara(Models.Mehanicar m)
        {
            try
            {
                connect();
                MySqlCommand deleteUpit = new MySqlCommand();
                deleteUpit.Connection = connection;
                deleteUpit.CommandText = "delete from mehanicari where id = @id;";
                deleteUpit.Parameters.AddWithValue("@id", m.Id);
                deleteUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisiPopravku(Models.Popravka p)
        {
            try
            {
                connect();
                MySqlCommand deleteUpit = new MySqlCommand();
                deleteUpit.Connection = connection;
                deleteUpit.CommandText = "delete from popravke where id = @id;";
                deleteUpit.Parameters.AddWithValue("@id", p.Id);
                deleteUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisiRacun(Models.Racun r)
        {
            try
            {
                connect();
                MySqlCommand deleteUpit = new MySqlCommand();
                deleteUpit.Connection = connection;
                deleteUpit.CommandText = "delete from racuni where id = @id;";
                deleteUpit.Parameters.AddWithValue("@id", r.Id);
                deleteUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisiVozilo(Models.Vozilo v)
        {
            try
            {
                connect();
                MySqlCommand deleteUpit = new MySqlCommand();
                deleteUpit.Connection = connection;
                deleteUpit.CommandText = "delete from vozila where id = @id;";
                deleteUpit.Parameters.AddWithValue("@id", v.Id);
                deleteUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        public bool obrisiZahtjev(Models.Zahtjev z)
        {
            try
            {
                connect();
                MySqlCommand deleteUpit = new MySqlCommand();
                deleteUpit.Connection = connection;
                deleteUpit.CommandText = "delete from zahtjevi where id = @id;";
                deleteUpit.Parameters.AddWithValue("@id", z.Id);
                deleteUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }

        //

        public bool updatePopravke(Models.Popravka popravka)
        {
            try
            {
                connect();
                MySqlCommand setUpit = new MySqlCommand();
                setUpit.Connection = connection;
                setUpit.CommandText = "update popravke set datumZavrsetka = @datumZavrsetkaRadova, zavrsena = @zavrsena where id = @id;";
                setUpit.Parameters.AddWithValue("@id", popravka.Id);
                setUpit.Parameters.AddWithValue("@datumZavrsetkaRadova", popravka.DatumZavrsetkaRadova);
                setUpit.Parameters.AddWithValue("@zavrsena", popravka.Zavrsena);
                setUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false; 
            }
        }

        public bool updateDijela(Models.Dio dio)
        {
            try
            {
                connect();
                MySqlCommand setUpit = new MySqlCommand();
                setUpit.Connection = connection;
                setUpit.CommandText = "update dijelovi set kolicina = @kolicina where id = @id;";
                setUpit.Parameters.AddWithValue("@id", dio.Id);
                setUpit.Parameters.AddWithValue("@kolicina", dio.Kolicina);
                setUpit.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                connection.Close();
                return false;
            }
        }
    }
}
