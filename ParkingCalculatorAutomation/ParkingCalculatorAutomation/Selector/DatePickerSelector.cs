using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ParkingCalculatorAutomation
{
    internal class DatePickerSelector
    {
        internal static void SelectYear(string year)
        {
            var yr = int.Parse(year);
            int curr = DateTime.Now.Year;

            do
            {
                curr = int.Parse(GetCurrentYear());

                if (curr < yr)
                    NextYear();
                else if (curr > yr)
                    PreviousYear();
            } while (curr != yr);

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

        private static string GetCurrentYear()
        {
            return Driver.Instance.FindElement(By.CssSelector("td > font > b")).Text;
        }

        private static void PreviousYear()
        {
            Selector.SelectByLinkText("<").Click();
        }

        private static void NextYear()
        {
            Selector.SelectByLinkText(">").Click();
        }
    }
}
