using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Solittare
{
    internal class Game
    {
        public Stack[] board = new Stack[9];
        public Stack pack = new Stack();

        public int moves = 0;
        public int time = 0;
        public int deals = 13;

        Onlinemodule onlines;    

        DispatcherTimer timer = new DispatcherTimer();
        //focus ne focus sto start času
        public void online(Onlinemodule m)
        {
            onlines = m;
        }

        public Game(bool loadis = false, string s = null)
        {
            pack = new Stack(true);
            for (int i = 9; i > 0; i--)
            {
                board[i - 1] = new Stack();
            }

            if (loadis == false && s == null)
            {
                deal(false);
                deal(false);
                deal(false);
            }
            else
            {
                load(s);
            }


            check();

            timer.Interval = new TimeSpan(0,0,1);
            timer.Tick += new EventHandler(dispatch);

            timer.Start();
        }

        private bool ccc(Stack s)
        {
            if(s.cards.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void deal(bool nonfirst = true)
        {
            if (board.All(ccc) || nonfirst == false)
            {
                Random random = new Random();

                for (int i = 9; i > 0; i--)
                {
                    int u = 0;
                    if (pack.cards.Count != 0)
                    {
                        u = random.Next(pack.cards.Count - 1);

                        if (board[i - 1].cards.Count() - 1 != -1)
                        {
                            board[i - 1].cards.Insert(0, pack.cards[u]);
                        }
                        else
                        {
                            board[i - 1].cards.Insert(0, pack.cards[u]);
                        }
                        pack.cards.RemoveAt(u);
                    }
                    else
                    {
                        MessageBox.Show("No deal remainnig!");
                        i = 0;

                    }

                    if (nonfirst == true)
                    {
                        check();
                    }                   
                }
                deals--;
            }
            else
            {
                MessageBox.Show("Máš tam volne mista brácho");
            }
        }

        public bool passable(int stcakindx, Stack n)
        //zjištuje jestli to můžeš vůbec takhle vzít
        {
            picked.Clear();
            for (int i = 0; i <= stcakindx; i++)
            {
                if(i != 0)
                { 
                    if (n.cards[i].id  == n.cards[i -1].id  +1)
                    {
                        picked.Add(n.cards[i]);
                        lastpicked = n;
                    }
                    else
                    {
                        picked.Clear();
                        return false;
                    }
                }
                else
                {
                    picked.Add(n.cards[i]);
                    lastpicked = n;
                }
            }
            check();

            return true;         
        }

        public Stack lastpicked;
        public List<Card> picked = new List<Card>();

        public bool move(Stack target)
        //zjištuje jestli to tam můžeš položit
        {
            if(target.cards.Count == 0)
            {
                target.cards.InsertRange(0, picked);
                lastpicked.cards.RemoveRange(0, picked.Count());

                picked.Clear();
                check();
                moves++;
                return true;
            }
            else if (picked[picked.Count - 1].id +1 == target.cards[0].id)
            {
                target.cards.InsertRange(0, picked);
                lastpicked.cards.RemoveRange(0, picked.Count());

                picked.Clear();
                check();
                moves++;
                return true;
            }
            else
            {
                picked.Clear();
                check();
                return false;
            }
            
        }

        public void check()
        {
            foreach(Stack stack in board)
            {
                if(stack.cards.Count != 0)
                {
                    stack.cards[0].isHiden = false;
                }

                int c = 1;

                try
                {
                    foreach (Card card in stack.cards)
                    {
                        if (card.id == c)
                        {
                            c++;
                            if (c == 14)
                            {
                                MessageBox.Show("lol!");
                                stack.cards.RemoveRange(0, 13);
                            }
                        }
                        else
                        {
                            c = 1;
                        }
                    }
                }
                catch
                { }
            }

            if(board.All(isprazdn) && pack.cards.Count == 0)
            {
                Win();
            }

            
        }
        private bool isprazdn(Stack n)
        {
            if(n.cards.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Win()
        {
            timer.Stop();
            MessageBox.Show("You have won!");
            if (onlines != null)
            {
                onlines.gamewrite(true, time);
            }
        }

        public void dispatch(object sender, EventArgs e)
        {
            time++;
        }

        public void timechange()
        {
            if(timer.IsEnabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }
        }

        public void Lose()
        {
            timer.Stop();
            if(onlines != null)
            {
                onlines.gamewrite(false, time);
            }
        }

        public string save()
        {
            string sss = "";
            foreach(Stack s in board)
            {
                foreach(Card c in s.cards)
                {
                    sss += c.id;
                }
                sss += "/";
            }
            if(pack.cards.Count != 0)
            {
                foreach(Card sc in pack.cards)
                {
                    sss += sc.id;
                }
            }

            return sss;
        }

        public void load(string csss)
        {
            int stc = 0;
            for (int i = 0; i < csss.Length; i++)
            {
                char c = csss[i];
                
                
                if(c == char.Parse("/"))
                {
                    stc++;                  
                }
                else if (stc == 9)
                {
                    string idk = csss.Substring(i);
                    for (int z = 0; z < idk.Length; z++)
                    {
                        char d = idk[z];
                        pack.cards.Add(new Card(int.Parse(z.ToString())));
                    }
                }
                else
                {
                    board[stc].cards.Add(new Card(int.Parse(c.ToString())));
                }
            }
        }

    }
    
}
