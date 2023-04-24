using System.Management;

namespace BatteryNotifier
{
    internal interface IBatteryPercentageListener : IBatteryEventListener
    {
        event EventHandler<BatteryStatusChangedEventArgs>? BatteryLowerThresholdReached;
        event EventHandler<BatteryStatusChangedEventArgs>? BatteryUpperThresholdReached;
    }
}