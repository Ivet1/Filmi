using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cards
{
     class Card
    {
        public string Face { get; set; }
        public Suit Suit { get; set; }

        public Card(string face, Suit suit)
        {
            Face = face;
            Suit = suit;
        }
        public override string ToString()
        {
            string card = "(" + this.Face + " " + this.Suit + ")";
            return card;

        }
    }
        enum Suit
    {
        CLUB, DIAMOND, HEART, SPADE
    }

    }

