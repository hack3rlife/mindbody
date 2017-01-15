using System;
using OpenQA.Selenium;

namespace ParkingCalculatorAutomation
{
    public class ParkingPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress);
        }

        public static ParkingCommand Create()
        {
            return new ParkingCommand();
        }
    }

    public class ParkingCommand
    {
        private ParkingLotType lotType;
        private DateTime entryDate;
        private DateTime exitDate;
        private string entryDateAux;
        private string entryTimeAux;
        private string exitDateAux;
        private string exitTimeAux;
        private bool fromCalendar;

        public ParkingCommand()
        {
        }

        public ParkingCommand WithParkingLot(ParkingLotType lotType)
        {
            this.lotType = lotType;
            return this;
        }

        public ParkingCommand WithStartDateAndTime(string date, string time)
        {
            this.entryDateAux = date;
            this.entryTimeAux = time;
            return this;
        }

        public ParkingCommand WithStartDateAndTime(DateTime entry)
        {
            this.entryDate = entry;
            return this;
        }

        public ParkingCommand WithStartDateAndTimeFromCalendar(DateTime entry)
        {
            this.fromCalendar = true;
            this.entryDate = entry;
            return this;
        }

        public ParkingCommand WithEndDateAndTime(string date, string time)
        {
            this.exitDateAux = date;
            this.exitTimeAux = time;
            return this;
        }

        public ParkingCommand WithEndDateAndTime(DateTime exit)
        {
            this.exitDate = exit;
            return this;
        }

        public ParkingCommand WithEndDateAndTimeFromCalendar(DateTime exit)
        {
            this.fromCalendar = true;
            this.exitDate = exit;
            return this;
        }

        public void Calculate()
        {
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


            var entryTime = DateTimeNavigation.EntryTime.Select();
            entryTime.Clear();

            if (this.entryTimeAux != null)
            {
                entryTime.SendKeys(this.entryTimeAux);
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

            var entryDate = DateTimeNavigation.EntryDate.Select();
            entryDate.Clear();

            if (this.entryDateAux != null)
            {
                entryDate.SendKeys(this.entryDateAux);
            }
            else if (this.fromCalendar)
            {
                DatePicker.SetEntryDate(this.entryDate);
            }
            else
            {
                entryDate.SendKeys(this.entryDate.ToShortDateString());
            }

            var exitTime = DateTimeNavigation.ExitTime.Select();
            exitTime.Clear();

            if (this.exitTimeAux != null)
            {
                exitTime.SendKeys(this.exitTimeAux);
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

            var exitDate = DateTimeNavigation.ExitDate.Select();
            exitDate.Clear();

            if (exitDateAux != null)
            {
                exitDate.SendKeys(this.exitDateAux);
            }
            else if (fromCalendar)
            {
                DatePicker.SeExittDate(this.exitDate);
            }
            else
            {
                exitDate.SendKeys(this.exitDate.ToShortDateString());
            }


            var submit = Driver.Instance.FindElement(By.Name("Submit"));
            submit.Click();
        }
    }
}
