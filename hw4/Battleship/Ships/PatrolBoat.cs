namespace Battleship.Ships
{
    public class PatrolBoat : Ship
    {
        public PatrolBoat(int x, int y) : base(x, y)
        {
        }

        public PatrolBoat(int x, int y, Direction direction) : base(x, y, direction)
        {
            Length = (int)ShipTypes.PatrolBoat;
        }

    }
}
