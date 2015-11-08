using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    public class Ship
    {
        public int X, Y;
        public int Length { get; set; }

        public readonly Direction Direction;

        public Ship(int x, int y, Direction direction = 0)
        {
            this.X = x;
            this.Y = y;
            this.Length = 0;
            this.Direction = direction;
        }

        public int borderX => (Direction == Direction.Horizontal) ? X + (Length - 1) : X;
        public int borderY => (Direction == Direction.Vertiacal) ? Y + (Length - 1) : Y;

        public bool FitsInSquare(byte squareHeight, byte squareWidth)
        {
            return borderX <= squareWidth && borderY <= squareHeight;
        }

        public static bool operator ==(Ship ship1, Ship ship2)
        {
            return (ship1.X == ship2.X && ship1.Y == ship2.Y && ship1.Direction == ship2.Direction);
        }

        public static bool operator !=(Ship ship1, Ship ship2)
        {
            return !(ship1 == ship2);
        }

        protected bool Equals(Ship other)
        {
            return X == other.X && Y == other.Y;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X;
                hashCode = (hashCode*397) ^ Y;
                hashCode = (hashCode*397) ^ (int) Direction;
                return hashCode;
            }
        }

        private static string alf="ABCDEFGHIJ";


        public static Ship Parse(string notation)
        {
            int x=0, y=0,lenght=1;
            Direction d = Direction.Horizontal;       
            for (int i = 0; i < notation.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        int r = alf.IndexOf(notation[0]);
                        if (r != -1) x = r+1; else throw  new NotAShipException();
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
                          if (notation[2]!='x') throw  new NotAShipException();
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

                         if (lenght>4) throw new NotAShipException();
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
                                 throw  new NotAShipException();
                        }
                        break;
                }
            }
            
           return  CreateNewShip(x,y,lenght,d);
        }

        private static Ship CreateNewShip(int x, int y, int lenght, Direction direction)
        {
            switch (lenght)
            {
                case (int)ShipTypes.PatrolBoat:return new PatrolBoat(x,y,direction);

                case (int)ShipTypes.Cruiser: return new Cruiser(x,y, direction);
                case (int)ShipTypes.Submarine: return new Submarine(x,y, direction);
                case (int)ShipTypes.AircraftCarrier: return new AircraftCarrier(x,y,direction);
                default: return new Ship(x, y, direction);
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

        public bool OverlapsWith(Ship ship)
        {
            return (X - 1 <= ship.borderX && borderX + 1 >= ship.X && Y - 1 <= ship.borderY && borderY + 1 >= ship.Y);
        }

        public override string ToString()
        {
            String d = (Direction == Direction.Horizontal) ? "-" : "|";
            return  $"{alf[X]}{Y}x{Length}{d}";
        }
    }

   
}
