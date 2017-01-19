using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    [TestClass]
    [DeploymentItem("data\\input_values.csv")]
    public class DataDrivenTestCases : ParkingCalculatorTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            ParkingPage.GoTo();
        }

        [TestMethod()]
        [TestCategory("SmokeTest")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\data\\input_values.csv", "input_values#csv", DataAccessMethod.Sequential)]
        public void ParkingCalculator_Default_TestCases_NoError()
        {
           // arrange
           var lot = InputParserHelper.GetParkingLotType(TestContext.DataRow[0].ToString());
            var entryTime = InputParserHelper.GetDate(TestContext.DataRow[1].ToString());
            var exitTime = InputParserHelper.GetDate(TestContext.DataRow[2].ToString());
            var expectedCost = TestContext.DataRow[3];
            var expectedDuration = TestContext.DataRow[4];

            // act
            ParkingPage.Create()
                .WithParkingLot(lot)
                .WithStartDateAndTime(entryTime)
                .WithEndDateAndTime(exitTime)
                .Calculate();

            this.TakeScreenShot(this.TestContext.TestName + DateTime.Now.Ticks);

            // assert
            Assert.AreEqual(expectedCost, ParkingPage.Total, "The cost is different");
            Assert.AreEqual(expectedDuration, ParkingPage.Description, "Datetime is incorrect");
        }
        
    }
}
