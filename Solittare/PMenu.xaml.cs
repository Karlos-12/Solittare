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
        }
    }
}