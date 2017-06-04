using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using NUnit.Framework;

namespace SeleniumExample.PageObjects.AutomationPractice.Validators
{
    class ShoppingCartConfirmationValidator : IValidator<ShoppingCartConfirmationElementMap>
    {
        private readonly IWebDriver _browser;
        private readonly WebDriverWait _wait;
        public ShoppingCartConfirmationValidator(IWebDriver browser)
        {
            _browser = browser;
            _wait = new WebDriverWait(_browser, TimeSpan.FromSeconds(10));
        }

        public ShoppingCartConfirmationElementMap Map
        {
            get { return new ShoppingCartConfirmationElementMap(_browser); }
        }

        public void ConfirmationMessage(string expectedMessage)
        {
            _wait.Until(ExpectedConditions.TextToBePresentInElement(this.Map.ConfirmationMessage, expectedMessage));
            string actualMessage = this.Map.ConfirmationMessage.Text.Trim();
            Assert.AreEqual(expectedMessage, actualMessage,
                string.Format("This cofirmation page did not have the expected confirmation message \nexpected: {0} \nactual:{1}",
                expectedMessage, actualMessage));
        }
    }
}
