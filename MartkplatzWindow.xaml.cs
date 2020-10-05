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
        public MartkplatzWindow()
        {
            InitializeComponent();
        }
        private void OnWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!canClose)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
