using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GamesStudios;
using GamesStudios.Models;

namespace MvcTest
{
    [TestClass]
    public class ModelTests
    {
        [TestMethod]
        public void Date_Validation_Valid()
        {
            DataValidation validator = new DataValidation();
            DateTime date = new DateTime(1889, 12, 1);
            Assert.IsTrue(validator.IsValid(date));
        }

        [TestMethod]
        public void Date_Validation_NotValid()
        {
            DataValidation validator = new DataValidation();
            DateTime date = new DateTime(1300, 12, 1);
            Assert.IsFalse(validator.IsValid(date));
        }

        [TestMethod]
        public void GenreValidation_Valid()
        {
            var model = new Genre()
            {
              //  doc = new DateTime(1889, 12, 1)
            };

            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);

        }




        [TestMethod]
        public void GameValidation_Valid()
        {
            var model = new Game();

            var results = TestModelHelper.Validate(model);

            Assert.AreEqual(0, results.Count);

        }


     
    }
}
