using System;
using OpenQA.Selenium.Support.UI;

namespace ParkingCalculatorAutomation
{
    internal class DatePickerSelector
    {
        internal static void SelectYear(string year)
        {
            throw new NotImplementedException();
        }

        internal static void SelectMonth(string month)
        {
            var dropDown = Selector.SelectByName("MonthSelector");
            var select = new SelectElement(dropDown);
            select.SelectByText(month);
        }

        internal static void SelectDay(string day)
        {
            Selector.SelectByLinkText(day).Click();
        }
    }
}
