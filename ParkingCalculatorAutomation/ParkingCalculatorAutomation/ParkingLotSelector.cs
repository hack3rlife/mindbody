using OpenQA.Selenium.Support.UI;

namespace ParkingCalculatorAutomation
{
    public static class ParkingLotSelector
    {
        public static void Select(string parkingType)
        {
            var dropDown = Selector.SelectById("Lot");
            var select = new SelectElement(dropDown);
            select.SelectByValue(parkingType);
        }
    }
}
