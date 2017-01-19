using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    [TestClass]
    [DeploymentItem("chromedriver.exe")]
    [DeploymentItem("IEDriverServer.exe")]
    public class ParkingCalculatorTest
    {
        [TestInitialize]
        public void Initilize()
        {
            // TODO: Get BrowserType value from a config file
            Driver.Initialize(BrowserType.Chrome);
        }

        [TestCleanup]
        public void CleanUp()
        {
            Driver.Instance.Close();
            Driver.Instance.Dispose();
        }

        public void TakeScreenShot(string testname)
        {
            var screenShoot = ((ITakesScreenshot)Driver.Instance).GetScreenshot();
            var filename = string.Format(@"{0}\{1}", Environment.CurrentDirectory, testname);
            screenShoot.SaveAsFile(filename, ImageFormat.Jpeg);
        }
    }
}
