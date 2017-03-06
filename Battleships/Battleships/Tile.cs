using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Tile
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int ShipIndex { get; set; }

        public TileType Type;

        public Tile(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public void Reset(Tile type)
        {
            ShipIndex = -1;
        }


    }
}
