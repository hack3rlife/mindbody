namespace ParkingCalculatorAutomation.Navigation
{
    public class ParkingPageNavigation
    {
        public class Submit
        {
            public static void Click()
            {
                Selector.SelectByName("Submit").Click();
            }
        }
    }
}
