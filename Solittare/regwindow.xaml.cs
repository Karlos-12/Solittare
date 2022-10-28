using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interakční logika pro regwindow.xaml
    /// </summary>
    public partial class regwindow : Window
    {
        public bool regster = false;
        MainWindow onlinesu;
        public regwindow(object on)
        {
            onlinesu = (MainWindow)on;
            InitializeComponent();
        }

        string stream;

        public void regsteror()
        {
            Onlinemodule onlinenum = new Onlinemodule("admin", "123");

            if(stream != null)
            {
                onlinenum.newacount(nambox.Text, passbox.Text, stream.ToString());
            }
            else
            {
                onlinenum.newacount(nambox.Text, passbox.Text);
            }

            Onlinemodule online = new Onlinemodule(nambox.Text, passbox.Text);

            MessageBox.Show("Registerd, now you can log in!");
            Close();
        }

        private void lf(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == "")
            {
                t.Text = t.Tag as string;
            }
        }

        private void gf(object sender, RoutedEventArgs e)
        {
            TextBox t = sender as TextBox;
            if (t.Text == t.Tag.ToString())
            {
                t.Text = "";
            }
        }

        private void jjj(object sender, RoutedEventArgs e)
        {
            regsteror();
        }

        private void imgupl(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            openFileDialog.ShowDialog();
            stream = openFileDialog.FileName;

            if(stream != null)
            {
                uimg.Content = "Image uploaded!";
                uimg.Background = new SolidColorBrush(Color.FromRgb(0,255,0));
            }
        }
    }
}
