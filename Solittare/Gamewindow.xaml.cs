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
    /// Interakční logika pro GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        Game main = new Game();
        public GameWindow()
        {
            InitializeComponent();

            Paint();
        }

        public void Paint()
        {
            for( int i = main.board.Count(); i > 0; i--)
            {
                Image img = new Image();

                int nm = 1;
                for(int u = main.board[i -1].cards.Count(); u > 0; u--)
                {
                    string p1 = main.board[i - 1].cards[u - 1].color.ToString();
                    string p2 = main.board[i - 1].cards[u - 1].id.ToString();
                    img.Source = new BitmapImage(new Uri("Resources/Cards/" + p1 + "/" + p2 + "n.png", UriKind.Relative));
                    img.VerticalAlignment = VerticalAlignment.Top;
                    img.HorizontalAlignment = HorizontalAlignment.Center;
                    

                    Grid.SetColumn(img, i-1);
                    Grid.SetRow(img, 0);
                    img.Margin = new Thickness(5, nm * 15, 5, 0);
                    nm++;

                    deskoc.Children.Add(img);
                }
            }
        }
    }
}
