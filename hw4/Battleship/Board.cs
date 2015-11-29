using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Battleship.Exceptions;
using Battleship.Ships;

namespace Battleship
{
    public class Board
    {

        private List<Ship> _ships;
        BoardValidateClass validation = new BoardValidateClass();

        public Board()
        {
               _ships = new List<Ship>();
        }
   
        public void Add(Ship ship)
        {
            if (!ship.FitsInSquare(ship.X + ship.Length, ship.Y + ship.Length)) throw new ArgumentOutOfRangeException();
            if (!_ships.Any())
                _ships.Add(ship);
            else
            {
                for (int i = 0; i<_ships.Count; i++)
                {
                    if (_ships[i].OverlapsWith(ship))
                        throw new ShipOverlapException($"Ship {_ships[i].ToString()} - overlaps with {ship.ToString()}");
                    _ships.Add(ship);
                }
            }
        }

        public List<Ship> GetAll()
        {
                return _ships;
        }

        public void Add(string notation)
        {
            Ship ship;
            if (Ship.TryParse(notation, out ship)) Add(ship);
            else throw new NotAShipException();

        }

        public void Validate()
        {
            if (!validation.Ready()) throw new BoardIsNotReadyException(
                $"There is not sufficient count of ships. We need: {validation.ToString()}");
        }
    }
}
