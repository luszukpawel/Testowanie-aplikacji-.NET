using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    class Ship
    {
        private int _health;
        private readonly ShipType _type;

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
