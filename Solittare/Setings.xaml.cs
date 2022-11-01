using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace Solittare
{
    /// <summary>
    /// Interakční logika pro Setings.xaml
    /// </summary>
    public partial class Setings : Window
    {
        Onlinemodule onlinemodule;
        public Setings(object line = null)
        {
            InitializeComponent();
            if(line != null)
            {
                onlinemodule = line as Onlinemodule;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("explorer", "https://www.wikihow.com/Play-Solitaire");
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

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Process.Start("explorer", "https://github.com/Karlos-12/Solittare");
            }
            catch
            {
                MessageBox.Show("A doprdele, internet zas není!");
            }
        }

        private async void ping(object sender, RoutedEventArgs e)
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = "https://solitare-56915-default-rtdb.europe-west1.firebasedatabase.app/users/",
                AuthSecret = "zQmSN9g7qKvJBWnI4Gx4QjQBPaSoWdlEKFH0BA8G"
            };
            IFirebaseClient client;
            client = new FirebaseClient(config);
            try
            {
                await client.GetAsync("admin/wins");
                Thread.Sleep(1000);
                MessageBox.Show("The ping was sucseful!");
            }
            catch
            {
                MessageBox.Show("The server isnt able to be ping right now");
            }
        }

        private void delact(object sender, RoutedEventArgs e)
        {
            if(onlinemodule != null)
            {
                if (onlinemodule.logged == true)
                {
                    
                    
                    if ((MessageBox.Show("Are u sure u want to reset this acount?", "Warning", MessageBoxButton.YesNo) == MessageBoxResult.Yes))
                    {
                        onlinemodule.reset();
                        MessageBox.Show("Acount was sucsessfuly reseted");
                    }
                }
            }
        }
    }
}
