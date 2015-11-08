using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Cruiser : Ship
    {
        public Cruiser(int x, int y, Direction direction = Direction.Vertiacal) : base(x, y, direction)
        {
        }
    }
}
