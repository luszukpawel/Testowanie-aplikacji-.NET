using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
   public class Player
    {
        public string PlayerNick;
        protected void Fire(int row, int col, Player player)
        {
        }
        private void SinkShip(Ship ship)
        {
        }

        public List<List<Tile>> MyGrid { get; set; }
        public List<List<Tile>> EnemyGrid { get; set; }

        private List<Ship> _myShips = new List<Ship>();
        private List<Ship> _enemyShips = new List<Ship>();

        public Player()
        {
        }


        private bool PlaceShipVertical(int shipIndex, int remainingLength)
        {
            return true;
        }

        private bool PlaceShipHorizontal(int shipIndex, int remainingLength)
        {
            return true;
        }

        
        public void PlaceShips()
        {
           
        }

        private void SunkPlayerShip(int i)
        {
            
        }

        public void SunkEnemyShip(int i)
        {
            
        }

        public TileType FiredAt(int row, int col, int damagedIndex, bool isSunk)
        {
           return TileType.Unknown;
        }

        public bool Lost()
        {
            return true;
        }
    }
}
