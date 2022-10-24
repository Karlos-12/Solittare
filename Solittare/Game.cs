using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                
                int u = random.Next(pack.cards.Count - 1);
                board[i - 1].cards.Add(pack.cards[u]);
                pack.cards.RemoveAt(u);
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
            
            return true;
        }

        Stack lastpicked;
        public List<Card> picked = new List<Card>();

        public bool move(Stack target)
        //zjištuje jestli to tam můžeš položit
        {
            if (picked[picked.Count - 1].id +1 == target.cards[0].id)
            {
                target.cards.InsertRange(0, picked);
                lastpicked.cards.RemoveRange(0, picked.Count());

                picked.Clear();
                return true;
            }
            else
            {
                picked.Clear();
                return false;
            }
        }
    }
}
