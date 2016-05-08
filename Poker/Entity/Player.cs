using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
    public class Player
    {
        private Hand m_hand;

        public Hand Hand
        {
            get { return m_hand; }
            set { m_hand = value; }
        }


        public Player(Hand hand) 
        {
            m_hand = hand;        
        }
     


    }
}
