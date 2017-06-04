using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using SeleniumExample.PageObjects.AutomationPractice.Validators;
using SeleniumExample.TestHelpers;

namespace SeleniumExample.PageObjects.AutomationPractice.PageObjects
{
    class ShoppingPageItem : IComponent<ShoppingPageItemElementMap, ShoppingPageItemValidator>
    {
        private readonly IWebDriver _browser;
        private readonly IWebElement _shoppingItem;
        private readonly UiHelpers _uiHelper;
        public ShoppingPageItem(IWebDriver browser, IWebElement shoppingItem)
        {
            _browser = browser;
            _shoppingItem = shoppingItem;
            _uiHelper = new UiHelpers(_browser);
        }

        public ShoppingPageItemElementMap Map
        {
            get { return new ShoppingPageItemElementMap(_browser, _shoppingItem); }
        }

        public ShoppingPageItemValidator Validate()
        {
            return new ShoppingPageItemValidator(_browser, _shoppingItem);
        }

        public void ScrollToItem()
        {
            _uiHelper.ScrollToElement(_shoppingItem);
        }

        public void HoverOverItem()
        {
            this.ScrollToItem();
            _uiHelper.HoverOverElement(_shoppingItem);
        }

        public void AddItemToCart()
        {
            this.HoverOverItem();
            this.Map.AddToCart.Click();
        }
    }
}
