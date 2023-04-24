namespace BatteryNotifier
{
    internal class BatteryInformation
    {   
        internal string? deviceID { get; set; }
        internal int percentage { get; set; }
        internal string? health { get; set; }
        internal int expectedRunTime { get; set; }
    }
}
