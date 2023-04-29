namespace BatteryNotifier
{
    internal class BatteryInformation
    {
        internal string? deviceID { get; set; }

        internal int percentage { get; set; }

        internal string? health { get; set; }

        internal int expectedRunTime { get; set; }

        internal BatteryState? state { get; set; }
    }

    internal enum BatteryState
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
