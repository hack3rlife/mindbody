using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
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
        [ExpectedException(typeof(Exception))]
        public void InvalidTime_TimeIsEmpty()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("01/15/2017", "")
              .WithEndDateAndTime("01/15/2017", "02:00")
              .Calculate();
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [ExpectedException(typeof(Exception))]
        public void InvalidTime_NegativeTime()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("01/15/2017", "-01:00")
              .WithEndDateAndTime("01/15/2017", "-02:00")
              .Calculate();            
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [ExpectedException(typeof(Exception))]
        public void InvalidTime_NonExistingTime()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("01/15/2017", "25:00")
              .WithEndDateAndTime("01/15/2017", "26:00")
              .Calculate();
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [ExpectedException(typeof(Exception))]
        public void InvalidTime_NonNumericVlues()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("01/15/2017", "aa:bb")
              .WithEndDateAndTime("01/15/2017", "cc:dd")
              .Calculate();
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [ExpectedException(typeof(Exception))]
        public void InvalidDate_DateIsEmpty()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("", "01:00")
              .WithEndDateAndTime("01/15/2017", "02:00")
              .Calculate();
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [ExpectedException(typeof(Exception))]
        public void InvalidDate_NonExistingDate()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("15/15/2017", "01:00")
              .WithEndDateAndTime("15/15/2017", "02:00")
              .Calculate();                    
        }

        [TestMethod]
        [TestCategory("InvalidInput")]
        [ExpectedException(typeof(Exception))]
        public void InvalidDate_NonNumericValues()
        {
            ParkingPage.Create()
              .WithParkingLot(ParkingLotType.STP)
              .WithStartDateAndTime("aa/15/2017", "01:00")
              .WithEndDateAndTime("1/bb/2017", "02:00")
              .Calculate();
        }
    }
}
