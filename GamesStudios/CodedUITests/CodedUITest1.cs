﻿using System;
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
    public class CodedUITest1
    {
        public CodedUITest1()
        {

        }

        [TestMethod]
        public void CodedUITestMethod1()
        {

            // this.UIMap.infugedu();
            //  this.UIMap.Edgetest();
            // this.UIMap.ExplorerTest();

            this.UIMap.ASDXD();

            // this.UIMap.XD();

            //this.UIMap.OpenFirefox();
            // this.UIMap.OpenApp();
            //this.UIMap.OpenFirefoxandGotoPage();
            // this.UIMap.TEST1();

            //  this.UIMap.OpenFirefoxandGotoMainPage();
            //  this.UIMap.AddNewGame();

            // this.UIMap.kalk2();
            // this.UIMap.mozilla();

            // this.UIMap.kalktest();

            // this.UIMap.GoToGamesAndCreateNew();

            /*   
               this.UIMap.OpenInternetExplorer();
               this.UIMap.OpenApp();
               this.UIMap.ListaOsobClick();
               this.UIMap.SprAdresClick();
               this.UIMap.ClickEditAdres();
               this.UIMap.EditMiastoPerson();
               this.UIMap.SaveAdresPersonClick();
             */
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