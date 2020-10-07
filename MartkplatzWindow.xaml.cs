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
        public bool hidden = true;
        Marktplatz mrktpltz;

        double BrotPreis = Ressource.Brot.Einkaufspreis;
        double EisenPreis = Ressource.Eisen.Einkaufspreis;
        double HolzPreis = Ressource.Holz.Einkaufspreis;
        double MilchPreis = Ressource.Milch.Einkaufspreis;
        double SteinPreis = Ressource.Stein.Einkaufspreis;

        double BrotVPreis = Ressource.Brot.Verkaufspreis;
        double EisenVPreis = Ressource.Eisen.Verkaufspreis;
        double HolzVPreis = Ressource.Holz.Verkaufspreis;
        double MilchVPreis = Ressource.Milch.Verkaufspreis;
        double SteinVPreis = Ressource.Stein.Verkaufspreis;


        double SteinKaufSumme;
        double EisenKaufSumme;
        double HolzKaufSumme;
        double MilchKaufSumme;
        double BrotKaufSumme;

        double GesamtErg = 0;


        double SteinVerkaufSumme;
        double EisenVerkaufSumme;
        double HolzVerkaufSumme;
        double MilchVerkaufSumme;
        double BrotVerkaufSumme;

        double GesamtVerkaufErg = 0;

        public MartkplatzWindow()
        {
            InitializeComponent();
            mrktpltz = new Marktplatz();

            DisplaySteinPreis.Text = TextInitialisieren("Stein", SteinPreis);
            DisplayEisenPreis.Text = TextInitialisieren("Eisen", EisenPreis);
            DisplayHolzPreis.Text = TextInitialisieren("Holz", HolzPreis);
            DisplayMilchPreis.Text = TextInitialisieren("Milch", MilchPreis);
            DisplayBrotPreis.Text = TextInitialisieren("Brot", BrotPreis);

            DisplaySteinVPreis.Text = TextInitialisieren("Stein", SteinVPreis);
            DisplayEisenVPreis.Text = TextInitialisieren("Eisen", EisenVPreis);
            DisplayHolzVPreis.Text = TextInitialisieren("Holz", HolzVPreis);
            DisplayMilchVPreis.Text = TextInitialisieren("Milch", MilchVPreis);
            DisplayBrotVPreis.Text = TextInitialisieren("Brot", BrotVPreis);
        }

        //protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        //{
        //    base.OnMouseLeftButtonDown(e);

        //    // Begin dragging the window
        //    this.DragMove();
        //}

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
                    DisplayHolzPreis.Text = TextInitialisieren("Holz", HolzPreis) + " x " + tb.Text + " = " + (HolzKaufSumme = HolzPreis * DoubledTbText);
                    break;
                case "AnzahlBrotKaufen":
                    DisplayMilchPreis.Text = TextInitialisieren("Brot", MilchPreis) + " x " + tb.Text + " = " + (MilchKaufSumme = MilchPreis * DoubledTbText);
                    break;
                case "AnzahlMilchKaufen":
                    DisplayBrotPreis.Text = TextInitialisieren("Milch", BrotPreis) + " x " + tb.Text + " = " + (BrotKaufSumme = BrotPreis * DoubledTbText);
                    break;

                //--VERKAUFEN--
                case "AnzahlSteinVerkaufen":
                    DisplaySteinVPreis.Text = TextInitialisieren("Stein", SteinVPreis) + " x " + tb.Text + " = " + (SteinVerkaufSumme = SteinVPreis * DoubledTbText);
                    break;
                case "AnzahlEisenVerkaufen":
                    DisplayEisenVPreis.Text = TextInitialisieren("Eisen", EisenVPreis) + " x " + tb.Text + " = " + (EisenVerkaufSumme = EisenVPreis * DoubledTbText);
                    break;
                case "AnzahlHolzVerkaufen":
                    DisplayHolzVPreis.Text = TextInitialisieren("Holz", HolzVPreis) + " x " + tb.Text + " = " + (HolzVerkaufSumme = HolzVPreis * DoubledTbText);
                    break;
                case "AnzahlBrotVerkaufen":
                    DisplayMilchVPreis.Text = TextInitialisieren("Brot", MilchVPreis) + " x " + tb.Text + " = " + (MilchVerkaufSumme = MilchVPreis * DoubledTbText);
                    break;
                case "AnzahlMilchVerkaufen":
                    DisplayBrotVPreis.Text = TextInitialisieren("Milch", BrotVPreis) + " x " + tb.Text + " = " + (BrotVerkaufSumme = BrotVPreis * DoubledTbText);
                    break;
            }
            GesamtErg = SteinKaufSumme + EisenKaufSumme + HolzKaufSumme + MilchKaufSumme + BrotKaufSumme;
            DisplayGesamtPreis.Text = "Summe: " + GesamtErg.ToString();

            GesamtVerkaufErg = SteinVerkaufSumme + EisenVerkaufSumme + HolzVerkaufSumme + MilchVerkaufSumme + BrotVerkaufSumme;
            DisplayGesamtVPreis.Text = "Summe: " + GesamtVerkaufErg.ToString();

        }

        private void PutResourceInDict(Dictionary<Ressource, int>list, Ressource res, int anzahl)
        {
            if (!list.ContainsKey(res))
            {
                list.Add(res, anzahl);
            }
            else
            {
               list[res] = anzahl;
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
                        PutResourceInDict(mrktpltz.DingeZumKaufen, Ressource.Stein, NumberedTbText);
                        break;
                    case "AnzahlEisenKaufen":
                        PutResourceInDict(mrktpltz.DingeZumKaufen, Ressource.Eisen, NumberedTbText);
                        break;
                    case "AnzahlHolzKaufen":
                        PutResourceInDict(mrktpltz.DingeZumKaufen, Ressource.Holz, NumberedTbText);
                        break;
                    case "AnzahlBrotKaufen":
                        PutResourceInDict(mrktpltz.DingeZumKaufen, Ressource.Brot, NumberedTbText);
                        break;
                    case "AnzahlMilchKaufen":
                        PutResourceInDict(mrktpltz.DingeZumKaufen, Ressource.Milch, NumberedTbText);
                        break;

                    //-- VERKAUFEN --
                    case "AnzahlSteinVerkaufen":
                        PutResourceInDict(mrktpltz.DingeZumVerkaufen, Ressource.Stein, NumberedTbText);
                        break;
                    case "AnzahlEisenVerkaufen":
                        PutResourceInDict(mrktpltz.DingeZumVerkaufen, Ressource.Eisen, NumberedTbText);
                        break;
                    case "AnzahlHolzVerkaufen":
                        PutResourceInDict(mrktpltz.DingeZumVerkaufen, Ressource.Holz, NumberedTbText);
                        break;
                    case "AnzahlBrotVerkaufen":
                        PutResourceInDict(mrktpltz.DingeZumVerkaufen, Ressource.Brot, NumberedTbText);
                        break;
                    case "AnzahlMilchVerkaufen":
                        PutResourceInDict(mrktpltz.DingeZumVerkaufen, Ressource.Milch, NumberedTbText);
                        break;
                }
            }
        }

        private void OnKaufenClick(object sender, RoutedEventArgs e)
        {
            PutResourceInDict(mrktpltz.DingeZumKaufen, Ressource.Gold, (int)GesamtErg);
            mrktpltz.Kaufen(mrktpltz.DingeZumKaufen);
            GesamtErg = 0;
            DisplayGesamtPreis.Text = "";
            SteinKaufSumme = EisenKaufSumme = HolzKaufSumme = MilchKaufSumme = BrotKaufSumme = 0;
            AnzahlSteinKaufen.Text = AnzahlEisenKaufen.Text = AnzahlHolzKaufen.Text = AnzahlBrotKaufen.Text = AnzahlMilchKaufen.Text = "";
        }

        private void OnVerkaufenClick(object sender, RoutedEventArgs e)
        {
            PutResourceInDict(mrktpltz.DingeZumVerkaufen, Ressource.Gold, (int)GesamtVerkaufErg);
            mrktpltz.Verkaufen(mrktpltz.DingeZumVerkaufen);

            GesamtVerkaufErg = 0;
            DisplayGesamtVPreis.Text = "";
            SteinVerkaufSumme = EisenVerkaufSumme = HolzVerkaufSumme = MilchVerkaufSumme = BrotVerkaufSumme = 0;
            AnzahlSteinVerkaufen.Text = AnzahlEisenVerkaufen.Text = AnzahlHolzVerkaufen.Text = AnzahlBrotVerkaufen.Text = AnzahlMilchVerkaufen.Text = "";
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}