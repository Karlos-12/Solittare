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

namespace Solittare
{
    /// <summary>
    /// Interakční logika pro Dev.xaml
    /// </summary>
    public partial class Dev : Window
    {
        public GameWindow main;
        Game game;
        public Dev(GameWindow m)
        {
            InitializeComponent();
            main = m;
            game = m.poss as Game;
        }

        private void cl_Click(object sender, RoutedEventArgs e)
        {
            foreach(Stack n in game.board)
            {
                n.cards.Clear();
            }
            main.Paint();
            game.check();
        }

        private void addwin(object sender, RoutedEventArgs e)
        {
            game.Win();
        }

        private void upload(object sender, RoutedEventArgs e)
        {
            (main.line as Onlinemodule).newacount("lol", "123");
        }

        private void ggg(object sender, RoutedEventArgs e)
        {
            game.pack.cards = new List<Card>();
            foreach(Stack card in game.board)
            {
                card.cards = new List<Card>();
            }

            game.load(t.Text);
        }
    }
}
