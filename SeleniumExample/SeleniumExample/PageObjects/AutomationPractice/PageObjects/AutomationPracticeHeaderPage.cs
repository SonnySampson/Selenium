using System;
using OpenQA.Selenium;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using SeleniumExample.PageObjects.AutomationPractice.Validators;

namespace SeleniumExample.PageObjects.AutomationPractice.PageObjects
{
    class AutomationPracticeHeaderPage : IPageObject<AutomationPracticeHeaderPageElementMap, AutomationPracticeHeaderPageValidator>
    {
        private readonly IWebDriver _browser;
        private readonly string url = @"http://automationpractice.com/index.php";
        public AutomationPracticeHeaderPage(IWebDriver browser)
        {
            _browser = browser;
        }
        public void Navigate()
        {
            _browser.Navigate().GoToUrl(url);
        }

        public AutomationPracticeHeaderPageElementMap Map
        {
            get
            {
                return new AutomationPracticeHeaderPageElementMap(_browser);
            }
        }

        public AutomationPracticeHeaderPageValidator Validate()
        {
            return new AutomationPracticeHeaderPageValidator(_browser);
        }

        public AutomationPracticeLoginPage GotoLoginPage()
        {
            this.Map.SignIn.Click();
            return new AutomationPracticeLoginPage(_browser);

        }
    }
}
