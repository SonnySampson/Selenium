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

        public IWebDriver GetDriver(object webDriverType)
        {
            if (webDriverType is string)
                webDriverType = (WebDriverFactoryType) Enum.Parse(typeof(WebDriverFactoryType), (string)webDriverType);

            switch ((WebDriverFactoryType)webDriverType)
            {
                case WebDriverFactoryType.FireFox:
                    FireFoxWebDriverBuilder();
                    break;
                case WebDriverFactoryType.Chrome:
                    ChromeWebDriverBuilder();
                    break;
                case WebDriverFactoryType.IE:
                    IEWebDriverBuilder();
                    break;
                default:
                    throw new ApplicationException(string.Format("WebDriverType '{0}' cannot be created", webDriverType));
            }
            SetDefaultSettings();
            return this._browser;
        }

        private void FireFoxWebDriverBuilder()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\");
            service.FirefoxBinaryPath = @"C:\Program Files (x86)\Mozilla Firefox\firefox.exe";
            this._browser = new FirefoxDriver(service);
            
        }

        private void IEWebDriverBuilder()
        {
            this._browser = new InternetExplorerDriver();
        }

        private void ChromeWebDriverBuilder()
        {
            this._browser = new ChromeDriver();
        }
        private void SetDefaultSettings()
        {
            this._browser.Manage().Window.Maximize();
            this._browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
