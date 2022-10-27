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
        public MainWindow()
        {
            InitializeComponent();
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
                play_Click(sender, e);
            }
        }

        private void login(object sender, RoutedEventArgs e)
        {
            var xd = new Onlinemodule(nambox.Text, passbox.Text);
            if(xd.logged == true)
            {
                log = xd;
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
    }
}
