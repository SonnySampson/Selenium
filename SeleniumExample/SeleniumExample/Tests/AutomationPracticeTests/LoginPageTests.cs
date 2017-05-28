using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
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
    public class AutomationPracticeLoginPageTests : ITest
    {
        public IWebDriver Browser { get; set; }
        public WebDriverWait Wait { get; set; }
        public WebDriverFactory webDriverFactory = new WebDriverFactory();
        public const string loginParamsFilePath = @"C:\LoginVariables.txt";
        private static List<string[]> data;
        public static ILog logger = LogManager.GetLogger(typeof(AutomationPracticeLoginPageTests));

        [TestInitialize]
        public void SetupTest()
        {
            //Staring log of test
            BasicConfigurator.Configure();
            logger.Info("Starting Login Tests");
            
            //Retrieving variables, if data file not found fail test
            FileIO file = new FileIO();
            data = file.ParseFile(loginParamsFilePath, ',');
            if (data == null)
                logger.Error(string.Format("The data file '{0}' was not found! " + 
                    "Please add a text file with vairbles formatted with email@address.com,password format", loginParamsFilePath));

            
        }

        [TestMethod]
        public void PositiveLogin()
        {
            Browser = webDriverFactory.GetDriver(WebDriverFactoryType.FireFox);
            Wait = new WebDriverWait(this.Browser, TimeSpan.FromSeconds(30));
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            AutomationPracticeHeaderPage headerPage = new AutomationPracticeHeaderPage(this.Browser); 
            AutomationPracticeLoginPage loginPage;
            headerPage.Navigate();
            loginPage = headerPage.GotoLoginPage();
            loginPage.Login(data[2][0], data[2][1]);
            headerPage.Validate().LoginName("Test Test");
        }
        
        [TestMethod]
        [TestCase(WebDriverFactoryType.FireFox)]
        [TestCase(WebDriverFactoryType.Chrome)]
        [TestCase(WebDriverFactoryType.IE)]
        public void NegativeLogin(object webDriverType)
        {
            Browser = webDriverFactory.GetDriver(webDriverType);
            AutomationPracticeHeaderPage headerPage = new AutomationPracticeHeaderPage(this.Browser);
            AutomationPracticeLoginPage loginPage;
            headerPage.Navigate();
            loginPage = headerPage.GotoLoginPage();
            loginPage.Login("wrong@wrong.com", "worng");
            loginPage.Validate().LoginErrorMessage("There is 1 error", "Authentication failed.");
            Browser.Quit();
        }


        [TestCleanup]
        public void TeardownTest()
        {
            
            Browser.Dispose();
        }
    }
}
