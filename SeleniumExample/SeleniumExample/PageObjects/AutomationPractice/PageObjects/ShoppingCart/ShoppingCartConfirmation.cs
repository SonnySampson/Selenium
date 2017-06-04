using System;
using OpenQA.Selenium;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using SeleniumExample.PageObjects.AutomationPractice.Validators;

namespace SeleniumExample.PageObjects.AutomationPractice.PageObjects
{
    class ShoppingCartConfirmation : IComponent<ShoppingCartConfirmationElementMap,ShoppingCartConfirmationValidator>
    {
        private readonly IWebDriver _browser;
        public ShoppingCartConfirmation(IWebDriver browser)
        {
            _browser = browser;
        }
        public ShoppingCartConfirmationElementMap Map
        {
            get { return new ShoppingCartConfirmationElementMap(_browser); }
        }

        public ShoppingCartConfirmationValidator Validate()
        {
            return new ShoppingCartConfirmationValidator(_browser);
        }
    }
}
