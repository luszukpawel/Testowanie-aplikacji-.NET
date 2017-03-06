using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class Player : IPlayer
    {
        public string PlayerNick;
        public bool Fire(int x, int y, Player playerToAttack)
        {
            if (x <= GameSettings.GRID_SIZE && y <= GameSettings.GRID_SIZE)
            {
                if (playerToAttack.MyGrid[x, y].Type == TileType.Undamaged)
                {
                    playerToAttack.MyGrid[x, y].Type = TileType.Damaged;
                    return true;
                }
            }
            return false;
        }
        public void Hit(int x, int y)
        {
            MyGrid[x, y].Type = TileType.Damaged;
        }

        public void SinkShip(Ship ship)
        {
        }

        public Tile[,] MyGrid = new Tile[GameSettings.GRID_SIZE, GameSettings.GRID_SIZE];
        public Tile[,] EnemyGrid = new Tile[GameSettings.GRID_SIZE, GameSettings.GRID_SIZE];


        public List<Ship> _myShips = new List<Ship>();
        public List<Ship> _enemyShips = new List<Ship>();

        public Player()
        {
            MyGridInit();
            EnemyGridInit();

            foreach (ShipType type in Enum.GetValues(typeof(ShipType)))
            {
                _myShips.Add(new Ship(type));
                _enemyShips.Add(new Ship(type));
            }

        }

        public void SetNickname(string _nick)
        {
            if (_nick.Length > 2)
                PlayerNick = _nick;
        }

        //set all player tiles to water
        public void MyGridInit()
        {
            for (int i = 0; i < GameSettings.GRID_SIZE; i++)
            {
                for (int j = 0; j < GameSettings.GRID_SIZE; j++)
                {
                    MyGrid[i, j] = new Tile(i, j) { Type = TileType.Water };
                }
            }
        }
        //set all enemy tiles to unknown
        public void EnemyGridInit()
        {
            for (int i = 0; i < GameSettings.GRID_SIZE; i++)
            {
                for (int j = 0; j < GameSettings.GRID_SIZE; j++)
                {
                    EnemyGrid[i, j] = new Tile(i, j) { Type = TileType.Unknown };
                }
            }
        }

        //places ship of player vertical
        public bool PlaceShipVertical(Ship ship, Tile tile)
        {
            int x = tile.x;
            int y = tile.y;
            int shipLengthsCount = 0;
            int size = GameSettings.shipLengths[ship._type];


            for (int i = 0; i < GameSettings.GRID_SIZE; i++)
            {
                for (int j = 0; j < GameSettings.GRID_SIZE; j++)
                {
                    if (i == x && j == y && y + size <= GameSettings.GRID_SIZE)
                    {
                        for (int k = size; k >= 1; k--)
                        {
                            if (MyGrid[i, j + k].Type == TileType.Water)
                            {
                                shipLengthsCount++;
                            }
                        }
                    }

                    if (shipLengthsCount == size)
                    {
                        for (int k = size; k >= 1; k--)
                        {
                            GameSettings.ShipsInGame.Add(ship);
                            _myShips.Add(ship);
                            MyGrid[i, j + k].Type = TileType.Undamaged;
                            MyGrid[i, j + k].ShipIndex = GameSettings.ShipsInGame.IndexOf(ship);

                        }
                        return true;
                    }

                }
            }
            return false;
        }

        //places ship of player horizontal
        public bool PlaceShipHorizontal(Ship ship, Tile tile)
        {
            int x = tile.x;
            int y = tile.y;
            int shipLengthsCount = 0;
            int size = GameSettings.shipLengths[ship._type];


            for (int i = 0; i < GameSettings.GRID_SIZE; i++)
            {
                for (int j = 0; j < GameSettings.GRID_SIZE; j++)
                {
                    if (i == x && j == y && x + size <= GameSettings.GRID_SIZE)
                    {
                        for (int k = size; k >= 1; k--)
                        {
                            if (MyGrid[i + k, j].Type == TileType.Water)
                            {
                                shipLengthsCount++;
                            }
                        }
                    }

                    if (shipLengthsCount == size)
                    {
                        for (int k = size; k >= 1; k--)
                        {
                            GameSettings.ShipsInGame.Add(ship);
                            _myShips.Add(ship);
                            MyGrid[i + k, j].Type = TileType.Undamaged;
                            MyGrid[i + k, j].ShipIndex = GameSettings.ShipsInGame.IndexOf(ship);

                        }
                        return true;
                    }

                }
            }
            return false;

        }

        public void SinkShip(int index)
        {
            for (int i = 0; i < GameSettings.GRID_SIZE; i++)
            {
                for (int j = 0; j < GameSettings.GRID_SIZE; j++)
                {
                    if (MyGrid[i, j].ShipIndex == index)
                    {
                        MyGrid[i,j].Type = TileType.Sunk;
                     }
                }
            }
            for (int i = _myShips.Count-1; i >= 0; i--)
            {
                if (_myShips[i].index == index)
                {
                    _myShips.Remove(_myShips[i]);
                }
            }
        }

        public bool isLost()
        {
            if (_myShips.Any()) return true;

            return false;
        }

    }
}
