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
    }
}
