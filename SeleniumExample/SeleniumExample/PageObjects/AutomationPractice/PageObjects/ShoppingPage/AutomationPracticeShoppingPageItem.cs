using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using SeleniumExample.PageObjects.AutomationPractice.Validators;

namespace SeleniumExample.PageObjects.AutomationPractice.PageObjects
{
    class AutomationPracticeShoppingPageItem : IComponent<AutomationPracticeShoppingItemElementMap, AutomationPracticeShoppingPageItemValidator>
    {
        private readonly IWebDriver _browser;
        private readonly IWebElement _shoppingItem;
        public AutomationPracticeShoppingPageItem(IWebDriver browser, IWebElement shoppingItem)
        {
            this._browser = browser;
            this._shoppingItem = shoppingItem;
        }

        public AutomationPracticeShoppingItemElementMap Map
        {
            get { return new AutomationPracticeShoppingItemElementMap(this._browser, this._shoppingItem); }
        }

        public AutomationPracticeShoppingPageItemValidator Validate()
        {
            return new AutomationPracticeShoppingPageItemValidator(this._browser, this._shoppingItem);
        }
    }
}
