using System;
using OpenQA.Selenium;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using NUnit.Framework;

namespace SeleniumExample.PageObjects.AutomationPractice.Validators
{
    public class HeaderPageValidator : IValidator<HeaderPageElementMap>
    {
        private readonly IWebDriver _browser;
        public HeaderPageValidator(IWebDriver browser)
        {
            _browser = browser;
        }
        public HeaderPageElementMap Map
        {
            get
            {
                return new HeaderPageElementMap(_browser);
            }
        }

        public void LoginName(string expectedName)
        {
            Assert.IsTrue(this.Map.UserName.Text.Equals(expectedName),
                string.Format("The username does not match! \nExpected: {0} \nActual: {1}", expectedName, this.Map.UserName.Text));
        }
    }
}
