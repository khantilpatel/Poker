using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
    /// <summary>
    /// Deck class for testing purpose, not used in the library logic
    /// </summary>
    public class Deck
    {
        private List<Card> m_deck;
        int cardsUsed = 0;

        /// <summary>
        /// Deck constructor creates the deck of 52 cards
        /// </summary>
        public Deck()
        {
            m_deck = new List<Card>(100);

            for (int suit = 0; suit <= 3; suit++)
            {
                for (int rank = 0; rank<= 12; rank++)
                {                    
                    m_deck.Add(new Card((CardSuits)System.Enum.GetValues(typeof(CardSuits)).GetValue(suit),
                        (CardRank)System.Enum.GetValues(typeof(CardRank)).GetValue(rank)));                    
                }
            }
        }

        /// <summary>
        /// Shuffle the cards in the deck before dealing the cards in the hands
        /// </summary>
        public void shuffle()
        {
           Random random = new Random();
            for (int i = m_deck.Count - 1; i > 0; i--)
            {
                int n = random.Next(i + 1);
                Card temp = m_deck[i];
                m_deck[i] = m_deck[n];
                m_deck[n] = temp;
            }
        }

        /// <summary>
        /// Used to deal the card from deck, throws exception if deck is empty.
        /// </summary>
        /// <returns></returns>
        public Card dealCard()
        {
            if (cardsUsed == m_deck.Count)            
            throw new PokerGenericException("No cards are left in the deck.");

            cardsUsed++;            
            return m_deck[cardsUsed - 1];
        }
           

    }
}
