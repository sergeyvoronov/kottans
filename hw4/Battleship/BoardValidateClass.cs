using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Ships;

namespace Battleship
{
    public class BoardValidateClass
    {

        private readonly int[] _boats = new int[Enum.GetNames(typeof(ShipTypes)).Length];

        public BoardValidateClass()
        {
            _boats[(int)(ShipTypes.PatrolBoat - 1)] = 4;
            _boats[(int)(ShipTypes.Cruiser - 1)] = 3;
            _boats[(int)(ShipTypes.Submarine - 1)] = 2;
            _boats[(int)(ShipTypes.AircraftCarrier - 1)] = 1;
        }

        public int Length() => _boats.Length;

        public int this[int i]
        {
            get
            {
                return _boats[i];
            }
            set
            {
                _boats[i] = value;
            }
        }

        public override string ToString()
        {
            //  PatrolBoat(4), Cruiser(3), Submarine(2), AircraftCarrier(1)")
            var ar = new List<string>();

            for (int i = 1; i < _boats.Length; i++)
            {
                if (_boats[i] > 0)
                    ar.Add($" {(ShipTypes)i}({_boats[i]})");
            }
            return string.Join(",", ar);
        }

        public bool Ready()
        {
            bool r = true;
            foreach (var b in _boats)
            {
                if (b > 0) r = false;
            }
            return r;
        }
    }

}
