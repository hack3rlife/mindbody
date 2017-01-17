using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    public class ParkingCalculatorTest
    {
        const string baseUrl = "http://adam.goucher.ca/parkcalc/index.php";

        [TestInitialize]
        public void Initilize()
        {
            // TODO: Get this value from a config file
            Driver.Initialize(BrowserType.Chrome);
        }

        [TestCleanup]
        [TestCategory("PositiveTests")]
        public void CleanUp()
        {
            Driver.Instance.Close();
            Driver.Instance.Dispose();
        }
    }
}
