using System;
using System.Collections.Generic;

namespace SeleniumExample.PageObjects
{
    public interface IComponent<T, U>
    {
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
