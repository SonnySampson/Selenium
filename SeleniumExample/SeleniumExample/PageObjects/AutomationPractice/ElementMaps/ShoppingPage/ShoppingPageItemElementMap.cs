using System;
using OpenQA.Selenium;

namespace SeleniumExample.PageObjects.AutomationPractice.ElementMaps
{
    class ShoppingPageItemElementMap : IElementMap
    {
        private readonly IWebDriver _browser;
        private readonly IWebElement _shoppingElement;
        public ShoppingPageItemElementMap(IWebDriver browser, IWebElement shoppingItem)
        {
            _browser = browser;
            _shoppingElement = shoppingItem;
        }

        public IWebElement ShoppingItem
        {
            get { return _shoppingElement; }
        }
        public IWebElement Name
        {
            get { return _shoppingElement.FindElement(By.ClassName("product-name")); }
        }

        public IWebElement DisplayedPrice
        {
            get { return _shoppingElement.FindElement(By.XPath(".//div[@class='right-block']//span[@class='price product-price']")); }
        }

        public IWebElement AddToCart
        {
            get { return _shoppingElement.FindElement(By.XPath(".//a[@class='button ajax_add_to_cart_button btn btn-default']")); }
        }
    }
}
