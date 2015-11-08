using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip;

namespace Battleship
{
    public class Board
    {

        //   [TestCase("There is not sufficient count of ships. We need: PatrolBoat (4), Cruiser (3), Submarine (2), AircraftCarrier (1)")]
        private List<Ship> ships;

        Dictionary<ShipTypes, int> dictionaryShips = new Dictionary<ShipTypes, int>()
        {
            { ShipTypes.PatrolBoat, 4},
             { ShipTypes.Cruiser, 3},
              { ShipTypes.Submarine, 2},
               { ShipTypes.AircraftCarrier, 1}
        };
         
        public Board()
        {
            ships = new List<Ship>();
        }

        public void Add(string str)
        {
            Ship ship;
            if (Ship.TryParse(str, out ship)) Add(ship);
            else throw new NotAShipException();
        }

        public void Add(Ship ship)
        {
            foreach (var s in ships)
            {   
                if (s.OverlapsWith(ship))  throw new ShipOverlapException($"Ship {s.ToString()} - overlaps with {ship.ToString()}");
                if (ship.FitsInSquare(ship.X, ship.Y)) throw new ArgumentOutOfRangeException();
            }
           ships.Add(ship);
        }

        public List<Ship> GetAll()
        {
            return ships;
        }

        public int Count()
        {
            return ships.Count;
        }

        public bool Validate()
        {
            BoardValidateClass boats = new BoardValidateClass();

            foreach (var s in ships)
            {
                boats[s.Length] = -1;
            }
            if (!boats.Ready())
            {
                throw new BoardIsNotReadyException($"There is not sufficient count of ships. We need: {boats.ToString()}");
            }
            else
            {
                return true;
            }

            return false;
        }
    }
}
