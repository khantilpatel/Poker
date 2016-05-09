using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
    /// <summary>
    /// Player Class represents a Poker Player with Name and Hand objects
    /// </summary>
    public class Player
    {
        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }

        private Hand m_hand;

        public Hand Hand
        {
            get { return m_hand; }
            set { m_hand = value; }
        }


        public Player(String name, Hand hand) 
        {
            m_name = name;
            m_hand = hand;        
        }

        /// <summary>
        /// Static helper method for Player class to check if two players has 
        /// equal hands based on high card.
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        public static bool playerHandEquals(Player player1, Player player2)
        {
            int cardIndex = 0;
            bool result = true; // assume first cards are equal

            while (cardIndex < player1.Hand.Cards.Count && result == true)
            {
                if (player1.Hand.Cards[cardIndex].Rank == player2.Hand.Cards[cardIndex].Rank)
                    result = true;
                else if (player1.Hand.Cards[cardIndex].Rank < player2.Hand.Cards[cardIndex].Rank)
                    result = false;
                else if (player1.Hand.Cards[cardIndex].Rank > player2.Hand.Cards[cardIndex].Rank)
                    result = false;

                cardIndex++;
            }

            return result;
        }

    }

    /// <summary>
    /// A IComparer implementation for Player to sort the hand by HandType and HandScore
    /// </summary>
    public class PlayerPokerHandScoreComparer : IComparer<Player>
    {
        public int Compare(Player player1, Player player2)
        {
            int result = player2.Hand.PokerHandScore.Type.
                CompareTo(player1.Hand.PokerHandScore.Type);

            if (result == 0)
                result = player2.Hand.PokerHandScore.Score.
                CompareTo(player1.Hand.PokerHandScore.Score);

            return result;
        }
    }

    /// <summary>
    /// /// A IComparer implementation for Player to sort the players hand based on High Card
    /// </summary>
    public class PlayerHighCardComparer : IComparer<Player>
    {
        public int Compare(Player player1, Player player2)
        {
            int cardIndex = 0;
            int result = 0; // assume first cards are equal

            while (cardIndex < player1.Hand.Cards.Count && result == 0)
            {
                if (player1.Hand.Cards[cardIndex].Rank == player2.Hand.Cards[cardIndex].Rank)
                    result = 0;
                else if (player1.Hand.Cards[cardIndex].Rank < player2.Hand.Cards[cardIndex].Rank)
                    result = 1;
                else if (player1.Hand.Cards[cardIndex].Rank > player2.Hand.Cards[cardIndex].Rank)
                    result = -1;

                cardIndex++;
            }

            return result;
        }
    }
}
