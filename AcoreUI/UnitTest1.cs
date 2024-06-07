using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Cryptography;
using System.Threading;

namespace AcoreUI
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSearchStreetFighterVThenVerifyStreetFighterVIsDisplayed()
        {
            int waitingTime = 2000;
            // Testing by name in inspect element
            By googleSearchBar = By.Name("q");

            // Google search button name
            By googleSearchButton = By.Name("btnK");
            By googleResultText = By.XPath(".//a//h3[text()='ACORE Capital: Welcome']"); // h3 inside a
           // By googleIAgreeButton = By.Id("L2AGLb");

            IWebDriver webDriver = new ChromeDriver();

            Thread.Sleep(waitingTime);

            webDriver.Navigate().GoToUrl("https://www.google.com");

            Thread.Sleep(waitingTime);

            //webDriver.FindElement(googleIAgreeButton).Click();

            webDriver.Manage().Window.Maximize();

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchBar).SendKeys("ACORE Capital");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(googleSearchButton).Click();

            Thread.Sleep(waitingTime);

            var actualResultText = webDriver.FindElement(googleResultText);

            Assert.IsTrue(actualResultText.Text.Equals("ACORE Capital: Welcome"));

            webDriver.Quit();
        }
    }
}