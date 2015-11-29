using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Exceptions
{
    public class ShipOverlapException : Exception
    {
        public ShipOverlapException(string message) : base(message)
        {
        }
    }
}
