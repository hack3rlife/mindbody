using System;
using System.Globalization;
using OpenQA.Selenium.Support.UI;

namespace ParkingCalculatorAutomation
{
    public class DatePicker
    {
        public static void SetEntryDate(DateTime date)
        {
            var parentWin = Driver.Instance.CurrentWindowHandle;

            var calendar = DatePickerNavigation.EntryDateCalendar.Select();

            PopupWindowFinder finder = new PopupWindowFinder(Driver.Instance, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
            string popupWindowHandle = finder.Click(calendar);

            Driver.Instance.SwitchTo().Window(popupWindowHandle);

            DatePickerSelector.SelectYear(date.Year.ToString());
            DatePickerSelector.SelectMonth(date.ToString("MMMM", CultureInfo.InvariantCulture));
            DatePickerSelector.SelectDay(date.Day.ToString());
            Driver.Instance.SwitchTo().Window(parentWin);
        }

        public static void SeExitDate(DateTime date)
        {
            var parentWin = Driver.Instance.CurrentWindowHandle;

            var calendar = DatePickerNavigation.ExitDateCalendar.Select();

            PopupWindowFinder finder = new PopupWindowFinder(Driver.Instance, TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(10));
            string popupWindowHandle = finder.Click(calendar);

            Driver.Instance.SwitchTo().Window(popupWindowHandle);

            DatePickerSelector.SelectYear(date.Year.ToString());
            DatePickerSelector.SelectMonth(date.ToString("MMMM", CultureInfo.InvariantCulture));
            DatePickerSelector.SelectDay(date.Day.ToString());
            Driver.Instance.SwitchTo().Window(parentWin);
        }
    }
}
