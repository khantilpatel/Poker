using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Entity
{
    public class PokerGenericException: Exception
    {
        public PokerGenericException(string message): base(message)
        {
        }
    }
}
