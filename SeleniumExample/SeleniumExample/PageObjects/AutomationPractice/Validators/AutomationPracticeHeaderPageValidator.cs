using System;
using OpenQA.Selenium;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using NUnit.Framework;

namespace SeleniumExample.PageObjects.AutomationPractice.Validators
{
    public class AutomationPracticeHeaderPageValidator : IValidator<AutomationPracticeHeaderPageElementMap>
    {
        private readonly IWebDriver _browser;
        public AutomationPracticeHeaderPageValidator(IWebDriver browser)
        {
            _browser = browser;
        }
        public AutomationPracticeHeaderPageElementMap Map
        {
            get
            {
                return new AutomationPracticeHeaderPageElementMap(_browser);
            }
        }

        public void LoginName(string expectedName)
        {
            Assert.IsTrue(this.Map.UserName.Text.Equals(expectedName),
                string.Format("The username does not match! \nExpected: {0} \nActual: {1}", expectedName, this.Map.UserName.Text));
        }
    }
}
