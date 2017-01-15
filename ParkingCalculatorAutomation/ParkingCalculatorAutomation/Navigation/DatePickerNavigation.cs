using OpenQA.Selenium;

namespace ParkingCalculatorAutomation
{
    public class DatePickerNavigation
    {
        public class EntryDateCalendar
        {
            public static IWebElement Select()
            {
                return DateTimeSelector.SelectByXPath(@"(//img[@alt='Pick a date'])[1]");
            }
        }

        public class ExitDateCalendar
        {
            public static IWebElement Select()
            {
                return DateTimeSelector.SelectByXPath(@"(//img[@alt='Pick a date'])[2]");
            }
        }
    }
}
