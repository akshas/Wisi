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
using System.Data.SqlClient;
using System.Data;


namespace WiSi
{
    /// <summary>
    /// Interaction logic for RessourcenWindow.xaml
    /// </summary>
    public partial class RessourcenWindow : Window
    {
       public bool canClose = false;
        DBConnection conn = new DBConnection();
        public RessourcenWindow()
        {
            InitializeComponent();
            RessourcenTable.ItemsSource = Ressource.ResList;
        }
        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!canClose)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
