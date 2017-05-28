using System;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace SeleniumExample.PageObjects
{
    public interface IValidator<T> 
    {
        T Map
        {
            get;
        }

    }
}
