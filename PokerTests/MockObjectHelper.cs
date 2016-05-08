using Poker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTests
{
    class MockObjectHelper
    {
        public static List<Card> flushHand()
        {
             return new List<Card>()
            {
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.King),
                new Card(CardSuits.Club, CardRank.Queen),
                new Card(CardSuits.Club, CardRank.Jack),
                new Card(CardSuits.Club, CardRank.Ten)
            };
        }

        public static List<Card> threeOfAKindHand()
        {
            return new List<Card>()
            {
                // A-A-A-J-10
                new Card(CardSuits.Diamond, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Jack),
                new Card(CardSuits.Club, CardRank.Ten)
            };           
        }

        public static List<Card> threeOfAKindInValidWithTwoCardsSameRankHand()
        {
            return new List<Card>()
            {
                // A-A-A-10-10
                new Card(CardSuits.Diamond, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ten),
                new Card(CardSuits.Club, CardRank.Ten)
            };
        }

       public static List<Card> onePairValidHand()
        {
            return new List<Card>()
            {
                // 10-10-6-4-2
                new Card(CardSuits.Club, CardRank.Ten),
                new Card(CardSuits.Spade, CardRank.Ten),
                new Card(CardSuits.Spade, CardRank.Six),
                new Card(CardSuits.Heart, CardRank.Four),
                new Card(CardSuits.Heart, CardRank.Two)
            };
        }

       public static List<Card> onePairInValidHand()
       {
           return new List<Card>()
            {
                // A-A-J-J-10
                new Card(CardSuits.Diamond, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Jack),
                new Card(CardSuits.Club, CardRank.Jack),
                new Card(CardSuits.Club, CardRank.Ten)
            };
       }
    }
}
