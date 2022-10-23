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
        int id { get; }
        coloros color { get; }

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
