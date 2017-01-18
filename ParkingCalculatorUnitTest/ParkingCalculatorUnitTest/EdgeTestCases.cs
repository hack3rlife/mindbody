using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    [TestClass]
    public class EdgeTestCases : ParkingCalculatorTest
    {
        [TestInitialize]        
        public void Initialize()
        {
            ParkingPage.GoTo();
        }

        [TestMethod]
        [TestCategory("EdgeCases")]
        public void ParkingCalculator_When_IsLeapYear_YearScenario()
        {
            ParkingPage.Create()
                .WithParkingLot(ParkingLotType.STP)
                .WithStartDateAndTime(new DateTime(2015, 12, 31, 0, 0, 0))
                .WithEndDateAndTime(new DateTime(2017, 1, 1, 0, 0, 0))
                .Calculate();

            Assert.AreEqual("$ 9,544.00", ParkingPage.Total, "The cost is different");
            Assert.AreEqual("        (367 Days, 0 Hours, 0 Minutes)", ParkingPage.Description, "Datetime is incorrect");
        }

        [TestMethod]
        [TestCategory("EdgeCases")]
        public void ParkingCalculator_When_IsLeapYear_MonthScenario()
        {
            ParkingPage.Create()
               .WithParkingLot(ParkingLotType.STP)
               .WithStartDateAndTime(new DateTime(2016, 2, 1, 0, 0, 0))
               .WithEndDateAndTime(new DateTime(2016, 3, 1, 0, 0, 0))
               .Calculate();

            Assert.AreEqual("$ 756.00", ParkingPage.Total, "The cost is different");
            Assert.AreEqual("        (29 Days, 0 Hours, 0 Minutes)", ParkingPage.Description, "Datetime is incorrect");
        }

        [TestMethod]
        [TestCategory("EdgeCases")]
        public void ParkingCalculator_When_DayLightSavingTime()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.LTS)
              .WithStartDateAndTime(new DateTime(2016, 3, 12, 21, 30, 0))
              .WithEndDateAndTime(new DateTime(2016, 3, 13, 23, 15, 0))
              .Calculate();

            Assert.AreEqual("$ 12.00", ParkingPage.Total, "The cost is different");
            Assert.AreEqual("        (1 Days, 0 Hours, 45 Minutes)", ParkingPage.Description, "Datetime is incorrect");
        }

        [TestMethod]
        [TestCategory("EdgeCases")]
        public void ParkingCalculator_When_FractionTime_IsLowerBound()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime(DateTime.Now)
              .WithEndDateAndTime(DateTime.Now.AddHours(1).AddMinutes(1))
              .Calculate();

            Assert.AreEqual("$ 3.00", ParkingPage.Total, "The cost is different");
            Assert.AreEqual("        (0 Days, 1 Hours, 1 Minutes)", ParkingPage.Description, "Datetime is incorrect");
        }

        [TestMethod]
        [TestCategory("EdgeCases")]
        public void ParkingCalculator_When_FractionTime_IsUpperBound()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime(DateTime.Now)
              .WithEndDateAndTime(DateTime.Now.AddHours(1).AddMinutes(31))
              .Calculate();

            Assert.AreEqual("$ 4.00", ParkingPage.Total, "The cost is different");
            Assert.AreEqual("        (0 Days, 1 Hours, 31 Minutes)", ParkingPage.Description, "Datetime is incorrect");
        }
    }
}
