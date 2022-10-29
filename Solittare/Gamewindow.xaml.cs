using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
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
using System.Windows.Threading;

namespace Solittare
{
    /// <summary>
    /// Interakční logika pro GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        Game main = new Game();
        Onlinemodule online;
        public object line;
        public object poss;
        MediaPlayer player = new MediaPlayer();

        public GameWindow()
        {
            InitializeComponent();
            poss = main;
            Paint();
            setupdis();
        }

        public GameWindow(object o)
        {
            InitializeComponent();
            poss = main;
            Paint();
            online = o as Onlinemodule;
            line = online;
            main.online(online);
            setupdis();
        }

        public void Paint()
        {
            deskoc.Children.Clear();

            for( int i = main.board.Count(); i > 0; i--)
            {
                Image img = new Image();

                int nm = 0;

                if (main.board[i - 1].cards.Count() == 0)
                {
                    img = new Image();                 
                    img.AllowDrop = true;
                    img.Source = new BitmapImage(new Uri("Resources/Cards/empty.png", UriKind.Relative));
                    img.VerticalAlignment = VerticalAlignment.Top;
                    img.HorizontalAlignment = HorizontalAlignment.Center;
                    img.Margin = new Thickness(5, 0, 5, 0);
                    img.Height = 450;
                    img.Tag = i-1;

                    img.Drop += new DragEventHandler(emptydrop);

                    Grid.SetColumn(img, i - 1);
                    deskoc.Children.Add(img);
                }
                else
                {
                    for (int u = main.board[i - 1].cards.Count(); u > 0; u--)
                    {
                        img = new Image();
                        string p1 = main.board[i - 1].cards[u - 1].color.ToString();
                        string p2 = main.board[i - 1].cards[u - 1].id.ToString();
                        if(main.board[i - 1].cards[u -1].isHiden == true)
                        {
                            img.Source = new BitmapImage(new Uri("Resources/Cards/blank.png", UriKind.Relative));
                        }
                        else
                        {
                            img.Source = new BitmapImage(new Uri("Resources/Cards/" + p1 + "/" + p2 + "n.png", UriKind.Relative));
                        }

                        img.MouseDown += new MouseButtonEventHandler(pickup);
                        img.Drop += new DragEventHandler(dropec);
                        img.VerticalAlignment = VerticalAlignment.Top;
                        img.HorizontalAlignment = HorizontalAlignment.Center;
                        img.Margin = new Thickness(5, nm * 60, 5, 0);
                        img.Height = 450;

                        int[] lol = new int[2] { u - 1, i - 1 };
                        img.Tag = lol;

                        Grid.SetColumn(img, i - 1);
                        deskoc.Children.Add(img);

                        nm++;
                        if (u == 1)
                        {
                            img.AllowDrop = true;
                        }
                    }
                }
            }
        }

        public void pickup(object sender, MouseEventArgs e)
        {
            Image l = sender as Image;
            int[] lul = l.Tag as int[];
            if(main.passable(lul[0], main.board[lul[1]]) == true)
            {
                Paint();
                DragDrop.DoDragDrop(l, l, DragDropEffects.Move);
                //MessageBox.Show("lu asi nějak to jede");
            }

            Paint();
        }

        public void emptydrop(object sender, DragEventArgs e)
        {
            Image spodek = sender as Image;
            int lul = (int)spodek.Tag;

            main.move(main.board[lul]);

            Paint();
        }

        public void dropec(object sender, DragEventArgs e)
        {
            Image spodek = sender as Image;
            int[] lul = spodek.Tag as int[];


            main.move(main.board[lul[1]]);

            Paint();
        }

        private void deal_Click(object sender, RoutedEventArgs e)
        {
            player.Open(new Uri("Resources/SFX/shuffle.wav", UriKind.Relative));
            if (main.pack.cards.Count == 0)
            {
                deal.IsEnabled = false;
                Paint();
            }
            else
            {
                main.deal();               
                player.Play();

                Paint();
            }

            if (main.pack.cards.Count == 0)
            {
                deal.IsEnabled = false;
                Paint();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.D)
            {
                Dev dev = new Dev(this);
                dev.Show();
            }
            if(e.Key == Key.Escape)
            {
                PMenu m = new PMenu(this);
                m.Show();
            }
        }

        private void tmchng(object sender, EventArgs e)
        {      
            tm.Content = main.time + "sec";
        }

        DispatcherTimer t = new DispatcherTimer();

        private void setupdis()
        {
            t.Interval = new TimeSpan(0,0,1);
            t.Tick += new EventHandler(tmchng);
            t.Start();
        }

        private void Window_Closed(object sender, System.ComponentModel.CancelEventArgs e)
        {
            main.Lose();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if()
            {

            }
        }

        //more mohlo by se to hebát co si budeme povídat

    }
}
