using System;
using OpenQA.Selenium;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using NUnit.Framework;

namespace SeleniumExample.PageObjects.AutomationPractice.Validators
{
    class LoginPageValidator : IValidator<LoginPageElementMap>
    {
        private readonly IWebDriver _browser;
        public LoginPageValidator(IWebDriver browser)
        {
            _browser = browser;
        }
        public LoginPageElementMap Map
        {
            get
            {
                return new LoginPageElementMap(_browser);
            }
        }

        public void LoginErrorMessage(string expectedErrorTitle, string expectedErrorMessage)
        {
            //Verifying Login Error Title
            Assert.IsTrue(this.Map.LoginErrorMessageTitle.Text.Equals(expectedErrorTitle),
                string.Format("The login error title does not match! \nExpected: {0} \nActual: {1}", expectedErrorTitle, 
                this.Map.LoginErrorMessageContent.Text));
            
            //Verifying Login Error Message
            Assert.IsTrue(this.Map.LoginErrorMessageContent.Text.Equals(expectedErrorMessage),
                string.Format("The login error message does not match! \nExpected: {0} \nActual: {1}", expectedErrorMessage,
                this.Map.LoginErrorMessageContent.Text));
        }
    }
}
