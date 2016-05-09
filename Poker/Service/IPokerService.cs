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
        void whatDoIHave(Player player);

        List<Player> tieBreaker(List<Player> players);

        List<Player> tieBreakerWithHighCard(List<Player> players);

        List<Player> evaluateHands(List<Player> players);


    }
}
