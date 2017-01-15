using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    [TestClass]
    public class MindbodyTestCases : ParkingCalculatorTest
    {
        [TestInitialize]
        public void Initialize()
        {
            ParkingPage.GoTo();
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        public void TestCase1()
        {
            ParkingPage.Create()
                .WithParkingLot(ParkingLotType.STP)
                .WithStartDateAndTime(new DateTime(2014, 1, 1, 22, 0, 0 ))
                .WithEndDateAndTime(new DateTime(2014, 1, 1, 23, 0, 0))
                .Calculate();

            Assert.AreEqual("$ 2.00", ParkingPageCost.Total, "The cost is different");
            Assert.AreEqual("        (0 Days, 1 Hours, 0 Minutes)", ParkingPageCost.Description, "Datetime is incorrect");

        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        public void TestCase2()
        {
            ParkingPage.Create()
                .WithParkingLot(ParkingLotType.LTS)
                 .WithStartDateAndTime(new DateTime(2014, 1, 1, 0, 0, 0))
                .WithEndDateAndTime(new DateTime(2014, 2, 1, 0, 0, 0))
                .Calculate();

            Assert.AreEqual("$ 270.00", ParkingPageCost.Total, "The cost is different");
            Assert.AreEqual("        (31 Days, 0 Hours, 0 Minutes)", ParkingPageCost.Description, "Datetime is incorrect");
        }

        [TestMethod]
        [TestCategory("SmokeTest")]
        public void TestCase3()
        {
            ParkingPage.Create()
                .WithParkingLot(ParkingLotType.STP)
                 .WithStartDateAndTime(new DateTime(2014, 2, 1, 0, 0, 0))
                .WithEndDateAndTime(new DateTime(2014, 1, 1, 0, 0, 0))
                .Calculate();

            Assert.AreEqual("ERROR! YOUR EXIT DATE OR TIME IS BEFORE YOUR ENTRY DATE OR TIME", ParkingPageCost.Total, "The expect cost is different");
        }
    }
}
