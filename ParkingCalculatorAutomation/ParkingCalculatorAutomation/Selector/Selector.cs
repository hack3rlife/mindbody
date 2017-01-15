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

        public static IWebElement SelectByName(string name)
        {
            return Driver.Instance.FindElement(By.Name(name));
        }

        public static ReadOnlyCollection<IWebElement> SelectElementsByName(string name)
        {
            return Driver.Instance.FindElements(By.Name(name));
        }

        public static IWebElement SelectByXPath(string xpath)
        {
            return Driver.Instance.FindElement(By.XPath(xpath));
        }

        public static IWebElement SelectByLinkText(string text)
        {
            return Driver.Instance.FindElement(By.LinkText(text));

        }
    }
}
