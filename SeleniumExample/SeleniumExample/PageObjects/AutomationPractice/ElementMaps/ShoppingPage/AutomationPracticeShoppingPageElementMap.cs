using System;
using OpenQA.Selenium;

namespace SeleniumExample.PageObjects.AutomationPractice.ElementMaps
{
    class AutomationPracticeShoppingPageElementMap : IElementMap
    {
        private readonly IWebDriver _browser;
        public AutomationPracticeShoppingPageElementMap(IWebDriver browser)
        {
            _browser = browser;
        }

        public IWebElement HeaderDisplay
        {
            get { return _browser.FindElement(By.ClassName("content_scene_cat_bg")); }
        }

        public IWebElement HeaderTitle 
        {
            get { return _browser.FindElement(By.ClassName("category-name")); }
        }

        public IWebElement HeaderSubTitle
        {
            get { return _browser.FindElement(By.ClassName("rte")); }
        }

        public IWebElement SortByDropDown
        {
            get { return _browser.FindElement(By.Id("selectProductSort")); }
        }

        public IWebElement ShowingText
        {
            get { return _browser.FindElement(By.ClassName("product-count")); }
        }

        public IWebElement ItemContainer
        {
            get { return _browser.FindElement(By.ClassName("product_list grid row"));}
        }

    }
}
