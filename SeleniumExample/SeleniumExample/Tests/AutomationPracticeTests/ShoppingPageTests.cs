﻿using System;
using System.Threading;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using SeleniumExample.PageObjects.AutomationPractice.PageObjects;
using SeleniumExample.TestHelpers;
using OpenQA.Selenium.Support.PageObjects;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using log4net;
using log4net.Config;

namespace SeleniumExample.Tests.AutomationPracticeTests
{
    [TestClass]
    class ShoppingPageTests
    {  
        public IWebDriver Browser { get; set; }
        public WebDriverWait Wait { get; set; }
        public WebDriverFactory webDriverFactory = new WebDriverFactory();
        public static ILog logger = LogManager.GetLogger(typeof(AutomationPracticeLoginPageTests));

        [TestInitialize]
        public void SetupTest()
        {
            //Staring log of test
            BasicConfigurator.Configure();
            logger.Info("Starting ShoppingPage Tests");            
        }
  
        [TestMethod]
        [TestCase(WebDriverFactoryType.FireFox, ShoppingPageURL.Dresses, 1, 5, 5, 5)]
        public void NumberOfItems(object webDriverType, ShoppingPageURL url, int startingItem, int endingItem, int totalItems, int shoppingItems)
        {
            Browser = webDriverFactory.GetDriver(webDriverType);
            AutomationPracticeShoppingPage shoppingPage = new AutomationPracticeShoppingPage(Browser);
            shoppingPage.Navigate(url);
            shoppingPage.Validate().ShowingTitle(startingItem, endingItem, totalItems);
            shoppingPage.Validate().NumberOfShoppingItems(shoppingItems);
            Browser.Quit();
        }

        [TestMethod]
        [TestCase(WebDriverFactoryType.Chrome, ShoppingPageURL.Tops, 0, "Faded Short Sleeve T-shirts", 16.51)]
        public void VerifyShoppingItem(object webDriverType, ShoppingPageURL url, int shoppingItemIndex, string shoppingItemName, double shoppingItemPrice)
        {
            Browser = webDriverFactory.GetDriver(webDriverType);
            AutomationPracticeShoppingPage shoppingPage = new AutomationPracticeShoppingPage(Browser);
            shoppingPage.Navigate(url);
            //TODO: Used to scroll to the shopping Item, make helper method
            ((IJavaScriptExecutor)Browser).ExecuteScript("arguments[0].scrollIntoView(true);", 
                shoppingPage.ShoppingItems[shoppingItemIndex].Map.ShoppingItem);
            shoppingPage.ShoppingItems[shoppingItemIndex].Validate().Name(shoppingItemName);
            shoppingPage.ShoppingItems[shoppingItemIndex].Validate().Price(shoppingItemPrice);
            Browser.Quit();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            Browser.Quit();
            Browser.Dispose();
        }
    }
}
