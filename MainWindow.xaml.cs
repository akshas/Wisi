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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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
        MartkplatzWindow markt;
        Kueche kueche = new Kueche();
        RessourcenWindow res = new RessourcenWindow();
        int EinwohnerLeftPos = 100;
        int EinwohnerTopPos = 150;
        
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
            foreach (Einwohner mensch in Einwohner.EinwohnerList)
            {
                mensch.Essen(Ressource.Brot);
                mensch.Essen(Ressource.Milch);
            }
            if (Ressource.Brot.Anzahl < 0 || Ressource.Milch.Anzahl < 0)
            {
                EndGame();
            }
        }



      
        
        #region Canvas Bearbeitung ---------------------------------




        private void AddOrRemoveItems(object sender, MouseButtonEventArgs e)
        {
            //if(e.OriginalSource is Rectangle)
            //{
            //    Rectangle activeRect = (Rectangle)e.OriginalSource;
            //    MainCanvas.Children.Remove(activeRect);
            //}
            //else
            //{
            //CreateElement(ImagePath);
            //}
        }
        private void CreateElement(string ImagePath)
        {
            Customcolor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
            ImageBrush element = new ImageBrush();
            element.ImageSource = new BitmapImage(new Uri(ImagePath, UriKind.Absolute));
            Rectangle newRect = new Rectangle
            {
                Width = 50,
                Height = 50,
                //Fill = Customcolor,
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

        private void MenuButtonClicked(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            
            switch (btn.Name)
            {
                case "Rathaus":
                    ImagePath = @"C:\Users\alex\source\repos\WiSi\WiSi\images\Rotes_Rathaus.png";
                    break;
                case "Haus":
                    ImagePath = @"C:\Users\alex\source\repos\WiSi\WiSi\images\house.png";
                    break;
                case "Kueche":
                    kueche.Show();
                    break;
                case "Ressourcen":
                    res.Show();
                    break;
                case "MarktBtn":
                    markt.Show();
                    break;
                case "Worker":
                    EinwhonerErzeugen();
                    var text = WorkerBlock.Children.OfType<TextBlock>();
                    text.ToArray()[0].Text = Einwohner.Anzahl.ToString();
                    break;
            }
        }
        #endregion


        #region Erzeugen Elemente
        /// <summary>
        /// Einwohner Erzeugen
        /// </summary>
        private void EinwhonerErzeugen()
        {
            if (Ressource.Brot.Anzahl > (Einwohner.Anzahl * 60) && Ressource.Milch.Anzahl > (Einwohner.Anzahl * 60))
            {
                new Einwohner(Einwohner.Anzahl + 1);
            }
            else
            {
                MessageBox.Show("Es gibt nicht genug Nahrungsmittel");
            }
        }

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
            Einwohner.StartEinwohnerErzeugen();
            WorkersAnzahlText.Text = Einwohner.Anzahl.ToString();
            Ressource.RessourcenErzeugen();
            RessourcenDisplay.ItemsSource = Ressource.ResList;
            markt = new MartkplatzWindow();
            MarktplatzErzeugen();

            foreach (Einwohner mensch in Einwohner.EinwohnerList)
            {
                mensch.Form = new Rectangle
                {
                    Width = 40,
                    Height = 40,
                    Fill = Brushes.Aqua
                };

                Canvas.SetLeft(mensch.Form, EinwohnerLeftPos);
                Canvas.SetTop(mensch.Form, EinwohnerTopPos);
                MainCanvas.Children.Add(mensch.Form);
                EinwohnerLeftPos += 50;
            }
            clock.Start();

        }
        
        private void EndGame()
        {
            clock.Stop();
        }

    }
}
