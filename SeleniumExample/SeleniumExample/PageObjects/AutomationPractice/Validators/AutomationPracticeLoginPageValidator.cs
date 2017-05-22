using System;
using OpenQA.Selenium;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;

namespace SeleniumExample.PageObjects.AutomationPractice.Validators
{
    class AutomationPracticeLoginPageValidator : IValidator<AutomationPracticeLoginPageElementMap>
    {
        private readonly IWebDriver _browser;
        public AutomationPracticeLoginPageValidator(IWebDriver browser)
        {
            _browser = browser;
        }
        public AutomationPracticeLoginPageElementMap Map
        {
            get
            {
                return new AutomationPracticeLoginPageElementMap(_browser);
            }
        }
    }
}
