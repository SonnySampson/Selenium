using System;
using OpenQA.Selenium;

namespace SeleniumExample.PageObjects.AutomationPractice.ElementMaps
{
    class ShoppingCartConfirmationElementMap : IElementMap
    {
         private readonly IWebDriver _browser;
         public ShoppingCartConfirmationElementMap(IWebDriver browser)
        {
            _browser = browser;
        }

        public IWebElement ConfirmationMessage
         {
             get { return _browser.FindElement(By.XPath(".//div[@id='layer_cart']//div[@class='clearfix']/div/h2")); }
         }
    }
}
