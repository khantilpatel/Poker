using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
    /// <summary>
    /// Hand class to hold the list of cards and some statistics.
    /// </summary>
    public class Hand
    {
        private List<Card> m_cards;

        
        private Dictionary<CardRank, int> hashRank;
        
        private Dictionary<CardSuits, int> hashSuit;

        private PokerHandScore m_pokerHandScore;

        public Hand(List<Card> cards) 
        {
            // Check if the cards are not exact 5 then throw exception
            if (cards.Count != 5)
                throw new PokerGenericException("Exact five cards need to be dealt in a poker hand");

            m_cards = cards;

            // Sort the cards based on the Ranks
            m_cards.Sort();
            hashRank = this.hashCardsByRank(cards);
            hashSuit = this.hashCardsBySuit(cards);
        }

        public List<Card> Cards
        {
            get { return m_cards; }
            //set { m_cards = value; }
        }     

        public PokerHandScore PokerHandScore
        {
            get { return m_pokerHandScore; }
            set { m_pokerHandScore = value; }
        }

        public Dictionary<CardRank, int> HashRank
        {
            get { return hashRank; }
            set { hashRank = value; }
        }

        public Dictionary<CardSuits, int> HashSuit
        {
            get { return hashSuit; }
            set { hashSuit = value; }
        }

        public override string ToString() 
        {
            StringBuilder builder = new StringBuilder();

            foreach (Card card in Cards)
            {
                builder.Append(card.Suit).Append("-").Append(card.Rank).Append(" ");
            }
            return builder.ToString();
        }

        /// <summary>
        /// Helper method for Hand class hash the Cards by their Ranks.
        /// Specifically used by PokerHandService class
        /// E.g., Q-K-Q-Q-J will be hashed to Q: 3, K: 1, J: 1.
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private Dictionary<CardRank, int> hashCardsByRank(List<Card> cards)
        {
            Dictionary<CardRank, int> dict = new Dictionary<CardRank, int>();

            foreach (Card card in cards)
            {
                if (dict.ContainsKey(card.Rank))
                {
                    dict[card.Rank] += 1;
                }
                else
                {
                    dict.Add(card.Rank, 1);
                }
            }

            return dict;
        }

        /// <summary>
        /// Helper method for Hand class hash the Cards by their Suit.
        /// Specifically used by PokerHandService class.
        /// E.g., SQ-SJ-S3-D8-C3 will be hashed to Spade: 3, Diamond : 1, Club: 1
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        private Dictionary<CardSuits, int> hashCardsBySuit(List<Card> cards)
        {
            Dictionary<CardSuits, int> dict = new Dictionary<CardSuits, int>();

            foreach (Card card in cards)
            {
                if (dict.ContainsKey(card.Suit))
                {
                    dict[card.Suit] += 1;
                }
                else
                {
                    dict.Add(card.Suit, 1);
                }

            }

            return dict;
        }
    }

}
