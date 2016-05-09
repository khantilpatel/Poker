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
    public class PokerHandServiceTests
    {
        [TestMethod]
        public void checkFlush_WhenValidCards_ReturnsPokerHandScore()
        {
            // Given
            IPokerHandService pokerHandService = new PokerHandService();
            Hand hand = MockObjectHelper.handFlush();
            int scoreValue = (int)CardRank.Ace;

            // When
            PokerHandScore pokerHandScore = pokerHandService.checkFlush(hand);

            // Then
            Assert.IsTrue(pokerHandScore.Score == scoreValue);
            Assert.IsTrue(pokerHandScore.Type == PokerHandType.Flush);
            Assert.IsFalse(pokerHandScore.isNull());
        }

        [TestMethod]
        public void checkFlush_WhenInValidCards_NullPokerHandScore()
        {
            // Given
            IPokerHandService pokerHandService = new PokerHandService();
            Hand hand = MockObjectHelper.handThreeOfAKind();
            int scoreValue = (int)CardRank.Ace;

            // When
            PokerHandScore pokerHandScore = pokerHandService.checkFlush(hand);

            // Then
            Assert.IsFalse(pokerHandScore.Score == scoreValue);
            Assert.IsTrue(pokerHandScore.Type == PokerHandType.None);
            Assert.IsTrue(pokerHandScore.isNull());
        }

        [TestMethod]
        public void checkThreeOfAKind_WhenValidCards_ReturnsPokerHandScore()
        {
            // Given
            IPokerHandService pokerHandService = new PokerHandService();
            Hand hand = MockObjectHelper.handThreeOfAKind();
            int scoreValue = (int) CardRank.Ace;

            // When
            PokerHandScore pokerHandScore = pokerHandService.checkThreeOfAKind(hand);

            // Then
            Assert.IsTrue(pokerHandScore.Score == scoreValue);
            Assert.IsTrue(pokerHandScore.Type == PokerHandType.ThreeOfAKind);
            Assert.IsFalse(pokerHandScore.isNull());
        }

        [TestMethod]
        public void checkThreeOfAKind_WhenInValidCards_FailPokerHandScore()
        {
            // Given
            IPokerHandService pokerHandService = new PokerHandService();
            Hand hand = MockObjectHelper.handThreeOfAKindInValidWithTwoCardsSameRank();
            int scoreValue = (int) CardRank.Ace;

            // When
            PokerHandScore pokerHandScore = pokerHandService.checkThreeOfAKind(hand);

            // Then
            Assert.IsFalse(pokerHandScore.Score == scoreValue);
            Assert.IsTrue(pokerHandScore.Type == PokerHandType.None);
            Assert.IsTrue(pokerHandScore.isNull());
         }

        [TestMethod]
        public void checkOnePair_WhenValidCards_ReturnsPokerHandScore()
        {
            // Given
            IPokerHandService pokerHandService = new PokerHandService();
            Hand hand = MockObjectHelper.handOnePairValid();
            int scoreValue = (int)CardRank.Ten;

            // When
            PokerHandScore pokerHandScore = pokerHandService.checkOnePair(hand);

            // Then
            Assert.IsTrue(pokerHandScore.Score == scoreValue);
            Assert.IsTrue(pokerHandScore.Type == PokerHandType.OnePair);
            Assert.IsFalse(pokerHandScore.isNull());
        }

        [TestMethod]
        public void checkOnePair_WhenInValidCards_FailPokerHandScore()
        {
            // Given
            IPokerHandService pokerHandService = new PokerHandService();
            Hand hand = MockObjectHelper.handOnePairInValid();
            int scoreValue = (int)CardRank.Ten;

            // When
            PokerHandScore pokerHandScore = pokerHandService.checkOnePair(hand);

            // Then
            Assert.IsFalse(pokerHandScore.Score == scoreValue);
            Assert.IsTrue(pokerHandScore.Type == PokerHandType.None);
            Assert.IsTrue(pokerHandScore.isNull());
        }

        [TestMethod]
        public void checkOnePair_WhenInValidCards1_FailPokerHandScore()
        {
            // Given
            IPokerHandService pokerHandService = new PokerHandService();
            Hand hand = MockObjectHelper.handThreeOfAKindInValidWithTwoCardsSameRank();
            int scoreValue = (int)CardRank.Ten;

            // When
            PokerHandScore pokerHandScore = pokerHandService.checkOnePair(hand);

            // Then
            Assert.IsFalse(pokerHandScore.Score == scoreValue);
            Assert.IsTrue(pokerHandScore.Type == PokerHandType.None);
            Assert.IsTrue(pokerHandScore.isNull());
        }
            
    }
}
