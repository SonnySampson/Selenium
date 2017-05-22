﻿using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumExample.PageObjects.AutomationPractice.ElementMaps
{
    class AutomationPracticeLoginPageElementMap : IElementMap
    {
        private readonly IWebDriver _browser;
        public AutomationPracticeLoginPageElementMap(IWebDriver browser)
        {
            _browser = browser;
        }

        public IWebElement EmailAddressText
        {
            get 
            { 
                return _browser.FindElement(By.Id("email"));
            }
        }

        public IWebElement PasswordText
        {
            get
            {
                return _browser.FindElement(By.Id("passwd"));
            }
        }

        public IWebElement SignInButton
        {
            get
            {
                return _browser.FindElement(By.Id("SubmitLogin"));
            }
        }
    }
}