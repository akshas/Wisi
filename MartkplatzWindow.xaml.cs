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

        double BrotPreis = Ressource.Brot.Einkaufspreis;
        double EisenPreis = Ressource.Eisen.Einkaufspreis;
        double HolzPreis = Ressource.Holz.Einkaufspreis;
        double MilchPreis = Ressource.Milch.Einkaufspreis;
        double SteinPreis = Ressource.Stein.Einkaufspreis;

        double SteinKaufSumme;
        double EisenKaufSumme;
        double HolzKaufSumme;
        double MilchKaufSumme;
        double BrotKaufSumme;
        Marktplatz mrktpltz;
        double GesamtErg = 0;

        Dictionary<Ressource, int> zumKaufen = new Dictionary<Ressource, int>();

        public MartkplatzWindow()
        {
            InitializeComponent();
            mrktpltz = new Marktplatz();

            DisplaySteinPreis.Text = TextInitialisieren("Stein", SteinPreis);
            DisplayEisenPreis.Text = TextInitialisieren("Eisen", EisenPreis);
            DisplayHolzPreis.Text = TextInitialisieren("Holz", HolzPreis);
            DisplayMilchPreis.Text = TextInitialisieren("Milch", MilchPreis);
            DisplayBrotPreis.Text = TextInitialisieren("Brot", BrotPreis);
        }

        private string TextInitialisieren(string name, double resPreis)
        {
            return name + ": " + resPreis + " €";
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
            bool ok = Double.TryParse(tb.Text, out double DoubledTbText);

            switch (tb.Name)
            {

                case "AnzahlSteinKaufen":
                    DisplaySteinPreis.Text = TextInitialisieren("Stein", SteinPreis) + " x " + tb.Text + " = " + (SteinKaufSumme = SteinPreis * DoubledTbText);
                    break;
                case "AnzahlEisenKaufen":
                    DisplayEisenPreis.Text = TextInitialisieren("Eisen", EisenPreis) + " x " + tb.Text + " = " + (EisenKaufSumme = EisenPreis * DoubledTbText);
                    break;
                case "AnzahlHolzKaufen":
                    DisplayHolzPreis.Text = TextInitialisieren("Holz", HolzPreis) + " x " + tb.Text + " = " + ( HolzKaufSumme = HolzPreis * DoubledTbText);
                    break;
                case "AnzahlBrotKaufen":
                    DisplayMilchPreis.Text = TextInitialisieren("Brot", MilchPreis) + " x " + tb.Text + " = " + (MilchKaufSumme = MilchPreis * DoubledTbText);
                    break;
                case "AnzahlMilchKaufen":
                    DisplayBrotPreis.Text = TextInitialisieren("Milch", BrotPreis) + " x " + tb.Text + " = " + (BrotKaufSumme = BrotPreis * DoubledTbText);
                    break;
            }
            GesamtErg = SteinKaufSumme + EisenKaufSumme + HolzKaufSumme + MilchKaufSumme + BrotKaufSumme;
            DisplayGesamtPreis.Text = "Summe: " +  GesamtErg.ToString();
        }

        private void PutResourceInDict(Ressource res, int anzahl)
        {
            if (!mrktpltz.DingeZumKaufen.ContainsKey(res))
            {
                mrktpltz.DingeZumKaufen.Add(res, anzahl);
            }
            else
            {
                mrktpltz.DingeZumKaufen[res] = anzahl;
            }
        }
        private void OnLostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            bool ok = Int32.TryParse(tb.Text, out int NumberedTbText);

            if (ok)
            {
                switch (tb.Name)
                {

                    case "AnzahlSteinKaufen":
                        PutResourceInDict(Ressource.Stein, NumberedTbText);
                        break;
                    case "AnzahlEisenKaufen":
                        PutResourceInDict(Ressource.Eisen, NumberedTbText);
                        break;
                    case "AnzahlHolzKaufen":
                        PutResourceInDict(Ressource.Holz, NumberedTbText);
                        break;
                    case "AnzahlBrotKaufen":
                        PutResourceInDict(Ressource.Brot, NumberedTbText);
                        break;
                    case "AnzahlMilchKaufen":
                        PutResourceInDict(Ressource.Milch, NumberedTbText);
                        break;
                }
            }
        }

        private void OnKaufenClick(object sender, RoutedEventArgs e)
        {
            PutResourceInDict(Ressource.Gold, (int)GesamtErg);
            mrktpltz.Kaufen(mrktpltz.DingeZumKaufen);
        }
    }
}
