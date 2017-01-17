using OpenQA.Selenium;
using ParkingCalculatorAutomation.Navigation;

namespace ParkingCalculatorAutomation
{
    public class ParkingPageCost
    {
        public static string Total
        {
            get
            {
                return ParkingCostNavigation.Total.Select();
            }
        }

        public static string Description
        {
            get
            {
                return ParkingCostNavigation.Description.Select();
            }
        }
    }
}
