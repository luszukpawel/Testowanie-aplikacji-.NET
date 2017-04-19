using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcTest.Doubles;
using GamesStudios.Controllers;
using GamesStudios.Models;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel;

namespace MvcTest.Tests
{
    [TestClass]
    public class GenreControllerTests
    {
        FakeGamesDBContext context;

        [TestInitialize()]
        public void Initialize()
        {
            context = new FakeGamesDBContext();
            context.Genres = new[]
            {
                new Genre { ID = 1, Name = "Shooter" },
                new Genre { ID = 2, Name = "aRPG" },
                new Genre { ID = 3, Name = "SportGame" },
            }.AsQueryable();
        }

        [TestMethod]
        public void GenreControllerTestInit()
        {
            var context = new FakeGamesDBContext();
            var controller = new GenreController();
        }

        [TestMethod]
        public void GenreControllerTestDetails()
        {
            var controller = new GenreController(context);
            var result = controller.Details(2) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
            var resultGenre = (Genre)result.Model;
            Assert.AreEqual("aRPG", resultGenre.Name);
        }

        [TestMethod]
        public void GenreControllerTestEditGenre()
        {
            var controller = new GenreController(context);
            var result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultGenre = (Genre)result.Model;
            Assert.AreEqual("aRPG", resultGenre.Name);
        }

        [TestMethod]
        public void GenreControllerTestEditModelNotValid()
        {
            var controller = new GenreController(context);

            Genre Genre = new Genre { ID = 2, Name = "FC Barcelona" };

            controller.ViewData.ModelState.AddModelError("Data", "Podałeś złą datę");
            var result = (ViewResult)controller.Edit(Genre);
            Assert.AreEqual("Edit", result.ViewName);
        }

       

        [TestMethod]
        public void GenreControllerCreate()
        {
            var contextLocal = new FakeGamesDBContext();

            var controller = new GenreController(contextLocal);
            var result = (ViewResult)controller.Create();
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void GenreControllerTestCreateNotValid()
        {
            var controller = new GenreController(context);

            Genre Genre = new Genre { ID = 4, Name = "FC Barcelona" };

            controller.ViewData.ModelState.AddModelError("Data", "Podałeś złą datę");
            var result = (ViewResult)controller.Create(Genre);
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void GenreControllerTestDeleteValid()
        {
            var controller = new GenreController(context);
            var result = (ViewResult)controller.Delete(2);
            Assert.AreEqual("", result.ViewName);
        }


    }
}
