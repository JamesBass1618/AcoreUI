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
        public void AcoreUI()
        {
            int waitingTime = 2000;

            // Testing by name in inspect element
            // Name is q in HTML
            By googleSearchBar = By.Name("q"); 

            // Google search button name
            By googleSearchButton = By.Name("btnK");

            // Acore employee login button
            By acoreButton = By.Id("btnSubmitEmployeeLogin");

            // Acore email
            By emailButton = By.Id("i0116");

            // Next selection button
            By nextButton = By.Id("idSIButton9");

            // Password button
            By passwordButton = By.Id("i0118");

            By googleResultText = By.XPath(".//a//h3[text()='ACORE Capital: Welcome']"); // h3 inside a;
            string bbAddress = "https://acorebackshop.azurewebsites.net/acore/pages/shared/login.aspx?ReturnUrl=%2fLocator%2fLoanLocator.aspx";
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

            webDriver.Navigate().GoToUrl(bbAddress);

            Thread.Sleep(waitingTime);

            webDriver.FindElement(acoreButton).Click();

            // Give time to see
            Thread.Sleep(waitingTime);

            webDriver.FindElement(emailButton).SendKeys("jbass@acorecapital.com"); ;

            Thread.Sleep(waitingTime);

            // Go to the next button
            webDriver.FindElement(nextButton).Click();

            Thread.Sleep(waitingTime);

            webDriver.FindElement(passwordButton).SendKeys("!Getmein22");

            Thread.Sleep(waitingTime);

            webDriver.FindElement(nextButton).Click();

            Thread.Sleep(waitingTime);

            webDriver.Quit();

           
        }
    }
}