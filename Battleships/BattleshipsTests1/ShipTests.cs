using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Tests
{
    [TestClass()]
    public class ShipTests
    {
 
        [TestMethod()]
        public void DeployTest()
        {
            Ship ship = new Ship(ShipType.PatrolBoat);
            ship._health = 0;
            ship.Deploy();
            Assert.AreEqual(ship._health, GameSettings.shipLengths[ship._type]);
        }

        [TestMethod()]
        public void IsSunkTest()
        {
            Ship ship = new Ship(ShipType.PatrolBoat);
            ship._health = 0;
            var result = ship.IsSunk();
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void HitTest()
        {
            Ship ship = new Ship(ShipType.PatrolBoat);
            var healthBeforeHit = ship._health;
            ship.Hit();
            var healthAfterHit = ship._health;
            Assert.AreNotEqual(healthBeforeHit,healthAfterHit);
        }
    }
}