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
            // Name is q in HTML
            By googleSearchBar = By.Name("q"); 

            // Google search button name
            By googleSearchButton = By.Name("btnK");
            By googleResultText = By.XPath(".//a//h3[text()='ACORE Capital: Welcome']"); // h3 inside a;

            IWebDriver webDriver = new ChromeDriver();

            Thread.Sleep(waitingTime);

            webDriver.Navigate().GoToUrl("https://www.google.com");

            Thread.Sleep(waitingTime);

            webDriver.Manage().Window.Maximize();

            Thread.Sleep(waitingTime);

            // Input ACORE Capital into the search bar
            webDriver.FindElement(googleSearchBar).SendKeys("ACORE Capital");

            Thread.Sleep(waitingTime);

            // Click/Enter query or search
            webDriver.FindElement(googleSearchButton).Click();

            // Give time to see
            Thread.Sleep(waitingTime);

            // Compare result to what we are actually seeing
            var actualResultText = webDriver.FindElement(googleResultText);

            Assert.IsTrue(actualResultText.Text.Equals("ACORE Capital: Welcome"));


            webDriver.Quit();
        }
    }
}