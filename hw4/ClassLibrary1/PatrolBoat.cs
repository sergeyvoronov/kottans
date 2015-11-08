using System;
using System.Runtime;

namespace BattleShip
{
    public class PatrolBoat
    {
        public int X, Y;
        private Direction direction;

        public PatrolBoat(int x, int y, Direction direction = 0)
        {
            this.X = x;
            this.Y = y;
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            var boat = obj as PatrolBoat;
            if (boat != null)
            { 
                PatrolBoat p = boat;
                return ((X == p.X) && (Y == p.Y)&&(direction==p.direction));
            }
            return false;
        }

// override object.GetHashCode
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}