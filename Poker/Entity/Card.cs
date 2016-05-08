using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{    

    public class Card : IComparable<Card>
    {
        private CardRank m_rank;
        private CardSuits m_suit;

        public Card(CardSuits suit, CardRank rank)
        {
            this.m_rank = rank;
            this.m_suit = suit;
        }


        public CardRank Rank
        {
            get { return this.m_rank; }
            set { this.m_rank = value; }
        }

        public CardSuits Suit
        {
            get { return m_suit; }
            set { m_suit = value; }
        }

        public int CompareTo(Card other) 
        {
            return other.Rank.CompareTo(this.Rank);        
        }

    }

    public enum CardRank
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven =7,
        Eight =8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    };

    public enum CardSuits
    {
        Club, Diamond, Heart, Spade
    }

    public enum PokerHandType
    {
        None = 0,
        HighCard = 2,
        OnePair = 4,
        TwoPair = 8,
        ThreeOfAKind = 16,
        Straight = 32,
        Flush = 64,
        FullHouse = 128,
        FourOfAKind = 256,
        StraightFlush = 512
    }
   

}
