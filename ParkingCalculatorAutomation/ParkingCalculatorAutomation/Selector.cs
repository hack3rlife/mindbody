using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ParkingCalculatorAutomation
{
    public static class Selector
    {
        public static IWebElement SelectById(string id)
        {
            return Driver.Instance.FindElement(By.Id(id));
        }

        public static ReadOnlyCollection<IWebElement> SelectByName(string name)
        {
            return Driver.Instance.FindElements(By.Name(name));
        }

        internal static IWebElement SelectByXPath(string xpath)
        {
            return Driver.Instance.FindElement(By.XPath(xpath));
        }

        internal static IWebElement SelectByXPath(object css)
        {
            throw new NotImplementedException();
        }
    }
}
