using System.Management;

namespace BatteryNotifier
{
    public interface IBatteryPercentageListener : IBatteryEventListener
    {
        event EventHandler<BatteryStatusChangedEventArgs>? BatteryLowerThresholdReached;
        event EventHandler<BatteryStatusChangedEventArgs>? BatteryUpperThresholdReached;
    }
}