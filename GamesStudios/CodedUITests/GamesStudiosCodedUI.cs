using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace CodedUITests
{
    [CodedUITest]
    public class GamesStudiosCodedUI
    {


        [TestMethod]
        public void CodedUiUpdeteGame()
        {

            this.UIMap.CodedUiUpdeteGame();

        }
        [TestMethod]
        public void CodedUiDeleteGenre()
        {

            this.UIMap.CodedUiDeleteGenre();


        }

        [TestMethod]
        public void CodedUiDeleteGame()
        {

            this.UIMap.CodedUiDeleteGame();
        }

        [TestMethod]
        public void CodedUiAddNewGame()
        {

            this.UIMap.CodedUIAddNewGame();

        }

        [TestMethod]
        public void CodedUiAddNewGenre()
        {
            this.UIMap.AddNewGenre();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;

    }
}