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
    
    class AutomationPracticeShoppingPage : IPageObject<AutomationPracticeShoppingPageElementMap, AutomationPracticeShoppingPageValidator>
    {
        private readonly IWebDriver _browser;
        private readonly string urlWomen = @"http://automationpractice.com/index.php?id_category=3&controller=category";
        private readonly string urlTops = @"http://automationpractice.com/index.php?id_category=4&controller=category";
        private readonly string urlDresses = @"http://automationpractice.com/index.php?id_category=8&controller=category";
        private List<AutomationPracticeShoppingPageItem> _shoppingItems;
       
        public AutomationPracticeShoppingPage(IWebDriver browser)
        {
            _browser = browser;
        }

        public void Navigate()
        {
            this._browser.Navigate().GoToUrl(urlWomen);
        }


        public void Navigate(ShoppingPageURL page)
        {
            switch(page)
            {
                case ShoppingPageURL.Women:
                    this._browser.Navigate().GoToUrl(urlWomen);
                    break;
                case ShoppingPageURL.Dresses:
                    this._browser.Navigate().GoToUrl(urlDresses);
                    break;
                case ShoppingPageURL.Tops:
                    this._browser.Navigate().GoToUrl(urlTops);
                    break;
                default:
                    throw new ArgumentException(string.Format("The value '{0}' is either not a valid value or has not been implemented."), page.ToString());
            }
        }

        public AutomationPracticeShoppingPageElementMap Map
        {
            get { return new AutomationPracticeShoppingPageElementMap(this._browser); }
        }

        public AutomationPracticeShoppingPageValidator Validate()
        {
            return new AutomationPracticeShoppingPageValidator(this._browser);
        }

        public List<AutomationPracticeShoppingPageItem> ShoppingItems
        {
            get { return (this._shoppingItems == null) ? this.GetShoppingItems() : this._shoppingItems; }
        }


        private List<AutomationPracticeShoppingPageItem> GetShoppingItems()
        {
            this._shoppingItems = new List<AutomationPracticeShoppingPageItem>();
            foreach(IWebElement shoppingItem in this.Map.ShoppingItems)
            {
                this._shoppingItems.Add(new AutomationPracticeShoppingPageItem(this._browser, shoppingItem));
            }
            return this._shoppingItems;
        }

        public List<AutomationPracticeShoppingPageItem> RefreshShoppingItems()
        {
            return GetShoppingItems();
        }
        

    }
}
