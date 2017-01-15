namespace ParkingCalculatorAutomation
{
    public class ParkingLotNavigation
    {
        public class ShortTermParking
        {
            public static void Select()
            {
                ParkingLotSelector.Select("STP");
            }
        }

        public class EconomicParking
        {
            public static void Select()
            {
                ParkingLotSelector.Select("EP");
            }
        }

        public class LongTermSurfaceParking
        {
            public static void Select()
            {
                ParkingLotSelector.Select("LTS");
            }
        }

        public class LongTermGarageParking
        {
            public static void Select()
            {
                ParkingLotSelector.Select("LTG");
            }
        }

        public class VAletParking
        {
            public static void Select()
            {
                ParkingLotSelector.Select("VP");
            }
        }
    }
}
