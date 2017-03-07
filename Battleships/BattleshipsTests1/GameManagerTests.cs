using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleships.Fakes;
using Microsoft.QualityTools.Testing.Fakes;

namespace Battleships.Tests
{
    [TestClass()]
    public class GameManagerTests
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        // Shims example
        [TestMethod()]
        public void PlayTest()
        {
            // Assert.Fail();
            using (ShimsContext.Create())
            {
                DateTime dataTimeFixed = new DateTime(1990, 1, 1);
                // var myInstance = new ShimGameManager();
                // ShimGameManager.Play = () => {GetCurrentDate = () => dataTimeFixed };
                var myInstance = new ShimGameManager { GetCurrentDate = () => dataTimeFixed };
                DateTime myInstancedataDateTime = myInstance.Instance.GetCurrentDate();
                Assert.AreEqual(dataTimeFixed,myInstancedataDateTime);
            }
        }
    }


}

