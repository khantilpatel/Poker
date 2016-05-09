using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
    /// <summary>
    /// Represents Type of a Poker Hand there are all defined but only few are used.
    /// </summary>
    public enum PokerHandType
    {
        None = 0,
        HighCard = 2,
        OnePair = 4,
        TwoPair = 8,
        ThreeOfAKind = 16,
        Straight = 32,
        Flush = 64,
        FullHouse = 128,
        FourOfAKind = 256,
        StraightFlush = 512
    }
}
