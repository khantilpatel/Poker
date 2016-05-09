// System module references
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

// Mannaged module references
using Poker;
using Poker.Entity;
using Poker.Service;

namespace PokerTests
{
    [TestClass]
    public class PokerServiceTests
    {

        IPokerService setUp()
        {
            IPokerHandService pokerHandService = new PokerHandService();
            return new PokerService(pokerHandService);
        }


        [TestMethod]
        public void whatDoIHave_WhenFlushHand_IdentifyHand()
        {
            // Given a hand with clear flush                    
            IPokerService pokerService = setUp();

            Hand hand = MockObjectHelper.handFlush();
            Player player = new Player("Joe", hand);

            // When calls whatDoIHave
            pokerService.whatDoIHave(player);

            // Then the player should have a PokerHandType.Flush
            Assert.IsTrue(player.Hand.PokerHandScore.Type == PokerHandType.Flush);
        }

        [TestMethod]
        public void whatDoIHave_WhenThreeOfAKindHand_IdentifyHand()
        {
            // Given a hand with clear flush     
            IPokerService pokerService = setUp();

            Hand hand = MockObjectHelper.handThreeOfAKind();
            Player player = new Player("Joe", hand);

            // When calls whatDoIHave
            pokerService.whatDoIHave(player);

            // Then the player should have a PokerHandType.Flush
            Assert.IsTrue(player.Hand.PokerHandScore.Type == PokerHandType.ThreeOfAKind);
        }    


        [TestMethod]
        public void whatDoIHave_WhenOnePairHand_IdentifyHand()
        {
            // Given 5 players with different hands
            IPokerService pokerService = setUp();

            Hand hand = MockObjectHelper.handOnePairValid();
            Player player = new Player("Joe", hand);

            // When calls whatDoIHave
            pokerService.whatDoIHave(player);

            // Then the player should have a PokerHandType.OnePair
            Assert.IsTrue(player.Hand.PokerHandScore.Type == PokerHandType.OnePair);
        }

        [TestMethod]
        public void sortPlayers_WhenPlayersWithExample1_SortWithJoeAtTop()
        {
            // Given 5 players with hands from Example1
            IPokerService pokerService = setUp();
            List<string> validSortOrder = new List<string>()
	        {
	            "Joe",
	            "Jen",            
	        };

            List<Player> players = new List<Player>(4);   

            players.Add(new Player("Jen", MockObjectHelper.handExample1Jen()));
            players.Add(new Player("Bob" ,MockObjectHelper.handExample1Bob()));
            players.Add(new Player("Joe", MockObjectHelper.handExample1Joe())); 
           
            // When hands are sorted based on HandType and its score
            foreach (Player player in players)
            {
                pokerService.whatDoIHave(player);
            }

            players.Sort(new PlayerPokerHandScoreComparer());        

            // Then the player list should return single winner player

            int index = 0;
            foreach (string player in validSortOrder)
            {
                Assert.IsTrue(player.Equals(players[index].Name));
                index++;
            }           
        }

        [TestMethod]
        public void sortPlayers_WhenPlayersWithExample2_SortWithJenAtTop()
        {
            // Given 5 players with different hands
            IPokerService pokerService = setUp();
            List<string> validSortOrder = new List<string>()
	        {
	            "Jen",
	            "Joe",
                "Bob"
	        };
            List<Player> players = new List<Player>(4);
           
            players.Add(new Player("Jen", MockObjectHelper.handExample2Jen()));
            players.Add(new Player("Bob", MockObjectHelper.handExample2Bob()));    
            players.Add(new Player("Joe", MockObjectHelper.handExample2Joe()));

            // When hands are sorted based on HandType and its score
            foreach (Player player in players)
            {
                pokerService.whatDoIHave(player);
            }

            players.Sort(new PlayerPokerHandScoreComparer());      

            // Then the player list should return single winner player
            int index = 0;
            foreach (string player in validSortOrder)
            {
                Assert.IsTrue(player.Equals(players[index].Name));
                index++;
            }
        }



        [TestMethod]
        public void tieBreaker_WhenHandsWithTie_IdentifyWinningHands()
        {
            // Given 5 players with different hands
            IPokerService pokerService = setUp();

            List<Player> players = new List<Player>(4);
       
            players.Add(new Player("Jen", MockObjectHelper.handExample2Jen()));
            players.Add(new Player("Bob", MockObjectHelper.handExample2Bob()));
            players.Add(new Player("Andrew", MockObjectHelper.handExample2Jen()));
            players.Add(new Player("Stam", MockObjectHelper.handOnePairInValid()));
            players.Add(new Player("Joe", MockObjectHelper.handExample2Joe()));
            // When hands are evaluated
            pokerService.evaluateHands(players);

            // Then the player list should return single winner player
          //  Assert.IsTrue(players.Equals(players1));
        }
        

        ///////////////////////
        [TestMethod]
        public void evaluateHands_WhenOneWinner_ReturnsWinner()
        {
            // Given 3 hands with one clear winner   
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            string winner = "Jen";
            players.Add(new Player("Jen", MockObjectHelper.handOnePairValid()));
            players.Add(new Player("Bob", MockObjectHelper.handExample2Bob()));
            players.Add(new Player("Andrew", MockObjectHelper.handExample2Jen()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return single winner player

        }

        [TestMethod]
        public void evaluateHands_WhenOneWinnerWithFlush_ReturnsWinner()
        {
            // Given 3 hands with one clear winner
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            string winner = "Jen";
            players.Add(new Player("Jen", MockObjectHelper.handFlush()));
            players.Add(new Player("Bob", MockObjectHelper.handLowHighCard1()));
            players.Add(new Player("Andrew", MockObjectHelper.handLowHighCard2()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return single winner player
            Assert.IsTrue(1 == result.Count);
            Assert.IsTrue(winner.Equals(result[0].Name));
        }

        [TestMethod]
        public void evaluateHands_WhenOneWinnerWithThreeofaKind_ReturnsWinner()
        {
            // Given 3 hands with one clear winner
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            string winner = "Jen";
            players.Add(new Player("Jen", MockObjectHelper.handThreeOfAKind()));
            players.Add(new Player("Bob", MockObjectHelper.handLowHighCard1()));
            players.Add(new Player("Andrew", MockObjectHelper.handLowHighCard2()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return single winner player
            Assert.IsTrue(1 == result.Count);
            Assert.IsTrue(winner.Equals(result[0].Name));

        }

        [TestMethod]
        public void evaluateHands_WhenOneWinnerWithOnePair_ReturnsWinner()
        {
            // Given 3 hands with one clear winner
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            string winner = "Jen";
            players.Add(new Player("Jen", MockObjectHelper.handOnePairValid()));
            players.Add(new Player("Bob", MockObjectHelper.handLowHighCard1()));
            players.Add(new Player("Andrew", MockObjectHelper.handLowHighCard2()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return single winner player
            Assert.IsTrue(1 == result.Count);
            Assert.IsTrue(winner.Equals(result[0].Name));
        }

        [TestMethod]
        public void evaluateHands_WhenOneWinnerWithHighCard_ReturnsWinner()
        {
            // Given 3 hands with one clear winner
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            string winner = "Jen";
            players.Add(new Player("Jen", MockObjectHelper.handLowHighCard3()));
            players.Add(new Player("Bob", MockObjectHelper.handLowHighCard1()));
            players.Add(new Player("Andrew", MockObjectHelper.handLowHighCard2()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return single winner player
            Assert.IsTrue(1 == result.Count);
            Assert.IsTrue(winner.Equals(result[0].Name));
        }

          [TestMethod]
        public void evaluateHands_WhenTieWithTwoPlayerHavingFlush_ReturnsTwoPlayers()
        {
            // Given 3 hands with two clear tie and other loser
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            List<string> validSortOrder = new List<string>()
	        {
	            "Jen",
                "Bob"
	        };

            players.Add(new Player("Jen", MockObjectHelper.handFlush()));
            players.Add(new Player("Bob", MockObjectHelper.handFlush()));
            players.Add(new Player("Andrew", MockObjectHelper.handLowHighCard2()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return two players sharing the pot
            Assert.IsTrue(2 == result.Count);
            int index = 0;
            foreach (string player in validSortOrder)
            {
                Assert.IsTrue(player.Equals(result[index].Name));
                index++;
            }
        }

       [TestMethod]
        public void evaluateHands_WhenTieWithTwoPlayerHavingOnePair_ReturnsTwoPlayers()
        {
            // Given 3 hands with two clear tie and other loser
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            List<string> validSortOrder = new List<string>()
	        {
	            "Jen",
                "Bob"
	        };

            players.Add(new Player("Jen", MockObjectHelper.handOnePairValid()));
            players.Add(new Player("Bob", MockObjectHelper.handOnePairValid1()));
            players.Add(new Player("Andrew", MockObjectHelper.handLowHighCard2()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return two players sharing the pot
            Assert.IsTrue(2 == result.Count);
            int index = 0;
            foreach (string player in validSortOrder)
            {
                Assert.IsTrue(player.Equals(result[index].Name));
                index++;
            }
        }

        [TestMethod]
        public void evaluateHands_WhenTieWithTwoPlayerHavingHighPair_ReturnsTwoPlayers()
        {
             // Given 3 hands with two clear tie and other loser
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            List<string> validSortOrder = new List<string>()
	        {
	            "Jen",
                "Bob",
                "Andrew"
	        };

            players.Add(new Player("Jen", MockObjectHelper.handLowHighCard1()));
            players.Add(new Player("Bob", MockObjectHelper.handLowHighCard1_Tie()));
            players.Add(new Player("Andrew", MockObjectHelper.handLowHighCard2()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return two players sharing the pot
            Assert.IsTrue(validSortOrder.Count == result.Count);
            int index = 0;
            foreach (string player in validSortOrder)
            {
                Assert.IsTrue(player.Equals(result[index].Name));
                index++;
            }
        }


        [TestMethod]
        public void evaluateHands_WhenExample1_ReturnJoe()
        {
            // Given 3 hands with two clear tie and other loser
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            List<string> validSortOrder = new List<string>()
	        {
	            "Joe"              
	        };

            players.Add(new Player("Joe", MockObjectHelper.handExample1Joe()));
            players.Add(new Player("Jen", MockObjectHelper.handExample1Jen()));
            players.Add(new Player("Bob", MockObjectHelper.handExample1Bob()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return two players sharing the pot
            Assert.IsTrue(validSortOrder.Count == result.Count);
            int index = 0;
            foreach (string player in validSortOrder)
            {
                Assert.IsTrue(player.Equals(result[index].Name));
                index++;
            }
        }


        [TestMethod]
        public void evaluateHands_WhenExample2_ReturnsJen()
        {
            // Given 3 hands with two clear tie and other loser
            IPokerService pokerService = setUp();
            List<Player> players = new List<Player>(4);
            List<string> validSortOrder = new List<string>()
	        {
	            "Jen"              
	        };

            players.Add(new Player("Joe", MockObjectHelper.handExample2Joe()));
            players.Add(new Player("Jen", MockObjectHelper.handExample2Jen()));
            players.Add(new Player("Bob", MockObjectHelper.handExample2Bob()));

            // When hands are evaluated
            List<Player> result = pokerService.evaluateHands(players);

            // Then the player list should return two players sharing the pot
            Assert.IsTrue(validSortOrder.Count == result.Count);
            int index = 0;
            foreach (string player in validSortOrder)
            {
                Assert.IsTrue(player.Equals(result[index].Name));
                index++;
            }
        }
    }

}
