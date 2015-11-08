using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Submarine : Ship
    {
        public Submarine(int x, int y, Direction direction = Direction.Vertiacal) : base(x, y, direction)
        {
            Length = (int) ShipTypes.Submarine;
        }
    }
}
