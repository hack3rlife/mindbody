using System;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
                    var options = new ChromeOptions();
                    options.AddArgument("no-sandbox");
                    Instance = new ChromeDriver(options);
                    break;
                case BrowserType.InternetExplorer:
                    Instance = new InternetExplorerDriver();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        public static void TakeScreenShot(string filename)
        {
            var screenShoot = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
            screenShoot.SaveAsFile(filename, ImageFormat.Jpeg);
        }
    }
}
