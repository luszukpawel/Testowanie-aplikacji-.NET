using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Battleships.Fakes;


namespace Battleships.Tests
{
    [TestClass()]
    public class PlayerTests
    {

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod()]
        [DeploymentItem("ShipHorizontal.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
                 "|DataDirectory|\\ShipHorizontal.xml",
                 "Ship",
                  DataAccessMethod.Sequential)]
        public void PlaceShipsXMLTest()
        {
            var row = TestContext.DataRow;
            var index = row["index"];
            string type = row["Type"].ToString();
            var _x = row["x"].ToString();
            var _y = row["y"].ToString();

            ShipType shipType = (ShipType)Enum.Parse(typeof(ShipType), type);

            Player player = new Player();
            Ship ship = new Ship(shipType);

            Tile tile = new Tile(Int32.Parse(_x), Int32.Parse(_y));
            bool result = player.PlaceShipHorizontal(ship, tile);
            Assert.IsTrue(result);

        }

        [TestMethod()]
        public void PlaceShipVerticalTest()
        {
            Player player = new Player();
            Ship ship = new Ship(ShipType.PatrolBoat);
            Tile tile = new Tile(5, 5);
            bool result = player.PlaceShipVertical(ship, tile);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void PlaceShipHorizontalTest()
        {
            Player player = new Player();
            Ship ship = new Ship(ShipType.PatrolBoat);
            Tile tile = new Tile(5, 5);
            bool result = player.PlaceShipHorizontal(ship, tile);
            Assert.IsTrue(result);
        }

        //collection assert example
        [TestMethod()]
        public void SinkShipTest()
        {
            Player player = new Player();
            Ship ship = new Ship(ShipType.PatrolBoat);
            ship.index = 1;
            player._myShips.Add(ship);
            player.SinkShip(ship.index);
            CollectionAssert.DoesNotContain(player._myShips, ship);
        }

        [TestMethod()]
        public void MyGridInitTest()
        {
            Player player = new Player();
            player.MyGridInit();

            Assert.AreEqual(player.MyGrid[5, 5].Type, TileType.Water);
        }

        [TestMethod()]
        public void EnemyGridInitTest()
        {
            Player player = new Player();
            player.EnemyGridInit();

            Assert.AreEqual(player.EnemyGrid[5, 5].Type, TileType.Unknown);
        }

        // StringAssert Class example
        [TestMethod()]
        public void SetNickname_ThrowExeptionWhenPlayerNotValid_Test()
        {
            Player player = new Player();

            string nonvalidnick = "xd";

            try
            {
                player.SetNickName(nonvalidnick);
                Assert.Fail("ArgumentExeption expected");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e is ArgumentException);
            }
        }

        [TestMethod()]
        public void SetNickname_ThrowExeptionWhenPlayerIsValid_Test()
        {
            IPlayer stubPlayer = new StubIPlayer()
            {
                ValidateNickNameString = (x) => { return true; }
            };
            string nonvalidnick = "xd";

            var result = stubPlayer.SetNickName(nonvalidnick);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void FireTest()
        {

            Player player = new Player();
            Ship ship = new Ship(ShipType.PatrolBoat);
            ship.index = 1;
            Tile tile = new Tile(5, 5);
            player._myShips.Add(ship);
            player.MyGrid[5, 5].Type = TileType.Undamaged;
            Boolean resiult = player.Fire(5, 5);
            Assert.IsTrue(resiult);


        }

        [TestMethod()]
        public void isLostTest()
        {
            bool wasSinkshipCalled = false;
            IPlayer stubplayer = new StubIPlayer()
            {
                SinkShipInt32 = (x) => { wasSinkshipCalled = true; }
            };
            Player player = new Player();
            Ship ship = new Ship(ShipType.PatrolBoat);
            ship.index = 1;
            player._myShips.Add(ship);
            player.SinkShip(ship.index);
            var result = player.isLost();
            Assert.IsTrue(wasSinkshipCalled);

        }


        [TestMethod]
        public void TestCurrentSWVersion()
        {/*
            int expected = 10;
            IPlayer player = new Battleships.Fakes.IPlayer()
                {
                    // Definitions for multiple methods can be combined by separating by commas.
                    CurrentSWVersionInt32 = (DeviceID) => { return 10;},
                    IsSWUpgradeRequiredInt32 = (DeviceID) => { return true; }
                };
            int actual = us.currentSWVersion(1);
            Assert.AreEqual(expected, actual, "Same Versions found
            */

        }

        [TestMethod()]
        public void SetNickNameTest()
        {
            IPlayer stubPlayer = new StubIPlayer()
            {

            };

        }
    }
}
