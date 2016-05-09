using Poker.Entity;
using Poker.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerTests
{
    /// <summary>
    /// Demo of how this library can be extended to add more functionality
    /// into the Poker game.
    /// </summary>
    class PokerLibraryExtensibilityDemo
    {
        public void Main() // Make this static to run
        {
            IPokerHandServiceFull pokerHandServiceFull = new PokerHandServiceFull();
            PokerServiceFull pokerServiceFull = new PokerServiceFull(pokerHandServiceFull);

            List<Player> players = new List<Player>(4);

            players.Add(new Player("Jen", MockObjectHelper.handExample2Jen()));
            players.Add(new Player("Bob", MockObjectHelper.handExample2Bob()));
            players.Add(new Player("Joe", MockObjectHelper.handExample2Joe()));

            pokerServiceFull.evaluateHands(players);
        }

    }

    /// <summary>
    /// The interface IPokerHandService can be extended to implement the remaining 
    /// functionality for the Poker game, such as StraightFlush, FourOfAKind etc.
    /// </summary>
    interface IPokerHandServiceFull : IPokerHandService
    {

        /// <summary>
        /// Given a Hand, check and compute score for PokerHandType.StraightFlush.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        PokerHandScore checkStraightFlush(Hand hand);

        /// <summary>
        /// Given a Hand, check and compute score for PokerHandType.FourOfAKind.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        PokerHandScore checkFourOfAKind(Hand hand);

        /// <summary>
        /// Given a Hand, check and compute score for PokerHandType.FullHouse.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        PokerHandScore checkFullHouse(Hand hand);    
    }

    /// <summary>
    /// This class implements the new extended Interface with all the methods
    /// for identifying a Poker hand.
    /// </summary>
    class PokerHandServiceFull : IPokerHandServiceFull
    {
        PokerHandScore IPokerHandServiceFull.checkStraightFlush(Hand hand)
        {
            throw new NotImplementedException();
        }

        PokerHandScore IPokerHandServiceFull.checkFourOfAKind(Hand hand)
        {
            throw new NotImplementedException();
        }

        PokerHandScore IPokerHandServiceFull.checkFullHouse(Hand hand)
        {
            throw new NotImplementedException();
        }

        PokerHandScore IPokerHandService.checkHighCard(Hand hand)
        {
            throw new NotImplementedException();
        }

        PokerHandScore IPokerHandService.checkOnePair(Hand hand)
        {
            throw new NotImplementedException();
        }

        PokerHandScore IPokerHandService.checkThreeOfAKind(Hand hand)
        {
            throw new NotImplementedException();
        }

        PokerHandScore IPokerHandService.checkFlush(Hand hand)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// For PokerService, as there is more functionality added to check for hand type. We just need to
    /// override the whatDoThePlayerHave method from the PokerService to account for new types of hands.
    /// Other methods such as evaluateHands, tieBreaker can be reused here flawlessly.
    /// </summary>
    class PokerServiceFull : PokerService
    {
        public PokerServiceFull(IPokerHandService service)
            : base(service)
        {
        }
        public override void whatDoThePlayerHave(Player player)
        {
            throw new NotImplementedException();
        }       
    }

}
