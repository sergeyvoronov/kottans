using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip;

namespace Battleship
{
    public class Board
    {

        private List<Ship> ships;

        public Board()
        {
            ships = new List<Ship>();
        } 
        public void Add(Ship ship)
        {
            foreach (var s in ships)
            {
                if (s.OverlapsWith(ship))  throw new ShipOverlapException($"Ship {s.ToString()} - overlaps with {ship.ToString()}");
                if (s.FitsInSquare(ship)) throw  new ArgumentOutOfRangeException();
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
    }
}
