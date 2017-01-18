using System;
using OpenQA.Selenium;
using ParkingCalculatorAutomation.Navigation;
using ParkingCalculatorAutomation.Workflow;

namespace ParkingCalculatorAutomation
{
    /// <summary>
    /// POM class for Parking Calculator index web page
    /// </summary>
    public class ParkingPage
    {
        /// <summary>
        /// Gets the cost test
        /// </summary>
        public static string Total
        {
            get
            {
                return ParkingCostNavigation.Total.Select();
            }
        }

        /// <summary>
        /// Gets cost description (duration)
        /// </summary>
        public static string Description
        {
            get
            {
                return ParkingCostNavigation.Description.Select();
            }
        }

        /// <summary>
        /// Navigates to http://adam.goucher.ca/parkcalc/index.php
        /// </summary>
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
        }

        /// <summary>
        /// Creates a new <see cref="ParkingCommand"/> class.
        /// </summary>
        /// <returns><see cref="ParkingCommand"/></returns>
        public static ParkingCommand Create()
        {
            return new ParkingCommand();
        }
    }

    public class ParkingCommand
    {
        /// <summary>
        /// Parking Lot Type
        /// </summary>
        private ParkingLotType lotType;

        /// <summary>
        /// Entry date 
        /// </summary>
        private DateTime entryDate;

        /// <summary>
        /// Exit date 
        /// </summary>
        private DateTime exitDate;

        /// <summary>
        /// Entry Date coming from DatePicker
        /// </summary>
        private string entryDatePicker;

        /// <summary>
        /// Entry Time
        /// </summary>
        private string entryTime;

        /// <summary>
        /// Exit Date coming from DatePicker
        /// </summary>
        private string exitDatePicker;

        /// <summary>
        /// Exit Time
        /// </summary>
        private string exitTime;

        /// <summary>
        /// Indicates if the date should be taken from the DatePicker calendar or not.
        /// </summary>
        private bool fromCalendar;

        /// <summary>
        /// Instantiates a new <see cref="ParkingCommand"/>
        /// </summary>
        public ParkingCommand()
        {
        }

        /// <summary>
        /// Sets the <see cref="ParkingLotType"/>
        /// </summary>
        /// <param name="lotType"></param>
        /// <returns><see cref="ParkingCommand"/></returns>
        public ParkingCommand WithParkingLot(ParkingLotType lotType)
        {
            this.lotType = lotType;
            return this;
        }

        /// <summary>
        /// Sets the entry date and time
        /// </summary>
        /// <param name="date">Entry date. Format should be "MM/DD/YYYY</param>
        /// <param name="time">Entry time. Format should be hh:mm:ss</param>
        /// <returns><see cref="ParkingCommand"/></returns>
        public ParkingCommand WithStartDateAndTime(string date, string time)
        {
            this.entryDatePicker = date;
            this.entryTime = time;
            return this;
        }

        /// <summary>
        /// Sets the entry DateTime
        /// </summary>
        /// <param name="start">Entry Date. Should provide date and time.</param>
        /// <returns><see cref="ParkingCommand"/></returns>
        public ParkingCommand WithStartDateAndTime(DateTime start)
        {
            this.entryDate = start;
            return this;
        }

        /// <summary>
        /// Sets the entry DateTime from DatePicker calendar.
        /// </summary>
        /// <param name="start">The entry DateTime</param>
        /// <returns><see cref="ParkingCommand"/></returns>
        public ParkingCommand WithStartDateAndTimeFromCalendar(DateTime start)
        {
            this.fromCalendar = true;
            this.entryDate = start;
            return this;
        }

        /// <summary>
        /// Sets the exit date and time
        /// </summary>
        /// <param name="date">Exit date. Format should be "MM/DD/YYYY</param>
        /// <param name="time">Exit time. Format should be hh:mm:ss</param>
        /// <returns><see cref="ParkingCommand"/></returns>
        public ParkingCommand WithEndDateAndTime(string date, string time)
        {
            this.exitDatePicker = date;
            this.exitTime = time;
            return this;
        }

        /// <summary>
        /// Sets the exit DateTime
        /// </summary>
        /// <param name="exit">Entry Date. Should provide date and time.</param>
        /// <returns><see cref="ParkingCommand"/></returns>
        public ParkingCommand WithEndDateAndTime(DateTime exit)
        {
            this.exitDate = exit;
            return this;
        }

        /// <summary>
        /// Sets the exit DateTime from DatePicker calendar.
        /// </summary>
        /// <param name="exit">The entry DateTime</param>
        /// <returns><see cref="ParkingCommand"/></returns>
        public ParkingCommand WithEndDateAndTimeFromCalendar(DateTime exit)
        {
            this.fromCalendar = true;
            this.exitDate = exit;
            return this;
        }

        /// <summary>
        /// Calculates the cost and duration based on <see cref="ParkingCommand"/> instance values.
        /// </summary>        
        public void Calculate()
        {            
            // 1. Select Parking Lot Type from dropdown
            switch (this.lotType)
            {
                case ParkingLotType.STP:
                    ParkingLotNavigation.ShortTermParking.Select();
                    break;
                case ParkingLotType.EP:
                    ParkingLotNavigation.EconomicParking.Select();
                    break;
                case ParkingLotType.LTS:
                    ParkingLotNavigation.LongTermSurfaceParking.Select();
                    break;
                case ParkingLotType.LTG:
                    ParkingLotNavigation.LongTermGarageParking.Select();
                    break;
                case ParkingLotType.VP:
                    ParkingLotNavigation.VAletParking.Select();
                    break;
                default:
                    break;
            }

            // 2. Select entry time
            var entryTime = DateTimeNavigation.EntryTime.Select();
            entryTime.Clear();

            if (this.entryTime != null)
            {
                entryTime.SendKeys(this.entryTime);
            }
            else
            {
                var entryAmPm = DateTimeNavigation.EntryTimeAMPM.Select();

                if (this.entryDate.ToShortTimeString().Contains("AM"))
                {
                    entryTime.SendKeys(string.Format("{0}:{1}", this.entryDate.Hour, this.entryDate.Minute));
                    entryAmPm[0].Click();
                }
                else
                {
                    entryTime.SendKeys(string.Format("{0}:{1}", this.entryDate.Hour - 12, this.entryDate.Minute));
                    entryAmPm[1].Click();
                }
            }

            // 3. Select entry date
            var entryDate = DateTimeNavigation.EntryDate.Select();
            entryDate.Clear();

            if (this.entryDatePicker != null)
            {
                entryDate.SendKeys(this.entryDatePicker);
            }
            else if (this.fromCalendar)
            {
                DatePicker.SetEntryDate(this.entryDate);
            }
            else
            {
                entryDate.SendKeys(this.entryDate.ToShortDateString());
            }

            // 4. Select exit time
            var exitTime = DateTimeNavigation.ExitTime.Select();
            exitTime.Clear();

            if (this.exitTime != null)
            {
                exitTime.SendKeys(this.exitTime);
            }
            else
            {

                var exitAmPm = DateTimeNavigation.ExitTimeAMPM.Select();

                if (this.exitDate.ToShortTimeString().Contains("AM"))
                {
                    exitTime.SendKeys(string.Format("{0}:{1}", this.exitDate.Hour, this.exitDate.Minute));
                    exitAmPm[0].Click();
                }
                else
                {
                    exitTime.SendKeys(string.Format("{0}:{1}", this.exitDate.Hour - 12, this.exitDate.Minute));
                    exitAmPm[1].Click();
                }
            }

            // 5. Select exit date
            var exitDate = DateTimeNavigation.ExitDate.Select();
            exitDate.Clear();

            if (exitDatePicker != null)
            {
                exitDate.SendKeys(this.exitDatePicker);
            }
            else if (fromCalendar)
            {
                DatePicker.SeExitDate(this.exitDate);
            }
            else
            {
                exitDate.SendKeys(this.exitDate.ToShortDateString());
            }

            // Get cost and duration
            ParkingPageNavigation.Submit.Click();
        }
    }
}
