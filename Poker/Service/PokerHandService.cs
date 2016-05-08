using Poker.Entity;
using Poker.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public class PokerHandService: IPokerHandService
    {
        const int FIVE_CARDS = 5;
        const int THREE_CARDS = 3;
        const int TWO_CARDS = 2;

        /// <summary>
        /// Implementation method to check if a given hand is of type PokerHandType.OnePair.
        /// Here cards pattern A-A-x-x-x (x means any other card) is searched. 
        /// Note that Q-Q-3-4-5 is a valid ThreeOfAKind hand, whereas Q-Q-Q-Q-5 or Q-Q-K-K-4 is not, even though it has Q-Q-Q pattern.   
        /// TODO: Kicker:: Also there will be a tie condition for Q-Q-3-4-5 and Q-Q-10-4-5, where the later will win. 
        /// Whereas for Q-Q-3-4-5 and Q-Q-3-4-5 case, there will be no resolution
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        
        PokerHandScore IPokerHandService.checkFlush(Hand hand)
        {

            PokerHandScore pokerHandScore = NullPokerHandScore.Instance;

            int score = 0;

            foreach (KeyValuePair<CardSuits, int> entry in hand.HashSuit)
            {
                if (entry.Value == FIVE_CARDS)
                { 
                  score = (int)hand.Cards[0].Rank;
                  pokerHandScore = new PokerHandScore(PokerHandType.Flush, score);
                }
            }

            return pokerHandScore;
        }

        /// <summary>
        /// Implementation method to check if a given hand is of type PokerHandType.ThreeOfAKind.
        /// ThreeOfAKind is a hand with that contains three cards of the same rank, plus two cards
        /// which are not of this rank nor the same as each other.
        /// Here cards pattern A-A-A-x-x (x means any other card) is searched. 
        /// Note that Q-Q-Q-4-5 is a valid ThreeOfAKind hand, whereas Q-Q-Q-Q-5 and Q-Q-Q-5-5 is not,
        /// even though it has Q-Q-Q pattern.

        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        PokerHandScore IPokerHandService.checkThreeOfAKind(Hand hand)
        {         
            PokerHandScore pokerHandScore = NullPokerHandScore.Instance;

            //dict = CalculateUtility.hashCards(hand.Cards);

            bool threeCardsOfSameRank = false, twoCardsNotSameRank = true;
            int score = 0;

            foreach (KeyValuePair<CardRank, int> entry in hand.HashRank)
            {
                if (entry.Value == THREE_CARDS)
                {
                    score = (int) entry.Key;
                    threeCardsOfSameRank = true;
                }
                else if (entry.Value == TWO_CARDS)
                {
                    twoCardsNotSameRank = false;
                }

            }
            
            if(threeCardsOfSameRank && twoCardsNotSameRank)
            {
                pokerHandScore = new PokerHandScore(PokerHandType.ThreeOfAKind, score);
            }

            return pokerHandScore;
        }

        /// <summary>
        /// Implementation method to check if a given hand is of type PokerHandType.OnePair.
        /// OnePair is a hand that contains two cards of one rank, plus three cards
        /// which are not of this rank nor the same as each other.
        /// Here cards pattern A-A-x-x-x (x means any other card) is searched. 
        /// Note that Q-Q-3-4-5 is a valid ThreeOfAKind hand, whereas Q-Q-Q-Q-5 or Q-Q-K-K-4 is not, even though it has Q-Q-Q pattern.   
        /// TODO: Kicker:: Also there will be a tie condition for Q-Q-3-4-5 and Q-Q-10-4-5, where the later will win. 
        /// Whereas for Q-Q-3-4-5 and Q-Q-3-4-5 case, there will be no resolution
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        PokerHandScore IPokerHandService.checkOnePair(Hand hand)
        {
            PokerHandScore pokerHandScore = NullPokerHandScore.Instance;

            //dict = CalculateUtility.hashCards(hand.Cards);

            bool twoCardsOfSameRank = false, otherTwoCardsNotSameRank = true;
            int score = 0;

            foreach (KeyValuePair<CardRank, int> entry in hand.HashRank)
            {
                if (twoCardsOfSameRank && entry.Value == TWO_CARDS)
                {
                    otherTwoCardsNotSameRank = false;
                }else if (entry.Value == TWO_CARDS)
                {
                    score = (int)entry.Key;
                    twoCardsOfSameRank = true;
                }
                
               

            }

            if (twoCardsOfSameRank && otherTwoCardsNotSameRank)
            {
                pokerHandScore = new PokerHandScore(PokerHandType.ThreeOfAKind, score);
            }           

            return pokerHandScore;
        }           

        PokerHandScore IPokerHandService.checkHighCard(Hand hand)
        {
            PokerHandScore score = new PokerHandScore(PokerHandType.HighCard,
             CalculateUtility.handScore(hand.Cards));

            return score;
        }

        
   
    }
}
