using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Solittare
{
    internal class Card
    {
        public int id { get; }
        public coloros color { get; }

        public Card(int id)
        {
            this.id = id;
            color = 0;
        }

        public Card(int id, coloros coloros)
        {
            this.id = id;
            color = coloros;
        }
    }
    
    enum coloros
    {
        red,
        blue,
        black,
        white
    }
}
