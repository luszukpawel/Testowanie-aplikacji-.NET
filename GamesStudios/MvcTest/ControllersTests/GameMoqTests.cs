using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamesStudios.Models;
using GamesStudios.DAL;
using Moq;
using GamesStudios.Controllers;
using System.Web.Mvc;

namespace MvcTest.Tests
{
    [TestClass]
    public class GameMoqTests
    {
        [TestMethod]
        public void TestDetailsMoq()
        {
            Game Game = new Game { ID = 1, Name = "The Wish" };
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();
            context.Setup(x => x.FindGameById(2)).Returns(Game);
            var controller = new GameController(context.Object);

            var result = controller.Details(2) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
            var resultGenre = (Game)result.Model;
            Assert.AreEqual("The Wish", resultGenre.Name);
        }

        [TestMethod]
        public void TestEditGenreMoq()
        {
            Game Game = new Game { ID = 1, Name = "RPG" };
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();
            context.Setup(x => x.FindGameById(2)).Returns(Game);
            var controller = new GameController(context.Object);

            var result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultGenre = (Game)result.Model;
            Assert.AreEqual("RPG", resultGenre.Name);
        }

        [TestMethod]
        public void TestEditConfirmGenreMoq()
        {
            Game Game = new Game { ID = 1, Name = "The Wish" };
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();
            context.Setup(x => x.FindGameById(2)).Returns(Game);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new GameController(context.Object);

            Game.Name = "The Wish";
            var result = controller.Edit(Game) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Game", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void TestEditModelNotValidMoq()
        {
            Game Game = new Game { ID = 1, Name = "The Wish" };
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();
            context.Setup(x => x.FindGameById(2)).Returns(Game);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new GameController(context.Object);

            Game.Name = "Leo34";

            controller.ViewData.ModelState.AddModelError("Name", "Podałeś złe imie");
            var result = (ViewResult)controller.Edit(Game);
            Assert.AreEqual("Edit", result.ViewName);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DetailsGenreExceptionMoq()
        {
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();

            context.Setup(x => x.FindGameById(2)).Returns((Game)null);
            var controller = new GameController(context.Object);

            var result = controller.Details(2) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
            var resultGame = (Game)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EditGenreExceptionMoq()
        {
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();

            context.Setup(x => x.FindGameById(2)).Returns((Game)null);
            var controller = new GameController(context.Object);

            var result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultGame = (Game)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }
    }
}
