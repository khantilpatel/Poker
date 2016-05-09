using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
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

    }

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
