// System module references
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

// Mannaged module references
using Poker;
using Poker.Entity;

namespace PokerTests
{
    [TestClass]
    public class PokerServiceTests
    {
        [TestMethod]
        public void evaluateHands_WhenOneWinner_ReturnsWinner()
        {
            // Given 3 hands with one clear winner          

            // When hands are evaluated

            // Then the player list should return single winner player
        }

        [TestMethod]
        public void evaluateHands_WhenOneWinnerWithFlush_ReturnsWinner()
        {
            // Given 3 hands with one clear winner

            // When hands are evaluated

            // Then the player list should return single winner player
        }

        [TestMethod]
        public void evaluateHands_WhenOneWinnerWithThreeofaKind_ReturnsWinner()
        {
            // Given 3 hands with one clear winner

            // When hands are evaluated

            // Then the player list should return single winner player
        }

        [TestMethod]
        public void evaluateHands_WhenOneWinnerWithOnePair_ReturnsWinner()
        {
            // Given 3 hands with one clear winner

            // When hands are evaluated

            // Then the player list should return single winner player
        }

        [TestMethod]
        public void evaluateHands_WhenOneWinnerWithHighCard_ReturnsWinner()
        {
            // Given 3 hands with one clear winner

            // When hands are evaluated

            // Then the player list should return single winner player
        }

        [TestMethod]
        public void evaluateHands_WhenTieWithTwoPlayer_ReturnsTwoPlayers()
        {
            // Given 3 hands with two clear tie and other loser

            // When hands are evaluated

            // Then the player list should return two players sharing the pot
        }

        [TestMethod]
        public void evaluateHands_WhenTieWithTwoPlayerHavingFlush_ReturnsTwoPlayers()
        {
            // Given 3 hands with two clear tie and other loser

            // When hands are evaluated

            // Then the player list should return two players sharing the pot
        }

        [TestMethod]
        public void evaluateHands_WhenTieWithTwoPlayerHavingThreeOfAKind_ReturnsTwoPlayers()
        {
            // Given 3 hands with two clear tie and other loser

            // When hands are evaluated

            // Then the player list should return two players sharing the pot
        }


        [TestMethod]
        public void evaluateHands_WhenTieWithTwoPlayerHavingOnePair_ReturnsTwoPlayers()
        {
            // Given 3 hands with two clear tie and other loser

            // When hands are evaluated

            // Then the player list should return two players sharing the pot
        }

        [TestMethod]
        public void evaluateHands_WhenTieWithTwoPlayerHavingHighPair_ReturnsTwoPlayers()
        {
            // Given 3 hands with two clear tie and other loser

            // When hands are evaluated

            // Then the player list should return two players sharing the pot
        }
    }

}
