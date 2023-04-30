using System.Management;

namespace BatteryNotifier
{
    public class BatteryPercentageListener : IBatteryPercentageListener
    {
        public event EventHandler<BatteryStatusChangedEventArgs>? BatteryUpperThresholdReached;
        public event EventHandler<BatteryStatusChangedEventArgs>? BatteryLowerThresholdReached;

        private System.Threading.Timer? timer;
        private IBatteryRepository repository;

        public BatteryPercentageListener(IBatteryRepository repository)
        {
            this.repository = repository;
        }

        private Int32 batteryUpperThreshold = Properties.Settings.Default.BATTERY_UPPER_THRESHOLD;
        private Int32 batteryLowerThreshold = Properties.Settings.Default.BATTERY_LOWER_THRESHOLD;

        public void StartListening(int poolIntervalSeconds)
        {
            TimeSpan startTimeSpan = TimeSpan.Zero;
            TimeSpan periodTimeSpan = TimeSpan.FromSeconds(poolIntervalSeconds);

            timer = new System.Threading.Timer((e) =>
            {
                CheckBatteryPercentage();
            }, null, startTimeSpan, periodTimeSpan);
        }

        private void CheckBatteryPercentage()
        {
            List<BatteryInformation> allBatteries = repository.GetAll();

            foreach (BatteryInformation battery in allBatteries)
            {
                if (
                    battery.percentage >= batteryUpperThreshold &&
                        (
                            battery.state == BatteryState.Unknown ||
                            battery.state == BatteryState.Charging ||
                            battery.state == BatteryState.Charging_and_Low ||
                            battery.state == BatteryState.Charging_and_High ||
                            battery.state == BatteryState.Charging_and_Critical ||
                            battery.state == BatteryState.Partially_Charged ||
                            battery.state == BatteryState.Fully_Charged
                        )
                    )
                {
                    BatteryUpperThresholdReached?.Invoke(this, new BatteryStatusChangedEventArgs
                    {
                        batteryInformation = battery
                    });
                }

                if (
                    battery.percentage <= batteryLowerThreshold &&
                        (
                            battery.state == BatteryState.Other ||
                            battery.state == BatteryState.Low ||
                            battery.state == BatteryState.Critical
                        )
                    )
                {
                    BatteryLowerThresholdReached?.Invoke(this, new BatteryStatusChangedEventArgs
                    {
                        batteryInformation = battery
                    });
                }
            }
        }
    }
}
