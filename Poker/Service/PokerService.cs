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
        
        public PokerService(IPokerHandService pokerHandService)
        {
            m_pokerHandService = pokerHandService;        
        }

        public List<Player> evaluateHands(List<Player> players)
        {
            foreach(Player player in players)
            {
                this.whatDoIHave(player);
            }

            players.Sort(new PlayerPokerHandScoreComparer());

            List<Player> result = this.tieBreaker(players);

            return result;
        }

        public void whatDoIHave(Player player)
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

        public List<Player> tieBreakerWithHighCard(List<Player> tiePlayers)
        {
            List<Player> winnerPlayers = new List<Player>();

            tiePlayers.Sort(new PlayerHighCardComparer());

            int index = 1;
            Player winnerPlayer = tiePlayers[0];
            winnerPlayers.Add(winnerPlayer);

            while (index < tiePlayers.Count &&
               playerHandEquals(winnerPlayer, tiePlayers[index]))
            {
                winnerPlayers.Add(tiePlayers[index]);
                index++;
            }          

            return winnerPlayers;
        }


        bool playerHandEquals(Player player1, Player player2) 
        {
            int cardIndex = 0;
            bool result = true; // assume first cards are equal

            while (cardIndex < player1.Hand.Cards.Count && result == true)
            {
                if (player1.Hand.Cards[cardIndex].Rank == player2.Hand.Cards[cardIndex].Rank)
                    result = true;
                else if (player1.Hand.Cards[cardIndex].Rank < player2.Hand.Cards[cardIndex].Rank)
                    result = false;
                else if (player1.Hand.Cards[cardIndex].Rank > player2.Hand.Cards[cardIndex].Rank)
                    result = false;

                cardIndex++;
            }

            return result;
        }

     
    }
}
