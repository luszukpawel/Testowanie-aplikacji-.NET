using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships;

namespace Battleships
{
    public class GameSettings
    {
        public static readonly Dictionary<ShipType, int> shipLengths = new Dictionary<ShipType, int>()
        {
            {ShipType.Carrier, 5},
            {ShipType.Battleship, 4},
            {ShipType.Destroyer, 3},
            {ShipType.Submarine, 2},
            {ShipType.PatrolBoat, 1}
        };

        public static List<Ship> ShipsInGame = new List<Ship>();
        public static readonly int GRID_SIZE = 10;
        public static string NICK_PATTERN = "/[0-9a-zA-Z]{6,}/";
    }
}
