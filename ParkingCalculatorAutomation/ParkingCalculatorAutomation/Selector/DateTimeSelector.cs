using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ParkingCalculatorAutomation
{
    internal class DateTimeSelector
    {
        internal static IWebElement SelectById(string id)
        {
            return Selector.SelectById(id);
        }

        internal static ReadOnlyCollection<IWebElement> SelectByName(string name)
        {
            return Selector.SelectElementsByName(name);
        }

        internal static IWebElement SelectByXPath(string xpath)
        {
            return Selector.SelectByXPath(xpath);
        }

        internal static IWebElement SelectByLinkText(string text)
        {
            return Selector.SelectByLinkText(text);
        }
    }
}
