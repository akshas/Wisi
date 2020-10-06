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
using System.Windows.Shapes;

namespace WiSi
{
    /// <summary>
    /// Interaction logic for MartkplatzWindow.xaml
    /// </summary>
    public partial class MartkplatzWindow : Window
    {
        public bool canClose = false;
        //Ressource Brot = Ressource.Brot;
        //double BrotPreis = Ressource.Brot.Einkaufspreis;
        //double EisenPreis = Ressource.Eisen.Einkaufspreis;
        //double HolzPreis = Ressource.Holz.Einkaufspreis;
        //double MilchPreis = Ressource.Milch.Einkaufspreis;
        //double SteinPreis = Ressource.Stein.Einkaufspreis;

        public MartkplatzWindow()
        {
            InitializeComponent();

       
            //DisplaySteinPreis.Text = "Stein: " + SteinPreis.ToString();
            //DisplayEisenPreis.Text = "Eisen: " + EisenPreis.ToString();
            //DisplayHolzPreis.Text = "Holz: " + HolzPreis.ToString();
            //DisplayMilchPreis.Text = "Milch: " + MilchPreis.ToString();
            //DisplayBrotPreis.Text = "Brot: " + BrotPreis.ToString();
            //MessageBox.Show(Brot.Name.ToString());
        }
        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true;
                this.Hide();
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            switch(tb.Name)
            {
                case "DisplaySteinPreis":
                    break;
            }
        }

        private void OnLostFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}
