﻿using System;
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

namespace Solittare
{
    /// <summary>
    /// Interakční logika pro PMenu.xaml
    /// </summary>
    public partial class PMenu : Window
    {
        GameWindow gameWindow;
        public PMenu(GameWindow g)
        {
            gameWindow = g;
            InitializeComponent();

            try
            {
                if ((g.line as Onlinemodule).img != null && (g.line as Onlinemodule).img != "")
                {
                    img.Source = new BitmapImage(new Uri((g.line as Onlinemodule).img, UriKind.Absolute));
                }
            }
            catch
            { }
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ng(object sender, RoutedEventArgs e)
        {
            gameWindow.Close();
            MainWindow m = new MainWindow();
            m.Show();
            Close();
        }

        private void qt(object sender, RoutedEventArgs e)
        {
            gameWindow.Close();
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
