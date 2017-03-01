using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Ship
    {
        private int _health;
        private readonly ShipType _type;

        private static readonly Dictionary<ShipType, int> shipLengths = new Dictionary<ShipType, int>()
   {
            {ShipType.Carrier, 5},
            {ShipType.Battleship, 4},
            {ShipType.Destroyer, 3},
            {ShipType.Submarine, 3},
            {ShipType.PatrolBoat, 2}
};

        public Ship(ShipType type)
        {
            _type = type;
            _health = shipLengths[_type];
        }

        public void Deploy()
        {
            
        }

        public bool IsSunk()
        {
            return true;
        }

        public bool Hit()
        {
            return true;
        }
    }
}
