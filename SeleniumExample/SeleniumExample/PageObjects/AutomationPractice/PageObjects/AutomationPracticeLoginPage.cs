using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using SeleniumExample.PageObjects.AutomationPractice.Validators;

namespace SeleniumExample.PageObjects.AutomationPractice.PageObjects
{
    class AutomationPracticeLoginPage : IPageObject<AutomationPracticeLoginPageElementMap, AutomationPracticeLoginPageValidator>
    {
        public readonly IWebDriver _browser;
        private readonly string url = @"http://automationpractice.com/index.php?controller=authentication&back=my-account";
        public AutomationPracticeLoginPage(IWebDriver browser)
        {
            _browser = browser;
        }

        public void Navigate()
        {
            _browser.Navigate().GoToUrl(url);
        }

        public AutomationPracticeLoginPageElementMap Map
        {
            get { return new AutomationPracticeLoginPageElementMap(_browser); }
        }

        public AutomationPracticeLoginPageValidator Validate()
        {
            return new AutomationPracticeLoginPageValidator(_browser);
        }

        public void Login(string username, string password)
        {
            this.Map.EmailAddressText.SendKeys(username);
            this.Map.PasswordText.SendKeys(password);
            this.Map.SignInButton.Click();
        }
    }
}
