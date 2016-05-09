using Poker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    public class PokerService : IPokerService
    {
        IPokerHandService m_pokerHandService;
        
        /// <summary>
        /// Using Inversion of control using dependency injection pattern to 
        /// decouple the services.
        /// </summary>
        /// <param name="pokerHandService"></param>
        public PokerService(IPokerHandService pokerHandService)
        {
            m_pokerHandService = pokerHandService;        
        }

        /// <summary>
        /// Process each player's hand and determine the winners.
        /// Try to break the tie using kicker cards where needed.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public List<Player> evaluateHands(List<Player> players)
        {
            foreach(Player player in players)
            {
                this.whatDoThePlayerHave(player);
            }

            players.Sort(new PlayerPokerHandScoreComparer());

            List<Player> result = this.tieBreaker(players);

            return result;
        }

        /// <summary>
        /// Determine what type of hand the player have and what is the rank for that hand.
        /// E.g., Flush Heart(Q-J-10-8-2) has a Queen's rank. ThreeOfAKind H3,D3,S3,C4,S6 has a 3 rank
        /// </summary>
        /// <param name="player"></param>
        public virtual void whatDoThePlayerHave(Player player)
        {

            PokerHandScore handScore = NullPokerHandScore.Instance;

            if (!(handScore = m_pokerHandService.checkFlush(player.Hand)).isNull())
            {
                player.Hand.PokerHandScore = handScore;
            }
            else if (!(handScore = m_pokerHandService.checkThreeOfAKind(player.Hand)).isNull())
            {
                player.Hand.PokerHandScore = handScore;
            }
            else if (!(handScore = m_pokerHandService.checkOnePair(player.Hand)).isNull())
            {
                player.Hand.PokerHandScore = handScore;
            }
            else if (!(handScore = m_pokerHandService.checkHighCard(player.Hand)).isNull())
            {
                player.Hand.PokerHandScore = handScore;
            }            
        }

        /// <summary>
        /// The backbone of the pocker logic is tieBraker method. If one clear winner then return
        /// that, else if there is a tie then try to resolve it using tieBreakerWithHighCard.
        /// </summary>
        /// <param name="players"></param>
        /// <returns></returns>
        public List<Player> tieBreaker(List<Player> players)
        {
            List<Player> winnerPlayers = new List<Player>();

            List<Player> tiePlayers = new List<Player>();
          
            // 1. Check if there is a tie
            int i = 1;
            PokerHandScore topScore = players[0].Hand.PokerHandScore;
            tiePlayers.Add(players[0]);

            while(i < players.Count && 
                players[i].Hand.PokerHandScore.Equals(topScore))
            {
                tiePlayers.Add(players[i]);
                i++;
            }

            // if clear winner then return;
            if (tiePlayers.Count == 1)
                winnerPlayers = tiePlayers;
            else {
                winnerPlayers = tieBreakerWithHighCard(tiePlayers);
            }

            return winnerPlayers;           
        }   

        /// <summary>
        /// Tries to break the ties considering High Cards in multiple hands.
        /// E.g., Consider hands Spade(Q, 10, 10, 5, 1) Heart(Q, 10, 10, 5, 1) Diamond(Q, 10, 10, 7, 1),
        /// the Diamond Hand wins, as it has 7 as a High card compared to others.
        /// This will be the case for Flush, OnePair hands and not for ThreeOfAKind
        /// </summary>
        /// <param name="tiePlayers"></param>
        /// <returns></returns>
        public List<Player> tieBreakerWithHighCard(List<Player> tiePlayers)
        {
            List<Player> winnerPlayers = new List<Player>();

            // Sort players according to the highcard ranking 
            tiePlayers.Sort(new PlayerHighCardComparer());

            // Now the Winner players are at the top of the list, get if one winner else the tie winners
            int index = 1;
            Player winnerPlayer = tiePlayers[0];
            winnerPlayers.Add(winnerPlayer);

            while (index < tiePlayers.Count &&
               Player.playerHandEquals(winnerPlayer, tiePlayers[index]))
            {
                winnerPlayers.Add(tiePlayers[index]);
                index++;
            }          

            return winnerPlayers;
        }     
    }
}
