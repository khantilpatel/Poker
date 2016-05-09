using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{    
    /// <summary>
    /// Card class represents a card in the Deck with a Suit and Rank.
    /// </summary>
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

        /// <summary>
        /// CompareTo implementation for sorting by Rank.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Card other) 
        {
            return other.Rank.CompareTo(this.Rank);        
        }

    }
}
