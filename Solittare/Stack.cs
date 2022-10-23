using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solittare
{
    internal class Stack
    {
        public int cardn { get; set; }
        public List<Card> cards { get; set; }

        public Stack()
        {
            cards = new List<Card>(null);
            cardn = 0;
        }
    }
}
