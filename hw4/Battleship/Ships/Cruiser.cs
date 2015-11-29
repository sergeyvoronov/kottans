using System;

namespace Battleship.Ships
{
   public class Cruiser : Ship
    {
       public Cruiser(int x, int y) : base(x, y)
       {
       }

       public Cruiser(int x, int y, Direction direction) : base(x, y, direction)
       {
            Length = (int)ShipTypes.Cruiser;

        }


    }


}
