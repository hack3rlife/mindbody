using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace ParkingCalculatorAutomation
{
    /// <summary>
    /// Encapsulates IWebDriver instance.
    /// </summary>
    public class Driver
    {
        /// <summary>
        /// Singleton instance
        /// </summary>
        public static IWebDriver Instance { get; set; }

        /// <summary>
        /// Url Base Address
        /// </summary>
        public static string BaseAddress
        {
            get
            {
                // TODO: Get this value from a config file
                return "http://adam.goucher.ca/parkcalc/index.php";
            }
        }

        /// <summary>
        /// Initializes a new <see cref="IWebDriver"/> 
        /// </summary>
        /// <param name="browser">The <see cref="BrowserType"/></param>
        public static void Initialize(BrowserType browser)
        {
            switch (browser)
            {
                case BrowserType.Chrome:
                    Instance = new ChromeDriver();
                    break;
                case BrowserType.InternetExplorer:
                    Instance = new InternetExplorerDriver(Environment.CurrentDirectory + "\\Selenium\\");  // TODO: Get path from a config file
                    break;
                case BrowserType.Firefox:
                    throw new NotImplementedException(nameof(browser));
                    //Instance = new FirefoxDriver();
                    //break;
                default:
                    Instance = new ChromeDriver();
                    break;
            }

            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        }
    }
}
