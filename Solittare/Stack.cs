using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solittare
{
    internal class Stack
    {
        public List<Card> cards { get; set; }

        public Stack()
        {
            cards = new List<Card>(null);
        }

        public Stack(bool preset)
        {
            cards = new List<Card>();
            //karty more pudou od spodu ale je to asi irelevantní

            for (int i = 4; i > 0; i--)
            {
                for (int u = 14; u > 0; u--)
                {
                    cards.Add(new Card(u));
                }
            }
        }
    }
}
