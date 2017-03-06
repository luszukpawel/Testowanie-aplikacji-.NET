using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Ship
    {
        public int _health;
        public int index;
        public readonly ShipType _type;


        public Ship(ShipType type)
        {
            _type = type;
            Deploy();
        }

        public void Deploy()
        {
            _health = GameSettings.shipLengths[_type];
        }

        public bool IsSunk()
        {
                return _health == 0 ? true : false;         
        }

        public bool Hit()
        {
            _health--;
            return IsSunk();
        }
    }
}
