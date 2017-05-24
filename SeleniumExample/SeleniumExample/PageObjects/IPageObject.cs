using System;
using OpenQA.Selenium;
using System.Collections.Generic;


namespace SeleniumExample.PageObjects
{
    /// <summary>
    /// Contains the properties and methods each PageObject class requires.
    /// Each PageObject is used to control a specific webpage or logical portion of a webpage that is being tested.
    /// </summary>
    /// <typeparam name="T">A class that implements the IElementMap interface.</typeparam>
    /// <typeparam name="U">A class that implements the IValidator interface.</typeparam>
    public interface IPageObject<T, U>
    {
        /// <summary>
        /// Used to navigate the PageObject's URL.
        /// </summary>
        void Navigate();
        
        /// <summary>
        ///Gets the PageObject's elements that a user can interact with.  
        /// </summary>
        T Map
        {
            get;
        }

        /// <summary>
        /// Used to get the PageObject's IValidator object, which is used to verify a PageObject's elements.
        /// </summary>
        /// <returns>An instance of the PageObject's object that implments the IValidator interface.</returns>
        U Validate();
    }
}
