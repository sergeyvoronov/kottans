using System;
using System.Runtime;

namespace BattleShip
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat(int x, int y, Direction direction = Direction.Vertiacal) : base(x, y, direction)
        {
            Length = (int) ShipTypes.PatrolBoat;
        }


        // override object.Equals
        public override bool Equals(object obj)
        {

            if (obj is PatrolBoat)
            {
                PatrolBoat pb = (PatrolBoat) obj;
                return X == pb.X && Y == pb.Y;

            }
            else
                return false;
        }

// override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}