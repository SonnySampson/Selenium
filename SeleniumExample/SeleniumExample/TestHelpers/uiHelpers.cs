using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumExample.TestHelpers
{
    class UiHelpers
    {
        private readonly IWebDriver _browser;
        private readonly Actions _action;
        public UiHelpers(IWebDriver browser)
        {
            _browser = browser;
            _action = new Actions(_browser);
        }

        public void ScrollToElement(IWebElement webElement)
        {
            ((IJavaScriptExecutor)_browser).ExecuteScript("arguments[0].scrollIntoView(true);",webElement);
        }

        public void HoverOverElement(IWebElement webElement)
        {
            if (!webElement.Displayed)
                this.ScrollToElement(webElement);
            _action.MoveToElement(webElement).Click().Build().Perform();
        }
    }
}
