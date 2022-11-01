using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solittare
{
    internal class Cleverguy
    {
        public Game game { get; internal set; }

        List<List<Card>> candidates = new List<List<Card>>();

        public Cleverguy(Game g)
        {
            game = g;
        }

        public string gethelpline()
        {
            candidates.Clear();

            string output = "";

            foreach(Stack  s1 in game.board)
            {
                if (s1.cards.Count != 0)
                {
                    List<Card> cl1 = new List<Card>();
                    bool does = true;

                    foreach (Card c1 in s1.cards)
                    {
                        if (does)
                        {
                            if (cl1.Count == 0)
                            {
                                cl1.Add(c1);

                            }
                            else if (c1.id - 1 == cl1[cl1.Count - 1].id && c1.isHiden == false)
                            {
                                cl1.Add(c1);
                            }
                            else
                            {
                                does = false;
                            }
                        }
                    }
                    candidates.Add(cl1);
                }
                else
                {
                    return "You fill the holes first";
                }
            }

            List<string> ideas = new List<string>();
            List<Card> firsts = new List<Card>();

            foreach (List<Card> cl2 in candidates)
            {
                firsts.Add(cl2[0]);
            }

            foreach (List<Card> cl3 in candidates)
            {
                Card tstc = cl3[cl3.Count - 1];

                foreach(Card c3 in firsts)
                {
                    if(c3.id -1 == tstc.id)
                    {
                        int stindx = candidates.IndexOf(cl3) +1;
                        int cardindx = cl3.IndexOf(tstc) +1;
                        int trgindx = firsts.IndexOf(c3) +1;
                        ideas.Add("From: [" + stindx + ";" + cardindx + "] To stack:" + trgindx);
                    }
                }
            }

            if (ideas.Count != 0)
            {
                Random random = new Random();
                output = ideas[random.Next(0, ideas.Count)];
                return output;
            }
            else
            {
                if(game.pack.cards.Count != 0)
                {
                    return "Please deal a new batch";
                }
                else
                {
                    return "No tips avalibe";
                }        
            }
        }
    }
}
