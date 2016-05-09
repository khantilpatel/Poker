using Poker.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
    /// <summary>
    /// TODO Check the access specifiers
    /// TODO 
    /// </summary>
    public class Hand
    {
        private List<Card> m_cards;

        private Dictionary<CardRank, int> hashRank;

        // Spade: 3, Diamond : 1, Club: 1, Heart: 0
        private Dictionary<CardSuits, int> hashSuit;

        private PokerHandScore m_pokerHandScore;

        public Hand(List<Card> cards) 
        {
            m_cards = cards;

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
