using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
    /// <summary>
    /// Provides details about the hand and specific score for that hand. E.g., for hand (10, J, Q, K, A) Type: Flush, score: 50
    /// </summary>
    public class PokerHandScore
    {
        private PokerHandType m_handType;

        public PokerHandScore(){}

        public PokerHandScore(PokerHandType type, int score)
        {
            this.Score = score;
            this.Type = type;
        }

        public PokerHandType Type
        {
            get { return m_handType; }
            set { m_handType = value; }
        }

        /// <summary>
        /// Specifies the score for the corresponding PokerHandType. 
        /// Note that for each PokerHandType the score is calculated differently in <see cref="IPokerHand"/>.
        /// </summary>
        int m_score;

        public int Score
        {
            get { return m_score; }
            set { m_score = value; }
        }

        public override bool Equals(object value)
        {
            if (value == null)
            {
                return false;
            }

            PokerHandScore handScore = value as PokerHandScore;

            return (handScore != null)
                && (Score == handScore.Score)
                && (Type == handScore.Type);              
        }

        public override int GetHashCode()
        {
            return (int)Score ^ (int)Type;
        }         


        public virtual bool isNull()
        {
            return false;
        }
    }

    /// <summary>
    /// Null Object class of type PokerHandScore to avoid null checks.
    /// Following Null Object and Singleton design pattern.
    /// </summary>
    public class NullPokerHandScore : PokerHandScore 
    {
        public override bool isNull()
        {
            return true;
        }

        public NullPokerHandScore(PokerHandType type, int score)
        {
            this.Score = score;
            this.Type = type;
        }
        private static PokerHandScore instance = new NullPokerHandScore(PokerHandType.None, 0);

        public static PokerHandScore Instance 
        {
            get { return instance; }
        }
    }
}
