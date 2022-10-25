using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Solittare
{
    internal class Game
    {
        public Stack[] board = new Stack[9];

        public Stack pack = new Stack();

        public Game()
        {
            pack = new Stack(true);
            for (int i = 9; i > 0; i--)
            {
                board[i - 1] = new Stack();
            }

            deal();
            //nebude    
            deal();
            deal();
        }

        public void deal()
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

        Stack lastpicked;
        public List<Card> picked = new List<Card>();

        public bool move(Stack target)
        //zjištuje jestli to tam můžeš položit
        {
            if(picked.Count - 1 == 0 || target.cards.Count == 0)
            {
                target.cards.InsertRange(0, picked);
                lastpicked.cards.RemoveRange(0, picked.Count());

                picked.Clear();
                check();
                return true;
            }
            else if (picked[picked.Count - 1].id +1 == target.cards[0].id)
            {
                target.cards.InsertRange(0, picked);
                lastpicked.cards.RemoveRange(0, picked.Count());

                picked.Clear();
                check();
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
                MessageBox.Show("You have won!");
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
    }
}
