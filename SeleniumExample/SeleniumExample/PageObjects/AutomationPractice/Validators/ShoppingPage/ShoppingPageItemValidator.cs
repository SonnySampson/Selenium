using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using NUnit.Framework;

namespace SeleniumExample.PageObjects.AutomationPractice.Validators
{
    class ShoppingPageItemValidator : IValidator<ShoppingPageItemElementMap>
    {
        private readonly IWebDriver _browser;
        private readonly IWebElement _shoppingItem;
        public ShoppingPageItemValidator(IWebDriver browser, IWebElement shoppingItem)
        {
            _browser = browser;
            _shoppingItem = shoppingItem;
        }

        public ShoppingPageItemElementMap Map
        {
            get { return new ShoppingPageItemElementMap(_browser, _shoppingItem); }
        }

        public void Name(string expectedName)
        {
            string actualName = this.Map.Name.Text.Trim();
            Assert.AreEqual(expectedName, actualName, string.Format("The shopping item name doesnot match! \n expected: {0} \n actual: {1}", 
                expectedName, actualName));
        }

        public void Price(double expectedPrice)
        {
            string actualPrice = this.Map.DisplayedPrice.Text.Trim();
            string expectedPriceString = "$" + expectedPrice.ToString();
            Assert.AreEqual(expectedPriceString, actualPrice, string.Format("The price of shopping item named '{0}', does not match! \n expected: {1} \n actual:",
                this.Map.Name.Text.Trim(), expectedPriceString, actualPrice));
        }
    }
}
