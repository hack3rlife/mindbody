using OpenQA.Selenium.Support.UI;

namespace ParkingCalculatorAutomation
{
    internal static class ParkingLotSelector
    {
        internal static void Select(string parkingType)
        {
            var dropDown = Selector.SelectById("Lot");
            var select = new SelectElement(dropDown);
            select.SelectByValue(parkingType);
        }
    }
}
