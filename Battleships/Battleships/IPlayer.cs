namespace Battleships
{
    public interface IPlayer
    {

        bool Fire(int x, int y, Player playerToAttack);
        void Hit(int x, int y);
        void SinkShip(Ship ship);
        bool ValidateNickName(string _nick);
        bool SetNickName(string _nick);
        void MyGridInit();
        void EnemyGridInit();
        bool PlaceShipVertical(Ship ship, Tile tile);
        bool PlaceShipHorizontal(Ship ship, Tile tile);
        void SinkShip(int index);
        bool isLost();


    }
}