using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumExample.Tests
{
    interface ITest
    {
        void SetupTest();
        void TeardownTest();
    }
}
