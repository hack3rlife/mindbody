using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    [TestClass]
    public class DataDrivenTesttCases : ParkingCalculatorTest
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

            // assert
            Assert.AreEqual(expectedCost, ParkingPageCost.Total, "The cost is different");
            Assert.AreEqual(expectedDuration, ParkingPageCost.Description, "Datetime is incorrect");
        }
        
    }
}
