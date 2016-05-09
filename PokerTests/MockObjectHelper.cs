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
        public static Hand handFlush()
        {
            return new Hand(new List<Card>()
            {
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.King),
                new Card(CardSuits.Club, CardRank.Queen),
                new Card(CardSuits.Club, CardRank.Jack),
                new Card(CardSuits.Club, CardRank.Ten)
            });
        }

        public static Hand handFlush1()
        {
            return new Hand(new List<Card>()
            {
                new Card(CardSuits.Heart, CardRank.Ace),
                new Card(CardSuits.Heart, CardRank.King),
                new Card(CardSuits.Heart, CardRank.Queen),
                new Card(CardSuits.Heart, CardRank.Jack),
                new Card(CardSuits.Heart, CardRank.Ten)
            });
        }

        public static Hand handThreeOfAKind()
        {
            return new Hand(new List<Card>()
            {
                // A-A-A-J-10
                new Card(CardSuits.Diamond, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Jack),
                new Card(CardSuits.Club, CardRank.Ten)
            });           
        }

        public static Hand handThreeOfAKindInValidWithTwoCardsSameRank()
        {
            return new Hand(new List<Card>()
            {
                // A-A-A-10-10
                new Card(CardSuits.Diamond, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Spade, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ten),
                new Card(CardSuits.Spade, CardRank.Ten)
            });
        }

       public static Hand handOnePairValid()
        {
            return new Hand(new List<Card>()
            {
                // 10-10-6-4-2
                new Card(CardSuits.Club, CardRank.Ten),
                new Card(CardSuits.Spade, CardRank.Ten),
                new Card(CardSuits.Spade, CardRank.Six),
                new Card(CardSuits.Heart, CardRank.Four),
                new Card(CardSuits.Heart, CardRank.Two)
            });
        }

       public static Hand handOnePairValid1()
       {
           return new Hand(new List<Card>()
            {
                // 10-10-6-4-2
                new Card(CardSuits.Heart, CardRank.Ten),
                new Card(CardSuits.Diamond, CardRank.Ten),
                new Card(CardSuits.Diamond, CardRank.Six),
                new Card(CardSuits.Spade, CardRank.Four),
                new Card(CardSuits.Spade, CardRank.Two)
            });
       }

       public static Hand handOnePairInValid()
       {
           return new Hand(new List<Card>()
            {
                // A-A-J-J-10
                new Card(CardSuits.Diamond, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Ace),
                new Card(CardSuits.Club, CardRank.Jack),
                new Card(CardSuits.Spade, CardRank.Jack),
                new Card(CardSuits.Club, CardRank.Ten)
            });
       }

       public static Hand handExample1Joe()
       {
           return new Hand(new List<Card>()
            {
                // A-A-J-J-10
                new Card(CardSuits.Heart, CardRank.Three),
                new Card(CardSuits.Heart, CardRank.Six),
                new Card(CardSuits.Heart, CardRank.Eight),
                new Card(CardSuits.Heart, CardRank.Jack),
                new Card(CardSuits.Heart, CardRank.King)
            });
       }

       public static Hand handExample1Jen()
       {
           return new Hand(new List<Card>()
            {
                // A-A-J-J-10
                new Card(CardSuits.Club, CardRank.Three),
                new Card(CardSuits.Diamond, CardRank.Three),
                new Card(CardSuits.Spade, CardRank.Three),
                new Card(CardSuits.Club, CardRank.Eight),
                new Card(CardSuits.Diamond, CardRank.Ten)
            });
       }

       public static Hand handExample1Bob()
       {
           return new Hand(new List<Card>()
            {
                // A-A-J-J-10
                new Card(CardSuits.Heart, CardRank.Two),
                new Card(CardSuits.Club, CardRank.Five),
                new Card(CardSuits.Spade, CardRank.Seven),
                new Card(CardSuits.Club, CardRank.Ten),
                new Card(CardSuits.Club, CardRank.Ace)
            });
       }

       public static Hand handExample2Joe()
       {
           return new Hand(new List<Card>()
            {
                // A-A-J-J-10
                new Card(CardSuits.Heart, CardRank.Three),
                new Card(CardSuits.Diamond, CardRank.Four),
                new Card(CardSuits.Club, CardRank.Nine),
                new Card(CardSuits.Diamond, CardRank.Nine),
                new Card(CardSuits.Heart, CardRank.Queen)
            });
       }

       public static Hand handExample2Jen()
       {
           return new Hand( new List<Card>()
            {
                // A-A-J-J-10
                new Card(CardSuits.Club, CardRank.Five),
                new Card(CardSuits.Diamond, CardRank.Seven),
                new Card(CardSuits.Heart, CardRank.Nine),
                new Card(CardSuits.Spade, CardRank.Nine),
                new Card(CardSuits.Spade, CardRank.Queen)
            });
       }

       public static Hand handExample2Bob()
       {
           return new Hand(new List<Card>()
            {
                // A-A-J-J-10
                new Card(CardSuits.Heart, CardRank.Two),
                new Card(CardSuits.Club, CardRank.Two),
                new Card(CardSuits.Spade, CardRank.Five),
                new Card(CardSuits.Club, CardRank.Ten),
                new Card(CardSuits.Heart, CardRank.Ace)
            });
       }

       public static Hand handLowHighCard1()
       {
           return new Hand(new List<Card>()
            {
                // H2-C6-S5-C4-H7
                new Card(CardSuits.Heart, CardRank.Two),
                new Card(CardSuits.Club, CardRank.Six),
                new Card(CardSuits.Spade, CardRank.Five),
                new Card(CardSuits.Club, CardRank.Four),
                new Card(CardSuits.Heart, CardRank.Seven)
            });
       }

       public static Hand handLowHighCard1_Tie()
       {
           return new Hand(new List<Card>()
            {
                // H2-C6-S5-C4-H7
                new Card(CardSuits.Club, CardRank.Two),
                new Card(CardSuits.Spade, CardRank.Six),
                new Card(CardSuits.Heart, CardRank.Five),
                new Card(CardSuits.Club, CardRank.Four),
                new Card(CardSuits.Diamond, CardRank.Seven)
            });
       }

       public static Hand handLowHighCard2()
       {
           return new Hand(new List<Card>()
            {
                // S2-H6-C5-D4-H7
                new Card(CardSuits.Spade, CardRank.Two),
                new Card(CardSuits.Heart, CardRank.Six),
                new Card(CardSuits.Club, CardRank.Five),
                new Card(CardSuits.Diamond, CardRank.Four),
                new Card(CardSuits.Heart, CardRank.Seven)
            });
       }

       public static Hand handLowHighCard3()
       {
           return new Hand(new List<Card>()
            {
                // D2-H6-C5-DJ-H7
                new Card(CardSuits.Diamond, CardRank.Two),
                new Card(CardSuits.Heart, CardRank.Six),
                new Card(CardSuits.Club, CardRank.Five),
                new Card(CardSuits.Diamond, CardRank.Jack),
                new Card(CardSuits.Heart, CardRank.Seven)
            });
       }

       public static Hand handLowHighCard4()
       {
           return new Hand(new List<Card>()
            {
                // D2-H6-C5-DJ-H7
                new Card(CardSuits.Diamond, CardRank.Queen),
                new Card(CardSuits.Heart, CardRank.Queen),
                new Card(CardSuits.Club, CardRank.Three),
                new Card(CardSuits.Diamond, CardRank.Four),
                new Card(CardSuits.Heart, CardRank.Five)
            });
       }


       public static Hand handLowHighCard5()
       {
           return new Hand(new List<Card>()
            {
                // D2-H6-C5-DJ-H7
                new Card(CardSuits.Diamond, CardRank.Queen),
                new Card(CardSuits.Heart, CardRank.Queen),
                new Card(CardSuits.Club, CardRank.Ten),
                new Card(CardSuits.Diamond, CardRank.Four),
                new Card(CardSuits.Heart, CardRank.Five)
            });
       }     
    }
}
