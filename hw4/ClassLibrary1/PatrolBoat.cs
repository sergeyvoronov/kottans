using System;
using System.Runtime;

namespace BattleShip
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat(int x, int y, Direction direction = Direction.Vertiacal) : base(x, y, direction)
        {
        }
    }
}