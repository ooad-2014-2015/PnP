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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Guess_the_car_logo_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool istekloVrijeme = true;
        static int brojac = 3;
        static int brojacS = 0;
        static int brojacT = 0;
        public IgraFacade igraFacade;
        public DispatcherTimer timer = new DispatcherTimer();
        public DispatcherTimer timer2 = new DispatcherTimer();
        public int vrijeme, faktorRezultata;
        public List<Igrac> igraci;
        public MainWindow()
        {
            InitializeComponent();
            igraFacade = new IgraFacade();
            igraFacade.Igrac.Rezultat = 0;
            igraFacade.Nivo.Broj = 0;
            igraFacade.Igrac.NajboljiRezultat = 0;
            timer2.Interval = new TimeSpan(0, 0, 1);
            timer2.Tick += new EventHandler(timer2_Tick);
            igraci = new List<Igrac>();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            vrijeme = Convert.ToInt32(vrijemeLabel.Content);
            vrijeme--;
            vrijemeLabel.Content = Convert.ToString(vrijeme);
        }

        private void kreirajIgracaButton_Click(object sender, RoutedEventArgs e)
        {
            igraFacade.Rezultati.Clear();
            IgracWindow igracWindow = new IgracWindow(igraFacade);
            igracWindow.Show();
        }

        private void laganaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            igraFacade.Tezina.VrijemeZaOdgovor = 4;
            faktorRezultata = 1;
        }

        private void srednjaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            igraFacade.Tezina.VrijemeZaOdgovor = 3;
            faktorRezultata = 2;
        }

        private void teskaRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            igraFacade.Tezina.VrijemeZaOdgovor = 2;
            faktorRezultata = 3;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            istekloVrijeme = true;
            if (laganaRadioButton.IsChecked == false && srednjaRadioButton.IsChecked == false && teskaRadioButton.IsChecked == false)
                MessageBox.Show("Niste odabrali tezinu!");
            else
            {
                if (laganaRadioButton.IsChecked == true) // omogucava da se zaredom igraju tezine
                {
                    if (igraFacade.Nivo.Broj == 7)
                    {
                        igraFacade.Nivo.Broj = 0;
                        brojac = 0;
                        promijeniBrendove_Lagana();
                    }
                    igraCanvas.Visibility = Visibility.Visible;
                    logo4Image.Visibility = Visibility.Hidden;
                    logo5Image.Visibility = Visibility.Hidden;
                    igraFacade.Nivo.Broj++;
                    string[] pitanja = { "Mercedes", "Honda", "Opel", "Fiat", "Mitsubishi", "Suzuki", "Volvo"}; //trazeni brendovi
                    igraFacade.Nivo.Logo = pitanja[igraFacade.Nivo.Broj - 1];
                    pitanjeLabel.Content = igraFacade.Nivo.Logo;
                }
                else if (srednjaRadioButton.IsChecked == true)
                {
                    if (igraFacade.Nivo.Broj == 7) // omogucava da se zaredom igraju tezine; mijenja se kako se mijenjaju nivoi
                    {
                        igraFacade.Nivo.Broj = 0;
                        brojacS = 0;
                        promijeniBrendove_Srednja();
                    }
                    igraCanvas.Visibility = Visibility.Visible;
                    logo4Image.Visibility = Visibility.Visible;
                    logo5Image.Visibility = Visibility.Hidden;
                    if(brojacS == 0) promijeniBrendove_Srednja();
                    igraFacade.Nivo.Broj++;
                    if (igraFacade.Nivo.Broj == 9) igraFacade.Nivo.Broj = 1; // mijenja se kako se mijenja broj nivoa
                    string[] pitanja = { "Bentley", "Kia", "Jeep", "Lada", "Ford", "Vespa", "Bugatti" }; //trazeni brendovi
                    igraFacade.Nivo.Logo = pitanja[igraFacade.Nivo.Broj - 1];
                    pitanjeLabel.Content = igraFacade.Nivo.Logo;
                }
                else
                {
                    if (teskaRadioButton.IsChecked == true) // omogucava da se zaredom igraju tezine
                    {
                        if (igraFacade.Nivo.Broj == 7)
                        {
                            igraFacade.Nivo.Broj = 0;
                            brojacT = 0;
                            promijeniBrendove_Teska();
                        }
                    }
                    igraCanvas.Visibility = Visibility.Visible;
                    logo4Image.Visibility = Visibility.Visible;
                    logo5Image.Visibility = Visibility.Visible;
                    if (brojacT == 0) promijeniBrendove_Teska();
                    igraFacade.Nivo.Broj++;
                    if (igraFacade.Nivo.Broj == 9) igraFacade.Nivo.Broj = 1; // mijenja se kako se mijenja broj nivoa
                    string[] pitanja = { "Rolls Royce", "Jawa", "Seat", "Zastava", "Yugo", "Proton", "Hillman" }; //trazeni brendovi
                    igraFacade.Nivo.Logo = pitanja[igraFacade.Nivo.Broj - 1];
                    pitanjeLabel.Content = igraFacade.Nivo.Logo;
                }
                
                    timer.Tick += new EventHandler(timer_Tick);
                    timer.Interval = new TimeSpan(0, 0, Convert.ToInt32(igraFacade.Tezina.VrijemeZaOdgovor));
                    timer.Start();
                    timer2.Start();
                    vrijemeLabel.Content = Convert.ToString(igraFacade.Tezina.VrijemeZaOdgovor);
                igraFacade.Igrac.NajboljiRezultat = 0;
                nbrLabel.Content =Convert.ToString(igraFacade.Igrac.NajboljiRezultat);
            }
        }

        private void logo1Image1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.Stop(); timer2.Stop();
            if (Convert.ToString(logo1Image1.Tag) == igraFacade.Nivo.Logo)
            {
                igraFacade.Igrac.Rezultat += faktorRezultata;
                igraCanvas.Visibility = Visibility.Hidden;
                MessageBox.Show("Tačan odgovor!");
                if (laganaRadioButton.IsChecked == true) promijeniBrendove_Lagana();
                else if (srednjaRadioButton.IsChecked == true) promijeniBrendove_Srednja();
                else promijeniBrendove_Teska();
                if (igraFacade.Nivo.Broj < 7) startButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent)); //mora se mijenjati ako se doda novi novi
                else 
                {
                    igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
                    igraFacade.Rezultati.Add(igraFacade.Igrac.Rezultat);
                    igraFacade.Igrac.Rezultat = 0;
                    rezultatLabel.Content = Convert.ToInt32(igraFacade.Igrac.Rezultat);
                    MessageBox.Show("Čestitamo, uspješno ste riješili ovu razinu.");
                }
            }
            else
            {
                kadSeOdaberePogresanLogo();
            }
            rezultatLabel.Content = Convert.ToString(igraFacade.Igrac.Rezultat);
            if (igraFacade.Igrac.Rezultat >= igraFacade.Igrac.NajboljiRezultat) igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
        }

        private void logo2Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.Stop(); timer2.Stop();
            if (Convert.ToString(logo2Image.Tag) == igraFacade.Nivo.Logo)
            {
                igraFacade.Igrac.Rezultat += faktorRezultata;
                igraCanvas.Visibility = Visibility.Hidden;
                MessageBox.Show("Tačan odgovor!");
                if (laganaRadioButton.IsChecked == true) promijeniBrendove_Lagana();
                else if (srednjaRadioButton.IsChecked == true) promijeniBrendove_Srednja();
                else promijeniBrendove_Teska();
                if (igraFacade.Nivo.Broj < 7) startButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));//mora se mijenjati ako se doda novi novi
                else
                {
                    igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
                    igraFacade.Rezultati.Add(igraFacade.Igrac.Rezultat);
                    igraFacade.Igrac.Rezultat = 0;
                    rezultatLabel.Content = Convert.ToInt32(igraFacade.Igrac.Rezultat);
                    MessageBox.Show("Čestitamo, uspješno ste riješili ovu razinu.");
                }
            }
            else
            {
                kadSeOdaberePogresanLogo();
            }
            rezultatLabel.Content = Convert.ToString(igraFacade.Igrac.Rezultat);
            if (igraFacade.Igrac.Rezultat >= igraFacade.Igrac.NajboljiRezultat) igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;

        }

        private void logo3Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.Stop(); timer2.Stop();
            if (Convert.ToString(logo3Image.Tag) == igraFacade.Nivo.Logo)
            {
                igraFacade.Igrac.Rezultat += faktorRezultata;
                igraCanvas.Visibility = Visibility.Hidden;
                MessageBox.Show("Tačan odgovor!");
                if (laganaRadioButton.IsChecked == true) promijeniBrendove_Lagana();
                else if (srednjaRadioButton.IsChecked == true) promijeniBrendove_Srednja();
                else promijeniBrendove_Teska();
                if (igraFacade.Nivo.Broj < 7) startButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));//mora se mijenjati ako se doda novi novi
                else
                {
                    igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
                    igraFacade.Rezultati.Add(igraFacade.Igrac.Rezultat);
                    igraFacade.Igrac.Rezultat = 0;
                    rezultatLabel.Content = Convert.ToInt32(igraFacade.Igrac.Rezultat);
                    MessageBox.Show("Čestitamo, uspješno ste riješili ovu razinu.");
                }
            }
            else
            {
                kadSeOdaberePogresanLogo();
            }
            rezultatLabel.Content = Convert.ToString(igraFacade.Igrac.Rezultat);
            if (igraFacade.Igrac.Rezultat >= igraFacade.Igrac.NajboljiRezultat) igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;

        }

        private void logo4Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.Stop(); timer2.Stop();
            if (Convert.ToString(logo4Image.Tag) == igraFacade.Nivo.Logo)
            {
                igraFacade.Igrac.Rezultat += faktorRezultata;
                igraCanvas.Visibility = Visibility.Hidden;
                MessageBox.Show("Tačan odgovor!");
                if (srednjaRadioButton.IsChecked == true) promijeniBrendove_Srednja();
                else promijeniBrendove_Teska();
                if(igraFacade.Nivo.Broj < 7) startButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                else
                {
                    igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
                    igraFacade.Rezultati.Add(igraFacade.Igrac.Rezultat);
                    igraFacade.Igrac.Rezultat = 0;
                    rezultatLabel.Content = Convert.ToInt32(igraFacade.Igrac.Rezultat);
                    MessageBox.Show("Čestitamo, uspješno ste riješili ovu razinu.");
                }
            }
            else
            {
                kadSeOdaberePogresanLogo();
            }
            rezultatLabel.Content = Convert.ToString(igraFacade.Igrac.Rezultat);
            if (igraFacade.Igrac.Rezultat >= igraFacade.Igrac.NajboljiRezultat) igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
        }

        private void logo5Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            timer.Stop(); timer2.Stop();
            if (Convert.ToString(logo5Image.Tag) == igraFacade.Nivo.Logo)
            {
                igraFacade.Igrac.Rezultat += faktorRezultata;
                igraCanvas.Visibility = Visibility.Hidden;
                MessageBox.Show("Tačan odgovor!");
                if (teskaRadioButton.IsChecked == true) promijeniBrendove_Teska();
                if (igraFacade.Nivo.Broj < 7) startButton.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                else
                {
                    igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
                    igraFacade.Rezultati.Add(igraFacade.Igrac.Rezultat);
                    igraFacade.Igrac.Rezultat = 0;
                    rezultatLabel.Content = Convert.ToInt32(igraFacade.Igrac.Rezultat);
                    MessageBox.Show("Čestitamo, uspješno ste riješili ovu razinu.");
                }
            }
            else
            {
                kadSeOdaberePogresanLogo();
            }
            rezultatLabel.Content = Convert.ToString(igraFacade.Igrac.Rezultat);
            if (igraFacade.Igrac.Rezultat >= igraFacade.Igrac.NajboljiRezultat) igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
        }

        private void timer_Tick(object sender, EventArgs e) 
        {
            
            timer.Stop();
            timer2.Stop();
            igraCanvas.Visibility = Visibility.Hidden;
            if (istekloVrijeme)
            {
                istekloVrijeme = false;
                igraFacade.Nivo.Broj = 0;
                igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
                igraFacade.Rezultati.Add(igraFacade.Igrac.Rezultat);
                igraFacade.Igrac.Rezultat = 0;
                rezultatLabel.Content = Convert.ToInt32(igraFacade.Igrac.Rezultat);
                if (laganaRadioButton.IsChecked == true) { brojac = 0; promijeniBrendove_Lagana(); }
                else if (srednjaRadioButton.IsChecked == true) { brojacS = 0; promijeniBrendove_Srednja(); }
                else { brojacT = 0; promijeniBrendove_Teska(); }
                MessageBox.Show("Vrijeme vam je isteklo! Kliknite na start i pokušajte ponovo!");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RezultatiWindow rezWindow = new RezultatiWindow();
            rezWindow.Show();
            igraFacade.Rezultati.Sort();
            if (igraFacade.Rezultati.Count >= 1) rezWindow.prviLabel.Content = "1. " + igraFacade.Igrac.Naziv + " " + igraFacade.Rezultati.ElementAt(igraFacade.Rezultati.Count - 1);
            if (igraFacade.Rezultati.Count >= 2) rezWindow.drugiLabel.Content = "2. " + igraFacade.Igrac.Naziv + " " + igraFacade.Rezultati.ElementAt(igraFacade.Rezultati.Count - 2);
            if (igraFacade.Rezultati.Count >= 3) rezWindow.treciLabel.Content = "3. " + igraFacade.Igrac.Naziv + " " + igraFacade.Rezultati.ElementAt(igraFacade.Rezultati.Count - 3);
            if (igraFacade.Rezultati.Count >= 4) rezWindow.cetvrtiLabel.Content = "4. " + igraFacade.Igrac.Naziv + " " + igraFacade.Rezultati.ElementAt(igraFacade.Rezultati.Count - 4);
            if (igraFacade.Rezultati.Count >= 5) rezWindow.petiLabel.Content = "5. " + igraFacade.Igrac.Naziv + " " + igraFacade.Rezultati.ElementAt(igraFacade.Rezultati.Count - 5);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void promijeniBrendove_Lagana()
        {            
            string[] brendovi = {"Mercedes.png", "Audi.png", "VW.png", // ovo su nivoi
                                 "Renault.png", "BMW.png", "Honda.png",
                                 "Mazda.png", "Opel.png", "Skoda.png",
                                 "Citroen.png", "Ferrari.png", "Fiat.png",
                                 "Hyundai.png", "Mitsubishi.png", "Chevrolet.png",
                                 "Peugeot.png", "Ford.png", "Suzuki.png",
                                 "Volvo.png", "Lexus.png", "Lamborghini.png"};
            if (brojac == 21) { return; }
            string s = brendovi[brojac];
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri(s, UriKind.Relative);
            bi1.EndInit();
            logo1Image1.Source = bi1;
            logo1Image1.Tag = s.Split('.')[0];

            s = brendovi[brojac+1];
            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri(s, UriKind.Relative);
            bi2.EndInit();
            logo2Image.Source = bi2;
            logo2Image.Tag = s.Split('.')[0];

            s = brendovi[brojac+2];
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(s, UriKind.Relative);
            bi3.EndInit();
            logo3Image.Source = bi3;
            logo3Image.Tag = s.Split('.')[0];
            brojac += 3;
        }

        public void promijeniBrendove_Srednja()
        {
            string[] brendovi = {"Bentley.png", "Citroen.png", "Subaru.png", "Daewoo.png", // ovo su nivoi
                                 "Lexus.png", "Dodge.png", "Yamaha.png", "Kia.png",
                                 "Skoda.png", "Lancia.png", "Jeep.png", "Saab.png",
                                 "Jaguar.png", "BMW.png", "Lada.png", "Dacia.png",
                                 "Ford.png", "Lamborghini.png", "Tesla.png", "Austin.png",
                                 "Lotus.png", "Volvo.png", "Suzuki.png", "Vespa.png",
                                 "Chevrolet.png", "Bugatti.png", "Land Rover.png", "Ferrari.png"};
            if (brojacS == 28) { return; }
            string s = brendovi[brojacS];
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri(s, UriKind.Relative);
            bi1.EndInit();
            logo1Image1.Source = bi1;
            logo1Image1.Tag = s.Split('.')[0];

            s = brendovi[brojacS + 1];
            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri(s, UriKind.Relative);
            bi2.EndInit();
            logo2Image.Source = bi2;
            logo2Image.Tag = s.Split('.')[0];

            s = brendovi[brojacS + 2];
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(s, UriKind.Relative);
            bi3.EndInit();
            logo3Image.Source = bi3;
            logo3Image.Tag = s.Split('.')[0];

            s = brendovi[brojacS + 3];
            BitmapImage bi4 = new BitmapImage();
            bi4.BeginInit();
            bi4.UriSource = new Uri(s, UriKind.Relative);
            bi4.EndInit();
            logo4Image.Source = bi4;
            logo4Image.Tag = s.Split('.')[0];
            brojacS += 4;
        }

        public void promijeniBrendove_Teska()
        {
            string[] brendovi = {"Ferrari.png", "Tesla.png", "Daewoo.png", "Lincoln.png", "Rolls Royce.png", // ovo su nivoi
                                 "Jawa.png", "Audi.png", "Hyundai.png", "Saab.png", "Gaz.png",
                                 "Suzuki.png", "Seat.png", "BMW.png", "Lotus.png", "Austin.png",
                                 "Lamborghini.png", "Rover.png", "Zastava.png", "Lancia.png", "Skoda.png",
                                 "Yugo.png", "Ford.png", "Yamaha.png", "Citroen.png", "Jawa.png",
                                 "Piaggio.png", "Liaz.png", "LDV.png", "Proton.png", "Elfin.png",
                                 "Veritas.png", "Autobacs.png", "Eagle.png", "Franklin.png", "Hillman.png"};
            if (brojacT == 35) { return; }
            string s = brendovi[brojacT];
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri(s, UriKind.Relative);
            bi1.EndInit();
            logo1Image1.Source = bi1;
            logo1Image1.Tag = s.Split('.')[0];

            s = brendovi[brojacT + 1];
            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri(s, UriKind.Relative);
            bi2.EndInit();
            logo2Image.Source = bi2;
            logo2Image.Tag = s.Split('.')[0];

            s = brendovi[brojacT + 2];
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(s, UriKind.Relative);
            bi3.EndInit();
            logo3Image.Source = bi3;
            logo3Image.Tag = s.Split('.')[0];

            s = brendovi[brojacT + 3];
            BitmapImage bi4 = new BitmapImage();
            bi4.BeginInit();
            bi4.UriSource = new Uri(s, UriKind.Relative);
            bi4.EndInit();
            logo4Image.Source = bi4;
            logo4Image.Tag = s.Split('.')[0];

            s = brendovi[brojacT + 4];
            BitmapImage bi5 = new BitmapImage();
            bi5.BeginInit();
            bi5.UriSource = new Uri(s, UriKind.Relative);
            bi5.EndInit();
            logo5Image.Source = bi5;
            logo5Image.Tag = s.Split('.')[0];
            brojacT += 5;
        }

        public void kadSeOdaberePogresanLogo()
        {
            igraFacade.Igrac.NajboljiRezultat = igraFacade.Igrac.Rezultat;
            igraFacade.Rezultati.Add(igraFacade.Igrac.Rezultat);
            igraFacade.Igrac.Rezultat = 0;
            rezultatLabel.Content = Convert.ToInt32(igraFacade.Igrac.Rezultat);
            //igraFacade.Igrac.Rezultat -= 1;
            igraCanvas.Visibility = Visibility.Hidden;
            igraFacade.Nivo.Broj = 0;
            brojac = 3;
            brojacS = 4;
            brojacT = 5;
            string s;
            if (laganaRadioButton.IsChecked == true) s = "Audi.png";
            else if (srednjaRadioButton.IsChecked == true) s = "Bentley.png";
            else s = "Ferrari.png";
            BitmapImage bi1 = new BitmapImage();
            bi1.BeginInit();
            bi1.UriSource = new Uri(s, UriKind.Relative);
            bi1.EndInit();
            logo1Image1.Source = bi1;
            logo1Image1.Tag = s.Split('.')[0];

            if (laganaRadioButton.IsChecked == true) s = "Mercedes.png";
            else if (srednjaRadioButton.IsChecked == true) s = "Citroen.png";
            else s = "Tesla.png";
            BitmapImage bi2 = new BitmapImage();
            bi2.BeginInit();
            bi2.UriSource = new Uri(s, UriKind.Relative);
            bi2.EndInit();
            logo2Image.Source = bi2;
            logo2Image.Tag = s.Split('.')[0];

            if (laganaRadioButton.IsChecked == true) s = "VW.png";
            else if (srednjaRadioButton.IsChecked == true) s = "Subaru.png";
            else s = "Daewoo.png";
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(s, UriKind.Relative);
            bi3.EndInit();
            logo3Image.Source = bi3;
            logo3Image.Tag = s.Split('.')[0];

            if (srednjaRadioButton.IsChecked == true || teskaRadioButton.IsChecked == true)
            {
                if (srednjaRadioButton.IsChecked == true) s = "Daewoo.png";
                else s = "Lincoln.png";
                BitmapImage bi4 = new BitmapImage();
                bi4.BeginInit();
                bi4.UriSource = new Uri(s, UriKind.Relative);
                bi4.EndInit();
                logo4Image.Source = bi4;
                logo4Image.Tag = s.Split('.')[0];
            }

            if (teskaRadioButton.IsChecked == true)
            {
                s = "Rolls Royce.png";
                BitmapImage bi5 = new BitmapImage();
                bi5.BeginInit();
                bi5.UriSource = new Uri(s, UriKind.Relative);
                bi5.EndInit();
                logo5Image.Source = bi5;
                logo5Image.Tag = s.Split('.')[0];
            }
            MessageBox.Show("Netačan odgovor! Kliknite na start i pokušajte ponovo!");
        }


    }
}
