using Poker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public interface IPokerService
    {
        /// <summary>
        /// Determine what hand does the player have. It should update the PokerHandScore property of Hand Class 
        /// for the player to indicate what hand has been found.
        /// </summary>
        /// <param name="player"></param>
        void whatDoThePlayerHave(Player player);

        /// <summary>
        /// If there is a clear winner return list with one player else 
        /// break the tie and return the list of player sharing the pot
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        List<Player> tieBreaker(List<Player> players);

        /// <summary>
        /// Break the players tie by comparing hand based on HighCard
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        List<Player> tieBreakerWithHighCard(List<Player> players);

        /// <summary>
        /// Primary interface for the library, should process the hand and return the 
        /// winners
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        List<Player> evaluateHands(List<Player> players);


    }
}
