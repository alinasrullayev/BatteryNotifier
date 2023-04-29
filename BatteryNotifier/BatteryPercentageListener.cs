using System.Management;

namespace BatteryNotifier
{
    internal class BatteryPercentageListener : IBatteryPercentageListener
    {
        public event EventHandler<BatteryStatusChangedEventArgs>? BatteryUpperThresholdReached;
        public event EventHandler<BatteryStatusChangedEventArgs>? BatteryLowerThresholdReached;

        private System.Threading.Timer? timer;
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

        public List<BatteryInformation> GetAllBatteries()
        {
            ManagementClass wmi = new ManagementClass("Win32_Battery");

            List<BatteryInformation> batteries = new List<BatteryInformation>();

            foreach (ManagementObject battery in wmi.GetInstances())
            {
                string deviceID = (string)battery["DeviceID"];
                int estimatedChargeRemaining = Convert.ToInt32(battery["EstimatedChargeRemaining"]);
                string health = (string)battery["Status"];
                int estimatedRunTime = Convert.ToInt32(battery["EstimatedRunTime"]);
                int state = Convert.ToUInt16(battery["BatteryStatus"]);

                BatteryInformation batteryInformation = new BatteryInformation();

                batteryInformation.deviceID = deviceID;
                batteryInformation.percentage = estimatedChargeRemaining;
                batteryInformation.health = health;
                batteryInformation.expectedRunTime = estimatedRunTime;
                batteryInformation.state = (BatteryState)state;

                batteries.Add(batteryInformation);
            }

            return batteries;
        }

        private void CheckBatteryPercentage()
        {
            List<BatteryInformation> allBatteries = GetAllBatteries();

            foreach (BatteryInformation battery in allBatteries)
            {
                Console.WriteLine(battery.state);

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

    internal class BatteryStatusChangedEventArgs : EventArgs
    {
        public BatteryInformation? batteryInformation;
    }
}
