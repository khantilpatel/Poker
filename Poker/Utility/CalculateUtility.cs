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


      
    }
}
