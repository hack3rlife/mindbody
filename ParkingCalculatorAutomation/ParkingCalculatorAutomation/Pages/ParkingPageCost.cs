using OpenQA.Selenium;

namespace ParkingCalculatorAutomation
{
    public class ParkingPageCost
    {
        public static string Total
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("span.SubHead > font > b")).Text;
            }
        }

        public static string Description
        {
            get
            {
                return Driver.Instance.FindElement(By.CssSelector("span.BodyCopy > font > b")).Text;
            }
        }
    }
}
