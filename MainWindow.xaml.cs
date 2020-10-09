using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using WiSi.Klassen;

namespace WiSi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Brush Customcolor;
        Random r = new Random();
        DispatcherTimer clock = new DispatcherTimer();
        string ImagePath = @"pack://application:,,,/images\townHall.png";

        // == Einwohner Variables ==
        Button bewegbarerEinwohner = new Button();
        bool EinwohnerDarfSichBewegen = false;
       
        // === Wohnhaus ===
        Wohnhaus wohnhaus;
        bool BaustelleIstVorbereitet = false;
        // Wohnhaus Button
        Button whBtn;

        Rathaus rathaus;
        MartkplatzWindow markt;

        // == Subwindows ==
        Kueche kueche = new Kueche();
        RessourcenWindow res = new RessourcenWindow();



        /// <summary>
        /// Connection
        /// </summary>
        DBConnection conn = new DBConnection();
        
        public MainWindow()
        {


            kueche.Width = 500;
            kueche.Height = 200;
            kueche.Topmost = true;

            res.Width = 500;
            res.Height = 200;
            res.Topmost = true;

            clock.Tick += MainEventTimer;
            clock.Interval = TimeSpan.FromSeconds(1);
            StartGame();
        }
        private void MainEventTimer(object sender, EventArgs e)
        {
            Task.Run(() => 
            {
                foreach (Einwohner mensch in Einwohner.EinwohnerList)
                {
                    Thread.Sleep(500);
                    mensch.Essen(Ressource.Brot);
                    mensch.Essen(Ressource.Milch);
                }

                if (Ressource.Brot.Anzahl < 0 || Ressource.Milch.Anzahl < 0)
                {
                    EndGame();
                }
            });
        }



      
        
        #region Canvas  ---------------------------------




        private void AddOrRemoveItems(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRect = (Rectangle)e.OriginalSource;
                MainCanvas.Children.Remove(activeRect);
            }
            else
            {
                CreateElement(ImagePath);
            }
        }

        private void CanvasClicked(object sender, MouseButtonEventArgs e)
        {
            if (EinwohnerDarfSichBewegen)
            {
                Canvas.SetLeft(bewegbarerEinwohner, Mouse.GetPosition(MainCanvas).X);
                Canvas.SetTop(bewegbarerEinwohner, Mouse.GetPosition(MainCanvas).Y);
            }

            if (BaustelleIstVorbereitet)
            {
                Canvas.SetLeft(whBtn, Mouse.GetPosition(MainCanvas).X);
                Canvas.SetTop(whBtn, Mouse.GetPosition(MainCanvas).Y);
                MainCanvas.Children.Add(whBtn);
                GebaeudePosition pos = new GebaeudePosition();
                pos.left = (int)Mouse.GetPosition(MainCanvas).X;
                pos.top = (int)Mouse.GetPosition(MainCanvas).Y;
                wohnhaus.Bauen(Ressource.zumBauen);
                wohnhaus.Position = pos;


                BaustelleIstVorbereitet = false;
            }
        }
        private void CanvasRightClicked(object sender, MouseButtonEventArgs e)
        {
            EinwohnerDarfSichBewegen = false;
            BaustelleIstVorbereitet = false;
            bewegbarerEinwohner.Background = Brushes.Aqua;
        }
        private void CreateElement(string ImagePath)
        {
            ImageBrush element = new ImageBrush();
            element.ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));
            Rectangle newRect = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = element,

                StrokeThickness = 3,
                Stroke = Brushes.BlanchedAlmond
            };
            Canvas.SetLeft(newRect, Mouse.GetPosition(MainCanvas).X);
            Canvas.SetTop(newRect, Mouse.GetPosition(MainCanvas).Y);


            MainCanvas.Children.Add(newRect);
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            double left = Mouse.GetPosition(MainCanvas).X;
            double top = Mouse.GetPosition(MainCanvas).Y;
            displayLeft.Text = "Left: " + left;
            displayTop.Text = "   Top: " + top;
        }
        #endregion

        /// <summary>
        /// MENU BUTTON CLICKED!!!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            
            switch (btn.Name)
            {
                case "Rathaus":
                    ImagePath = @"C:\Users\alex\source\repos\WiSi\WiSi\images\Rotes_Rathaus.png";
                    break;
                case "Haus":
                    //ImagePath = @"C:\Users\alex\source\repos\WiSi\WiSi\images\house.png";
                    WohnhausBauen();
                    break;
                case "Kueche":
                    if (kueche.hidden)
                    {
                        kueche.Show();
                        kueche.hidden = false;
                    }
                    else
                    {
                        kueche.Close();
                        kueche.hidden = true;
                    }
                    break;
                case "Ressourcen":
                    res.Show();
                    break;
                case "MarktBtn":
                    if (markt.hidden)
                    {
                        markt.Show();
                        markt.hidden = false;
                    }
                    else
                    {
                        markt.Close();
                        markt.hidden = true;
                    }
                    break;
                case "RathausBtn":
                    rathaus.ShowStatistic();
                    break;
                case "Worker":
                    EinwhonerErzeugen();
                    var text = WorkerBlock.Children.OfType<TextBlock>();
                    text.ToArray()[0].Text = Einwohner.Anzahl.ToString();
                    break;

            }
        }


        #region Erzeugen Elemente

        private void WohnhausBauen()
        {
            whBtn = new Button();
            wohnhaus = new Wohnhaus();
            whBtn.Content = wohnhaus.Bild;
            whBtn.Name = "Wohnhaus_" + wohnhaus.Id;
            BaustelleIstVorbereitet = true;
        }

        /// <summary>
        /// Erste 3 Einwohner erzeugen
        /// </summary>
        private void StartEinwohnerErzeugen()
        {
            for (int i = 1; i <= Einwohner.StartAnzahl; i++)
            {
                EinwhonerErzeugen();
            }
        }

        /// <summary>
        /// Einwohner Erzeugen
        /// </summary>
        private void EinwhonerErzeugen()
        {
            if ((Ressource.Brot.Anzahl > (Einwohner.Anzahl * 60) && Ressource.Milch.Anzahl > (Einwohner.Anzahl * 60)) && Einwohner.Anzahl < ((Wohnhaus.Anzahl + 1) * 3))
            {
                Button EwBtn = new Button();
                Einwohner newEinwohner = new Einwohner(Einwohner.Anzahl + 1);
                EwBtn.Width = newEinwohner.Form.Width;
                EwBtn.Height = newEinwohner.Form.Height;
                EwBtn.Background = newEinwohner.Form.Fill;
                EwBtn.Name = "Einwohner_" + newEinwohner.Id;
                EwBtn.Click += EinwohnerClicked;
                EwBtn.MouseRightButtonUp += BewegbarkeitLoeschen;
                Canvas.SetLeft(EwBtn, newEinwohner.Position.x);
                Canvas.SetTop(EwBtn, newEinwohner.Position.y);

                Canvas.SetZIndex(EwBtn, 3);
                MainCanvas.Children.Add(EwBtn);
            }
            else
            {
                MessageBox.Show("Es gibt nicht genug Nahrungsmittel");
            }
        }


        /// <summary>
        ///  Einwohner clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EinwohnerClicked(object sender, RoutedEventArgs e)
        {
            bewegbarerEinwohner.Background = Brushes.Aqua;
            Button btn = (Button)sender;

            bewegbarerEinwohner = btn;
            bewegbarerEinwohner.Background = Brushes.Tomato;
            EinwohnerDarfSichBewegen = true;
            

        }
        /// <summary>
        /// Nich Bewegen!                 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BewegbarkeitLoeschen(object sender, MouseButtonEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Background = Brushes.Aqua;
            EinwohnerDarfSichBewegen = false;
        }


        //-----------------------------------------------------------------
        /// <summary>
        /// Marktplatz
        /// </summary>
        private void MarktplatzErzeugen() {

            Button mpBtn = new Button();
            Marktplatz marktPlatz = new Marktplatz();
            mpBtn.Content = marktPlatz.Bild;
            mpBtn.Name = "MarktBtn";
            Canvas.SetLeft(mpBtn, marktPlatz.Position.left);
            Canvas.SetTop(mpBtn, marktPlatz.Position.top);
            
            
            mpBtn.Click += MenuButtonClicked;
            MainCanvas.Children.Add(mpBtn);
        }

        private void RathausErzeugen()
        {
            Button rhBtn = new Button();
            rathaus = new Rathaus("Rathaus");
            rhBtn.Content = rathaus.Bild;
            rhBtn.Name = "RathausBtn";
            Canvas.SetLeft(rhBtn, rathaus.Position.left);
            Canvas.SetTop(rhBtn, rathaus.Position.top);

            rhBtn.Click += MenuButtonClicked;
            MainCanvas.Children.Add(rhBtn);

        }

        #endregion

        //-------------------------------------------------------------------------------------------------------

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            kueche.canClose = true;
            kueche.Close();
            res.canClose = true;
            res.Close();
            markt.canClose = true;
            markt.Close();

        }


        /// <summary>
        /// START GAME
        /// </summary>
        private void StartGame()
        {
            InitializeComponent();

            MainCanvas.Focus();
            // -- Rathaus --
            RathausErzeugen();

            // -- Markt --
            Ressource.RessourcenErzeugen();
            RessourcenDisplay.ItemsSource = Ressource.ResList;
            markt = new MartkplatzWindow();
            MarktplatzErzeugen();

            // -- Einwohner --
            StartEinwohnerErzeugen();
            WorkersAnzahlText.Text = Einwohner.Anzahl.ToString();


            // -- Timer --
            clock.Start();

        }
        
        private void EndGame()
        {
            clock.Stop();
        }

        private void OnRessourceClicked(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "BergBtn":
                    
                    break;
                case "TeichBtn":

                    break;

                case "WaldBtn":

                    break;



            }
        }
    }
}
