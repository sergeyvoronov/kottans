using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Ship
    {
        public int X, Y;
        private readonly Direction _direction;

        public Ship(int x, int y, Direction direction = 0)
        {
            this.X = x;
            this.Y = y;
            this._direction = direction;
        }

        protected bool Equals(Ship other)
        {
            return X == other.X && Y == other.Y && _direction == other._direction;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X;
                hashCode = (hashCode*397) ^ Y;
                hashCode = (hashCode*397) ^ (int) _direction;
                return hashCode;
            }
        }
    }
}
