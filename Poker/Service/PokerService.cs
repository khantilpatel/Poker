using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Service
{
    class PokerService
    {
        IPokerHandService m_pokerHandService;
        
        public PokerService(IPokerHandService pokerHandService)
        {
            m_pokerHandService = pokerHandService;        
        }
    }
}
