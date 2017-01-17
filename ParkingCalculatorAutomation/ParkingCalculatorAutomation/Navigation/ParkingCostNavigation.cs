using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingCalculatorAutomation.Navigation
{
    public class ParkingCostNavigation
    {
        public class Total
        {
            public static string Select()
            {
                return Selector.SelectByCss("span.SubHead > font > b").Text;
            }
        }

        public class Description
        {
            public static string Select()
            {
                return Selector.SelectByCss("span.BodyCopy > font > b").Text;
            }
        }
    }
}
