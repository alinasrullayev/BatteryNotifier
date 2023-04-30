namespace BatteryNotifier
{
    public class BatteryInformation
    {
        public string? deviceID { get; set; }

        public int percentage { get; set; }

        public string? health { get; set; }

        public int expectedRunTime { get; set; }

        public BatteryState? state { get; set; }
    }

    public enum BatteryState
    {
        Other = 1,
        Unknown = 2,
        Fully_Charged = 3,
        Low = 4,
        Critical = 5,
        Charging = 6,
        Charging_and_High = 7,
        Charging_and_Low = 8,
        Charging_and_Critical = 9,
        Undefined = 10,
        Partially_Charged = 11

    }
}
