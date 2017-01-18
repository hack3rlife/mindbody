using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    /// <summary>
    /// All this test cases are failing and will be ignored during test time. 
    /// The idea is just to show possible test scenario.
    /// </summary>
    [TestClass]
    public class InvalidInputTestCases : ParkingCalculatorTest
    {
        [TestInitialize]
        public void Initialize()
        {
            ParkingPage.GoTo();
        }
        
        [TestMethod]
        [TestCategory("InvalidInput")]
        [Ignore]
        public void InvalidTime_TimeIsEmpty()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("01/15/2017", "")
              .WithEndDateAndTime("01/15/2017", "02:00")
              .Calculate();
            
            // Possible expected verification.
            // Assert.AreEqual(ParkingPage.TimeIsEmptyError, "Entry Time can't be empty")
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [Ignore]
        public void InvalidTime_NegativeTime()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("01/15/2017", "-01:00")
              .WithEndDateAndTime("01/15/2017", "02:00")
              .Calculate();

            // Possible expected verification.
            // Assert.AreEqual(ParkingPage.InvlidEntryTime, "Entry Time is invalid")    
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [Ignore]
        public void InvalidTime_NonExistingTime()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("01/15/2017", "25:00")
              .WithEndDateAndTime("01/15/2017", "23:00")
              .Calculate();

            // Possible expected verification.
            // Assert.AreEqual(ParkingPage.InvlidEntryTime, "Entry Time is invalid")
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [Ignore]
        public void InvalidTime_NonNumericVlues()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("01/15/2017", "01:00")
              .WithEndDateAndTime("01/15/2017", "cc:dd")
              .Calculate();

            // Possible expected verification.
            // Assert.AreEqual(ParkingPage.InvlidExitTime, "Exit Time is invalid")
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [Ignore]
        public void InvalidDate_DateIsEmpty()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("", "01:00")
              .WithEndDateAndTime("01/15/2017", "02:00")
              .Calculate();

            // Possible expected verification.
            // Assert.AreEqual(ParkingPage.InvlidEntryDate, "Entry Date can't be empty")
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [Ignore]
        public void InvalidDate_NonExistingDate()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("11/15/2017", "01:00")
              .WithEndDateAndTime("15/15/2017", "02:00")
              .Calculate();

            // Possible expected verification.
            // Assert.AreEqual(ParkingPage.InvlidExitDate, "Exit Date is invalid")                
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [Ignore]
        public void InvalidDate_NonNumericValues()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("01/15/2017", "01:00")
              .WithEndDateAndTime("1/bb/2017", "02:00")
              .Calculate();

            // Possible expected verification.
            // Assert.AreEqual(ParkingPage.InvlidExitDate, "Exit Date is invalid")   
        }
    }
}
