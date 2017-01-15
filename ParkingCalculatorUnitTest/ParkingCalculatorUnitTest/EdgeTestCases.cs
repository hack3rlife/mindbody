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
        public void Morethanayear()
        {
            ParkingPage.Create()
                .WithParkingLot(ParkingLotType.STP)
                .WithStartDateAndTime(new DateTime(2015, 12, 31, 0, 0, 0))
                .WithEndDateAndTime(new DateTime(2017, 1, 1, 0, 0, 0))
                .Calculate();

            Assert.AreEqual("$ 9,544.00", ParkingPageCost.Total, "The cost is different");
            Assert.AreEqual("        (367 Days, 0 Hours, 0 Minutes)", ParkingPageCost.Description, "Datetime is incorrect");
        }

        [TestMethod]
        [TestCategory("EdgeCases")]
        public void Morethanamonth()
        {
            ParkingPage.Create()
               .WithParkingLot(ParkingLotType.STP)
               .WithStartDateAndTime(new DateTime(2016, 2, 1, 0, 0, 0))
               .WithEndDateAndTime(new DateTime(2016, 3, 1, 0, 0, 0))
               .Calculate();

            Assert.AreEqual("$ 756.00", ParkingPageCost.Total, "The cost is different");
            Assert.AreEqual("        (29 Days, 0 Hours, 0 Minutes)", ParkingPageCost.Description, "Datetime is incorrect");
        }

        [TestMethod]
        [TestCategory("EdgeCases")]
        public void Morethanaday()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime(new DateTime(2016, 3, 12, 21, 30, 0))
              .WithEndDateAndTime(new DateTime(2016, 3, 13, 23, 15, 0))
              .Calculate();

            Assert.AreEqual("$ 28.00", ParkingPageCost.Total, "The cost is different");
            Assert.AreEqual("        (1 Days, 0 Hours, 45 Minutes)", ParkingPageCost.Description, "Datetime is incorrect");
        }

        [TestMethod]
        [TestCategory("EdgeCases")]
        public void Morethananhour()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime(DateTime.Now)
              .WithEndDateAndTime(DateTime.Now.AddHours(1).AddMinutes(1))
              .Calculate();

            Assert.AreEqual("$ 3.00", ParkingPageCost.Total, "The cost is different");
            Assert.AreEqual("        (0 Days, 1 Hours, 1 Minutes)", ParkingPageCost.Description, "Datetime is incorrect");
        }

        [TestMethod]
        [TestCategory("EdgeCases")]
        public void Hourandahalf()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime(DateTime.Now)
              .WithEndDateAndTime(DateTime.Now.AddHours(1).AddMinutes(31))
              .Calculate();

            Assert.AreEqual("$ 4.00", ParkingPageCost.Total, "The cost is different");
            Assert.AreEqual("        (0 Days, 1 Hours, 31 Minutes)", ParkingPageCost.Description, "Datetime is incorrect");
        }
    }
}
