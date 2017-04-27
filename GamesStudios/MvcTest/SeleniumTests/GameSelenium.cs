using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.PhantomJS;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace MVC_ASP.Tests.Tests
{
    [TestClass]
    public class SeleniumGame
    {

        [TestMethod]
        public void SelenumAddGame()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:59145/Game");


            driver.FindElement(By.CssSelector("div.container:nth-child(2) > p:nth-child(2) > a:nth-child(1)")).Click();


            driver.FindElement(By.XPath("//*[@id=\"xd\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"xd\"]")).SendKeys("SeleniumNameTest");
            driver.FindElement(By.XPath("//*[@id=\"GenreID\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"GenreID\"]")).SendKeys("SeleniumGenreTest");
            driver.FindElement(By.CssSelector(".btn")).Click();


            string checkTest = driver.FindElement(By.Name("MainTitle")).Text;

            Assert.AreEqual("Lista Gier", checkTest);
            driver.Close();
        }

        [TestMethod]
        public void SelenumDeleteGame()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:59145/Game");

            IWebElement tabela = driver.FindElement(By.XPath("/html/body/div/div/table/tbody"));
            int IleKolumnPrzed = tabela.FindElements(By.XPath("tr")).Count;

            driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[2]/td[3]/a[3]")).Click();

            string checkTest = driver.FindElement(By.Name("MainTitle")).Text;

            driver.FindElement(By.XPath("/html/body/div/div/form/div/input")).Click();

            IWebElement tabela2 = driver.FindElement(By.XPath("/html/body/div/div/table/tbody"));
            int IleKilumnPo = tabela2.FindElements(By.XPath("tr")).Count;

            Assert.AreEqual(IleKolumnPrzed, IleKilumnPo + 1);

            driver.Close();
        }

        [TestMethod]
        public void SelenumEditGame()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:59145/Game");


            driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[2]/td[3]/a[2]")).Click();

            string checkTest = driver.FindElement(By.Name("MainTitle")).Text;
            
            Assert.AreEqual("Edit Game", checkTest);

            driver.FindElement(By.XPath("//*[@id=\"Name\"]")).Click();
            driver.FindElement(By.XPath("//*[@id=\"Name\"]")).SendKeys("AfterUpdete");
            driver.FindElement(By.XPath("/ html / body / div / form / div / div[3] / div / input")).Click();

            string checkTest2 = driver.FindElement(By.Name("MainTitle")).Text;

            Assert.AreEqual("Lista Gier", checkTest2);
            driver.Close();
        }

        [TestMethod]
        public void SelenumDetailsGame()
        {
            IWebDriver driver = new ChromeDriver();
            INavigation nav = driver.Navigate();
            nav.GoToUrl("http://localhost:59145/Game");


            driver.FindElement(By.XPath("/html/body/div/div/table/tbody/tr[2]/td[3]/a[1]")).Click();

            string checkTest = driver.FindElement(By.Name("MainTitle")).Text;

            Assert.AreEqual("Game Details", checkTest);

            driver.Close();
        }

        
        /*
                [TestMethod]
                public void TestClickSprawdzAdres()
                {
                    IWebDriver driver = new FirefoxDriver();
                    INavigation nav = driver.Navigate();
                    nav.GoToUrl("http://localhost:59145/Game/Create");
                    IWebElement element = driver.FindElement(By.CssSelector("div.container:nth-child(2) > p:nth-child(2) > a:nth-child(1)"));
                    element.Click();
                    string checkTest = driver.FindElement(By.CssSelector("Title")).Text;
                    Assert.AreEqual("Adres osoby", checkTest);
                    driver.Close();
                }

                [TestMethod]
                public void TestClickUsun()
                {
                    IWebDriver driver = new FirefoxDriver();
                    INavigation nav = driver.Navigate();
                    nav.GoToUrl("http://localhost:59145/Game");
                    IWebElement element = driver.FindElement(By.Name("usunGame"));
                    element.Click();
                    string checkTest = driver.FindElement(By.Id("Title")).Text;
                    Assert.AreEqual("Usuwanie osoby", checkTest);
                    driver.Close();
                }

                [TestMethod]
                public void TestTextEdytuj()
                {
                    IWebDriver driver = new FirefoxDriver();
                    INavigation nav = driver.Navigate();
                    nav.GoToUrl("http://localhost:59145/Game");
                    IWebElement el = driver.FindElement(By.Name("edytuj"));
                    String message = el.Text;
                    String successMsg = "Edytuj dane";
                    Assert.AreEqual(message, successMsg);
                    driver.Close();
                }


            */

    }
}
