using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    public static class InputParserHelper
    {
        public static ParkingLotType GetParkingLotType(string type)
        {
            switch (type)
            {
                case "EP":
                    return ParkingLotType.EP;
                case "LTG":
                    return ParkingLotType.LTG;
                case "LTS":
                    return ParkingLotType.LTS;
                case "STP":
                    return ParkingLotType.STP;
                case "VP":
                    return ParkingLotType.VP;
                default:
                    throw new InvalidCastException(nameof(type));
            }
        }

        public static DateTime GetDate(string date)
        {
            DateTime dt;

            if (DateTime.TryParse(date, out dt))
                return dt;

            throw new InvalidOperationException(nameof(date));
        }
    }
}
