using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Exceptions;

namespace Battleship.Ships
{
    public class Ship
    {
        private Direction _direction;
        private int _x, _y;
        private static string alf = "ABCDEFGHIJ";

        public Direction Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public int Length;

        public Ship(int x, int y)
        {
            this._x = x;
            this._y = y;
        }


        public Ship(int x, int y, Direction direction)
        {
            this._x = x;
            this._y = y;
            this._direction = direction;
        }

        public static bool operator ==(Ship boat1, Ship boat2)
        {
            return boat1._x == boat2._x && boat1._y == boat2._y && boat1._direction == boat2._direction;
        }

        public static bool operator !=(Ship boat1, Ship boat2)
        {
            return !(boat1 == boat2);
        }

        protected bool Equals(Ship other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return (Ship) this == (Ship) obj;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (_x*397) ^ _y;
            }
        }

        public static Ship Parse(string notation)
        {
            int x = 0, y = 0, lenght = 1;
            Direction d = Direction.Horizontal;
            for (int i = 0; i < notation.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        int r = alf.IndexOf(notation[0]);
                        if (r != -1) x = r + 1;
                        else throw new NotAShipException();
                        break;
                    case 1:
                        try
                        {
                            y = int.Parse(notation[1].ToString());
                        }
                        catch (Exception)
                        {
                            throw new NotAShipException();
                        }

                        break;
                    case 2:
                        if (notation[2] != 'x') throw new NotAShipException();
                        break;
                    case 3:
                        try
                        {
                            lenght = int.Parse(notation[3].ToString());
                        }
                        catch (NotAShipException)
                        {

                            throw new NotAShipException();
                        }
                        if (lenght > 4) throw new NotAShipException();
                        break;
                    case 4:

                        switch (notation[4])
                        {
                            case '|':
                                d = Direction.Vertiacal;
                                break;
                            case '-':
                                d = Direction.Horizontal;
                                break;
                            default:
                                throw new NotAShipException();
                        }
                        break;
                }
            }

            return CreateNewShip(x, y, lenght, d);
        }

        private static Ship CreateNewShip(int x, int y, int lenght, Direction direction)
        {
            switch (lenght)
            {
                case (int) ShipTypes.PatrolBoat:
                    return new PatrolBoat(x, y, direction);
                case (int) ShipTypes.Cruiser:
                    return new Cruiser(x, y, direction);
                case (int) ShipTypes.Submarine:
                    return new Submarine(x, y, direction);
                case (int) ShipTypes.AircraftCarrier:
                    return new AircraftCarrier(x, y, direction);
                default:
                    return new Ship(x, y, direction);
            }
        }

        public static bool TryParse(string notation, out Ship pos)
        {

            bool result = true;
            pos = null;
            try
            {
                pos = Parse(notation);
            }
            catch (NotAShipException)
            {
                result = false;
            }
            return result;
        }

        public bool FitsInSquare(int squareHeight, int squareWidth)
        {
            int x = 0, y = 0;
            x = (_direction == Direction.Horizontal) ? x += Length : x = _x;
            y = (_direction == Direction.Vertiacal) ? y += Length : y = _y;
            return _x <= squareWidth && _y <= squareHeight && x <= squareWidth && y <= squareHeight;
        }

        public bool OverlapsWith(Ship otherShip)
        {
            bool result = false;
            for (int i = 0; i < Length; i++)
            {
                int x = (_direction == Direction.Horizontal) ? _x + i : _x;
                int y = (_direction == Direction.Vertiacal) ? _y + i : _y;
                for (int j = 0; j < otherShip.Length; j++)
                {
                    int x2 = (otherShip._direction == Direction.Horizontal) ? otherShip._x + j : otherShip._x;
                    int y2 = (otherShip._direction == Direction.Vertiacal) ? otherShip._y + j : otherShip._y;

                    if (x == x2 && y == y2) result = true;
                }
            }
            int lx = (_direction == Direction.Horizontal) ? Length : 1;
            int ly = (_direction == Direction.Vertiacal) ? Length : 1;
            for (int i = _x - 1; i <= _x+lx; i++)
            {
                for (int j = _y - 1; j <= _y+ly; j++)
                {
                    if ((otherShip._x == i) && (otherShip._y == j)) result = true;
                }
            }
            return result;
        }
    }


}
