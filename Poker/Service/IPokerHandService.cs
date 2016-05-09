using Poker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public interface IPokerHandService
    {
        /// <summary>
        /// Given a Hand, check and compute score for PokerHandType.HighCard.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        PokerHandScore checkHighCard(Hand hand);

        /// <summary>
        /// Given a Hand, check and compute score for PokerHandType.OnePair.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        PokerHandScore checkOnePair(Hand hand);

        /// <summary>
        /// Given a Hand, check and compute score for PokerHandType.ThreeOfAKind.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        PokerHandScore checkThreeOfAKind(Hand hand);

        /// <summary>
        /// Given a Hand, check and compute score for PokerHandType.Flush.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        PokerHandScore checkFlush(Hand hand);


       // int compareHand(Hand hand1, Hand hand2);

    }
}
