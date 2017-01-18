using System;
using ParkingCalculatorAutomation;

namespace ParkingCalculatorUnitTest
{
    public static class InputParserHelper
    {
        public static ParkingLotType GetParkingLotType(string type)
        {
            switch (type.ToUpperInvariant())
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
                    throw new ArgumentException(nameof(type));
            }
        }

        public static DateTime GetDate(string date)
        {
            DateTime dt;

            if (DateTime.TryParse(date, out dt))
                return dt;

            throw new ArgumentException(nameof(date));
        }
    }
}
