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

        private List<PokerHandScore> m_pokerHandScores;

        public Hand(List<Card> cards) 
        {
            m_cards = cards;

            m_cards.Sort();
            hashRank = CalculateUtility.hashCardsByRank(cards);
            hashSuit = CalculateUtility.hashCardsBySuit(cards);
        }

        public List<Card> Cards
        {
            get { return m_cards; }
            //set { m_cards = value; }
        }     

        public List<PokerHandScore> PokerHandScores
        {
            get { return m_pokerHandScores; }
            set { m_pokerHandScores = value; }
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
    }

}
