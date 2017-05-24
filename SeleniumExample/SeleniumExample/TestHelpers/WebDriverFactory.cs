using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumExample.TestHelpers
{
    public enum WebDriverFactoryType
    {
        FireFox,
        Chrome,
        IE
    }
    public class WebDriverFactory
    {
        private IWebDriver _browser;

        public IWebDriver GetDriver(WebDriverFactoryType webDriverType)
        {
            switch (webDriverType)
            {
                case WebDriverFactoryType.FireFox:
                    return FireFoxWebDriverBuilder();
                case WebDriverFactoryType.Chrome:
                case WebDriverFactoryType.IE:
                    throw new NotImplementedException(string.Format("WebDriverType '{0}' has not been implemented", webDriverType));
                default:
                    throw new ApplicationException(string.Format("WebDriverType '{0}' cannot be created", webDriverType));
            }
        }

        private IWebDriver FireFoxWebDriverBuilder()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\");
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            this._browser = new FirefoxDriver(service);
            this._browser.Manage().Window.Maximize();
            return this._browser;
            
        }
    }
}
