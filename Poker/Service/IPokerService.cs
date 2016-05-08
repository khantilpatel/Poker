using Poker.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    interface IPokerService
    {
        List<Player> evaluateHands(List<Player> players);

        Hand whatDoIHave(Hand hand);

        int compareAllHands(int indexHand1, int indexHand2);

        int compareHand(Hand hand1, Hand hand2);


    }
}
