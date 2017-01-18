using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
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
    }
}
