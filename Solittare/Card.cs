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
        public bool isHiden { get; set; }

        public Card(int id, bool hidden, coloros coloros = 0)
        {
            this.id = id;
            color = coloros;
            isHiden = hidden;
        }

        public Card(int id, coloros coloros )
        {
            this.id = id;
            color = coloros;
            isHiden = true;
        }

        public Card(int id, bool hidden = true)
        {
            this.id = id;
            color = 0;
            isHiden = hidden;
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
