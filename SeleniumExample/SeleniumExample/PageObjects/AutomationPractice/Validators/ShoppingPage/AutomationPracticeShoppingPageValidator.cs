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
            Assert.AreEqual(string.Format("Showing {0} - {1} of {2} items", startingItem, endingItem, totalItems),
                this.Map.ShowingText.Text.Trim());
        }
    }
}
