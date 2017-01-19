using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    [TestClass]
    [DeploymentItem("chromedriver.exe")]
    [DeploymentItem("IEDriverServer.exe")]
    public class ParkingCalculatorTest
    {
        public TestContext TestContext { get; set; }

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
            var fileName = string.Format(@"{0}\{1}", Environment.CurrentDirectory, testname);

            Driver.TakeScreenShot(fileName);

            TestContext.AddResultFile(fileName);

        }      
    }
}
