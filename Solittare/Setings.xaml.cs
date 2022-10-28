using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Solittare
{
    /// <summary>
    /// Interakční logika pro Setings.xaml
    /// </summary>
    public partial class Setings : Window
    {
        public Setings()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://www.wikihow.com/Play-Solitaire");
            }
            catch
            {
                MessageBox.Show("A doprdele, internet zas není!");
            }
        }

        private void upl(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", new Uri("Resources", UriKind.Relative).ToString());
        }
    }
}
