using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTest.Doubles;
using GamesStudios.Controllers;
using GamesStudios.Models;
using System.Linq;
using System.Web.Mvc;

namespace MvcTest.Tests
{
    [TestClass]
    public class GameControllerTests
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
        public void GameControllerCreate()
        {
            var contextLocal = new FakeGamesDBContext();
            contextLocal.Genres = new[]
            {
                new Genre { ID = 1, Name = "Shooter" },
                new Genre { ID = 2, Name = "aRPG" },
                new Genre { ID = 3, Name = "SportGame" },
            }.AsQueryable();

            var controller = new GameController(contextLocal);
            var result = (ViewResult)controller.Create();
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void GameControllerTestCreateNotValid()
        {
            context.Genres = new[]
            {
                new Genre { ID = 1, Name = "Shooter" },
                new Genre { ID = 2, Name = "aRPG" },
                new Genre { ID = 3, Name = "SportGame" },
            }.AsQueryable();

            var controller = new GameController(context);

            Game Game = new Game { ID = 4, Name = "2341", };

            controller.ViewData.ModelState.AddModelError("Imie", "Podałeś złe nazwe");
            var result = (ViewResult)controller.Create(Game);
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void GameControllerTestDeleteValid()
        {
            var controller = new GameController(context);
            var result = (ViewResult)controller.Delete(2);
            Assert.AreEqual("", result.ViewName);
        }

    
    }
}
