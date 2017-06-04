using System;
using OpenQA.Selenium;

namespace SeleniumExample.PageObjects.AutomationPractice.ElementMaps
{
    class AutomationPracticeShoppingItemElementMap : IElementMap
    {
        private readonly IWebDriver _browser;
        private readonly IWebElement _shoppingElement;
        public AutomationPracticeShoppingItemElementMap(IWebDriver browser, IWebElement shoppingItem)
        {
            this._browser = browser;
            this._shoppingElement = shoppingItem;
        }

        public IWebElement ShoppingItem
        {
            get { return _shoppingElement; }
        }
        public IWebElement Name
        {
            get { return this._shoppingElement.FindElement(By.ClassName("product-name")); }
        }

        public IWebElement DisplayedPrice
        {
            get { return this._shoppingElement.FindElement(By.XPath(".//div[@class='right-block']//span[@class='price product-price']")); }
        }
    }
}
