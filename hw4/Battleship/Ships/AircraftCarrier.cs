using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Ships
{
    public class AircraftCarrier : Ship
    {
        public AircraftCarrier(int x, int y) : base(x, y)
        {
        }

        public AircraftCarrier(int x, int y, Direction direction) : base(x, y, direction)
        {
            Length = (int)ShipTypes.AircraftCarrier;
        }
    }
}
