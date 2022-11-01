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

namespace Solittare
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Onlinemodule log;
        public MainWindow(string usr = "", string psw = "")
        {
            InitializeComponent();
            if(usr != "" && psw != "")
            {
                var xd = new Onlinemodule(usr, psw);
                if (xd.logged == true)
                {
                    log = xd;
                    img.Source = new BitmapImage(new Uri(log.img, UriKind.Absolute));
                }
            }
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow(log);
            game.Show();
            Close();
        }

        private void cslose(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (exp.IsExpanded == true)
                {
                    login(sender, e);
                }
                else
                {
                    play_Click(sender, e);
                }
            }
        }

        public async void login(object sender, RoutedEventArgs e)
        {
            var xd = new Onlinemodule(nambox.Text, passbox.Text);
            if(xd.logged == true)
            {
                log = xd;
                img.Source = new BitmapImage(new Uri(log.img, UriKind.Absolute));
                await Task.Delay(1000);
                exp.IsExpanded = false;            
            }

        }

        private void lf(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if(t.Text == "")
            {
                t.Text = t.Tag as string;
            }
        }

        private void gf(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if(t.Text == t.Tag.ToString())
            {
                t.Text = "";
            }
        }

        private void setngs(object sender, RoutedEventArgs e)
        {
            Setings setings = new Setings(log);
            setings.Show();
        }

        private async void rege(object sender, RoutedEventArgs e)
        {
            regwindow regwindow = new regwindow(this);
            regwindow.Show();
        }

        private void load_click(object sender, RoutedEventArgs e)
        {            
            if(lcloadinpt.Text != null || lcloadinpt.Text != "")
            {
                GameWindow window = new GameWindow(log, true, lcloadinpt.Text);
                window.Show();
                Close();
            }
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;    
            if(txt.Text == "SSS here...")
            {
                txt.Text = "";
            }
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if(txt.Text == "")
            {
                txt.Text = "SSS here...";
            }
        }

        private void laddialogopne(object sender, RoutedEventArgs e)
        {
            loadec.Visibility = Visibility.Visible;
        }

        private async void serevrload(object sender, RoutedEventArgs e)
        {
            string a = await log.loadfromserver();
            GameWindow game = new GameWindow(log, true, a);
            game.Show();
            Close();
        }

        private void clsload(object sender, RoutedEventArgs e)
        {
            loadec.Visibility = Visibility.Hidden;
        }
    }
}
