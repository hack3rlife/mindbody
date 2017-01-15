using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace ParkingCalculatorAutomation
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseAddress
        {
            get
            {
                // TODO: Get this value from a config file
                return "http://adam.goucher.ca/parkcalc/index.php";
            }
        }

        public static void Initialize(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    Instance = new ChromeDriver();
                    break;
                case BrowserType.InternetExplorer:
                    Instance = new InternetExplorerDriver();
                    break;
                case BrowserType.Firefox:
                    Instance = new FirefoxDriver();
                    break;
                default:
                    Instance = new ChromeDriver();
                    break;
            }

            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
    }
}
