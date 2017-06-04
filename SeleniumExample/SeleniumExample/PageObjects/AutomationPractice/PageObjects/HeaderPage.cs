using System;
using OpenQA.Selenium;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using SeleniumExample.PageObjects.AutomationPractice.Validators;

namespace SeleniumExample.PageObjects.AutomationPractice.PageObjects
{
    class HeaderPage : IPageObject<HeaderPageElementMap, HeaderPageValidator>
    {
        private readonly IWebDriver _browser;
        private readonly string url = @"http://automationpractice.com/index.php";
        public HeaderPage(IWebDriver browser)
        {
            _browser = browser;
        }
        public void Navigate()
        {
            _browser.Navigate().GoToUrl(url);
        }

        public HeaderPageElementMap Map
        {
            get
            {
                return new HeaderPageElementMap(_browser);
            }
        }

        public HeaderPageValidator Validate()
        {
            return new HeaderPageValidator(_browser);
        }

        public LoginPage GotoLoginPage()
        {
            this.Map.SignIn.Click();
            return new LoginPage(_browser);

        }
    }
}
