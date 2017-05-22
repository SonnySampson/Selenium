using System;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace SeleniumExample.PageObjects
{
    public interface IPageObject<T, U>
    {
        void Navigate();
        T Map
        {
            get;
        }
        U Validate();
    }
}
