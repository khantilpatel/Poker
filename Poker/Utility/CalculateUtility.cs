using Poker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Utility
{
    class CalculateUtility
    {
        public static int handScore(List<Card> cards)
        {
            int score = 0;

            foreach (Card card in cards)
            {
                score += (int) card.Rank;
            }

            return score;
        }


        public static Dictionary<CardRank, int> hashCardsByRank(List<Card> cards)
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

        public static Dictionary<CardSuits, int> hashCardsBySuit(List<Card> cards)
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
