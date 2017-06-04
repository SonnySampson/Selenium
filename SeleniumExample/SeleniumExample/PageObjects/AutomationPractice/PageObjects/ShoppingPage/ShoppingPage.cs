using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExample.PageObjects.AutomationPractice.ElementMaps;
using SeleniumExample.PageObjects.AutomationPractice.Validators;

namespace SeleniumExample.PageObjects.AutomationPractice.PageObjects
{
    public enum ShoppingPageURL
    {
        Women,
        Tops,
        Dresses
    }
    
    class ShoppingPage : IPageObject<ShoppingPageElementMap, ShoppingPageValidator>
    {
        private readonly IWebDriver _browser;
        private readonly string urlWomen = @"http://automationpractice.com/index.php?id_category=3&controller=category";
        private readonly string urlTops = @"http://automationpractice.com/index.php?id_category=4&controller=category";
        private readonly string urlDresses = @"http://automationpractice.com/index.php?id_category=8&controller=category";
        private List<ShoppingPageItem> _shoppingItems;
       
        public ShoppingPage(IWebDriver browser)
        {
            _browser = browser;
        }

        public void Navigate()
        {
            _browser.Navigate().GoToUrl(urlWomen);
        }


        public void Navigate(ShoppingPageURL page)
        {
            switch(page)
            {
                case ShoppingPageURL.Women:
                    _browser.Navigate().GoToUrl(urlWomen);
                    break;
                case ShoppingPageURL.Dresses:
                    _browser.Navigate().GoToUrl(urlDresses);
                    break;
                case ShoppingPageURL.Tops:
                    _browser.Navigate().GoToUrl(urlTops);
                    break;
                default:
                    throw new ArgumentException(string.Format("The value '{0}' is either not a valid value or has not been implemented."), page.ToString());
            }
        }

        public ShoppingPageElementMap Map
        {
            get { return new ShoppingPageElementMap(_browser); }
        }

        public ShoppingPageValidator Validate()
        {
            return new ShoppingPageValidator(_browser);
        }

        public List<ShoppingPageItem> ShoppingItems
        {
            get { return (_shoppingItems == null) ? this.GetShoppingItems() : _shoppingItems; }
        }


        private List<ShoppingPageItem> GetShoppingItems()
        {
            _shoppingItems = new List<ShoppingPageItem>();
            foreach(IWebElement shoppingItem in this.Map.ShoppingItems)
            {
                _shoppingItems.Add(new ShoppingPageItem(_browser, shoppingItem));
            }
            return _shoppingItems;
        }

        public List<ShoppingPageItem> RefreshShoppingItems()
        {
            return GetShoppingItems();
        }
        

    }
}
