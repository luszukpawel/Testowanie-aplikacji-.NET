using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    public class GameManager : GameSettings
    {
        public Player Player1 = new Player();
        public Player Player2 = new Player();

        public DateTime TimeOFMatchStart;
        void PrepareGameScene()
        {
            Player1.PlayerToAttack = Player2;
            Player2.PlayerToAttack = Player1;
        }

        public void Play()
        {
            TimeOFMatchStart = GetCurrentDate();
        }

        public DateTime GetCurrentDate()
        {
            return DateTime.Now;
        }
        public void SavePlayerScore()
        {

        }
    }
}
