using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using NUnit.Framework;

namespace SeleniumExample.PageObjects.AutomationPractice.Validators
{
    class AutomationPracticeShoppingPageValidator : IValidator<AutomationPracticeShoppingPageElementMap>
    {
        IWebDriver _browser;
        public AutomationPracticeShoppingPageValidator(IWebDriver browser)
        {
            _browser = browser;
        }

        public AutomationPracticeShoppingPageElementMap Map
        {
            get { return new AutomationPracticeShoppingPageElementMap(_browser); }
        }

        public void ShowingTitle(int startingItem, int endingItem, int totalItems)
        {
            string expectedMessage = string.Format("Showing {0} - {1} of {2} items", startingItem, endingItem, totalItems);
            Assert.AreEqual(expectedMessage, this.Map.ShowingText.Text.Trim(),
                string.Format("The showing title is incorrect, \nExpected: '{0}'  \nActual: '{1}'", expectedMessage, this.Map.ShowingText.Text.Trim()));
        }

        public void NumberOfShoppingItems(int expectedAmount)
        {
            int actualAmount = this.Map.ShoppingItems.Count;
            Assert.AreEqual(expectedAmount, actualAmount, string.Format("Incorrect amount of items, \nExpected: {0} \nActual:{1}", expectedAmount, actualAmount));
        }
    }
}
