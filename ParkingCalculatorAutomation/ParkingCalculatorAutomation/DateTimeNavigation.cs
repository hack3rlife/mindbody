using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ParkingCalculatorAutomation
{
    public class DateTimeNavigation
    {
        public class EntryTime
        {
            public static IWebElement Select()
            {
                return DateTimeSelector.SelectById("EntryTime");
            }
        }

        public class EntryDate
        {
            public static IWebElement Select()
            {
                return DateTimeSelector.SelectById("EntryDate");
            }
        }

        public class EntryTimeAMPM
        {
            public static ReadOnlyCollection<IWebElement> Select()
            {
                return DateTimeSelector.SelectByName("EntryTimeAMPM");
            }
        }

        public class EntryDateCalendar
        {
            public static IWebElement Select()
            {
                return DateTimeSelector.SelectByXPath(@"//img[@alt='Pick a date'])[1]");
            }
        }

        public class ExitTime
        {
            public static IWebElement Select()
            {
                return DateTimeSelector.SelectById("ExitTime");
            }
        }

        public class ExitDate
        {
            public static IWebElement Select()
            {
                return DateTimeSelector.SelectById("ExitDate");
            }
        }

        public class ExitTimeAMPM
        {
            public static ReadOnlyCollection<IWebElement> Select()
            {
                return DateTimeSelector.SelectByName("ExitTimeAMPM");
            }
        }

        public class ExitDateCalendar
        {
            public static IWebElement Select()
            {
                return DateTimeSelector.SelectByXPath(@"//img[@alt='Pick a date'])[2]");
            }
        }
    }
}
