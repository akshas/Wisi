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
        string ImagePath = @"C:\Users\alex\source\repos\WiSi\WiSi\images\Rotes_Rathaus.png";
        ImageBrush BrushElement;
        Kueche kueche = new Kueche();


        public MainWindow()
        {
            InitializeComponent();
            kueche.Width = 500;
            kueche.Height = 200;
            kueche.Left = 75;
            kueche.Top = 720;
            
        }







        #region Canvas Bearbeitung
        private void AddOrRemoveItems(object sender, MouseButtonEventArgs e)
        {
            if(e.OriginalSource is Rectangle)
            {
                Rectangle activeRect = (Rectangle)e.OriginalSource;
                MainCanvas.Children.Remove(activeRect);
            }
            else
            {
                CreateElement(ImagePath);
            }
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
            }
        }
        #endregion
    }
}
