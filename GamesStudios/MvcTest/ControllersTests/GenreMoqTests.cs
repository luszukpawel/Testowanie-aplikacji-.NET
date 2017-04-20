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
    public class GenreMoqTests
    {
        [TestMethod]
        public void TestDetailsMoq()
        {
            Genre Genre = new Genre();
            Genre.ID = 1;
            Genre.Name = "RPG";
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();
            context.Setup(x => x.FindGenreById(2)).Returns(Genre);
            var controller = new GenreController(context.Object);

            var result = controller.Details(2) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
            var resultGenre = (Genre)result.Model;
            Assert.AreEqual("RPG", resultGenre.Name);
        }

        [TestMethod]
        public void TestEditGenreMoq()
        {
            Genre Genre = new Genre();
            Genre.ID = 2;
            Genre.Name = "RPG";
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();
            context.Setup(x => x.FindGenreById(2)).Returns(Genre);
            var controller = new GenreController(context.Object);

            var result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultGenre = (Genre)result.Model;
            Assert.AreEqual("RPG", resultGenre.Name);
        }

        [TestMethod]
        public void TestEditConfirmGenreMoq()
        {
            Genre Genre = new Genre();
            Genre.ID = 1;
            Genre.Name = "RPG";
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();
            context.Setup(x => x.FindGenreById(2)).Returns(Genre);
            context.Setup(s => s.SaveChanges()).Returns(0);
            var controller = new GenreController(context.Object);

            Genre.Name = "jRPG";
          //  Genre.doc = new DateTime(1889, 12, 1);
            var result = controller.Edit(Genre) as RedirectToRouteResult;

            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Genre", result.RouteValues["Controller"]);
        }



        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DetailsGenreExceptionMoq()
        {
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();

            context.Setup(x => x.FindGenreById(2)).Returns((Genre)null);
            var controller = new GenreController(context.Object);

            var result = controller.Details(2) as ViewResult;

            Assert.AreEqual("Details", result.ViewName);
            var resultGenre = (Genre)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EditGenreExceptionMoq()
        {
            Mock<IGamesStudiosDBContext> context = new Mock<IGamesStudiosDBContext>();

            context.Setup(x => x.FindGenreById(2)).Returns((Genre)null);
            var controller = new GenreController(context.Object);

            var result = controller.Edit(2) as ViewResult;

            Assert.AreEqual("Edit", result.ViewName);
            var resultGenre = (Genre)result.Model;
            Assert.AreEqual(typeof(Exception), result.GetType());
        }
    }


}
