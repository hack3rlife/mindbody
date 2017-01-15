using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ParkingCalculatorAutomation
{
    public class DateTimeSelector
    {
        public static IWebElement SelectById(string id)
        {
            return Selector.SelectById(id);
        }

        public static ReadOnlyCollection<IWebElement> SelectByName(string name)
        {
            return Selector.SelectByName(name);
        }

        internal static IWebElement SelectByXPath(string xpath)
        {
            return Selector.SelectByXPath(xpath);
        }
    }
}
