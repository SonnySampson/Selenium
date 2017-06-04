using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumExample.PageObjects.AutomationPractice.ElementMaps
{
    public class HeaderPageElementMap : IElementMap
    {
        private readonly IWebDriver _browser;
        public HeaderPageElementMap(IWebDriver browser)
        {
            _browser = browser;
        }

        public IWebElement SignIn
        {
            get
            {
                return _browser.FindElement(By.ClassName("login"));
            }
        }

        public IWebElement UserName
        {
            get
            {
                return _browser.FindElement(By.ClassName("account")).FindElement(By.TagName("span"));
            }
        }
    }
}
