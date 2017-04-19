using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamesStudios.Controllers;
using GamesStudios.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTest.Doubles;

namespace MvcTest.Tests
{
    [TestClass]
    public class GameControllerExeptionsTests
    {
        FakeGamesDBContext context;

        [TestInitialize()]
        public void Initialize()
        {
            context = new FakeGamesDBContext();
            context.Games = new[]
            {
                new Game { ID = 1, Name = "AWtS",},
                new Game { ID = 2, Name = "Gravity and Mirrors",},

            }.AsQueryable();
        }

        [TestMethod]
        public void GenreControllerTestInit()
        {
            var context = new FakeGamesDBContext();
            var controller = new GameController();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GameControllerDetailsException()
        {
            var controller = new GameController(context);
            var result = controller.Details(8);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GameControllerEditViewException()
        {
            var controller = new GameController(context);
            var result = controller.Edit(8);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GameControllerTestDeleteNotValid()
        {
            var controller = new GameController(context);
            var result = controller.Delete(7);
            Assert.AreEqual(typeof(Exception), result.GetType());
        }
    }
}
