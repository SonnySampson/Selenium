using System;
using OpenQA.Selenium;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using NUnit.Framework;

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

        public void LoginErrorMessage(string expectedErrorTitle, string expectedErrorMessage)
        {
            Assert.IsTrue(this.Map.LoginErrorMessageTitle.Text.Equals(expectedErrorTitle),
                string.Format("The login error title does not match! \nExpected: {0} \nActual: {1}", expectedErrorTitle, 
                this.Map.LoginErrorMessageContent.Text));
            Assert.IsTrue(this.Map.LoginErrorMessageContent.Text.Equals(expectedErrorMessage),
                string.Format("The login error message does not match! \nExpected: {0} \nActual: {1}", expectedErrorMessage,
                this.Map.LoginErrorMessageContent.Text));
        }
    }
}
