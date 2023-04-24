using System.Management;

namespace BatteryNotifier
{
    internal class BatteryPercentageListener : IBatteryPercentageListener
    {
        private const Int32 BATTERY_PERCENTAGE_LOWER_THRESHOLD = 20;
        private const Int32 BATTERY_PERCENTAGE_UPPER_THRESHOLD = 80;

        public event EventHandler<BatteryStatusChangedEventArgs>? BatteryUpperThresholdReached;
        public event EventHandler<BatteryStatusChangedEventArgs>? BatteryLowerThresholdReached;

        private System.Threading.Timer? timer;

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

                BatteryInformation batteryInformation = new BatteryInformation();

                batteryInformation.deviceID = deviceID;
                batteryInformation.percentage = estimatedChargeRemaining;
                batteryInformation.health = health;
                batteryInformation.expectedRunTime = estimatedRunTime;

                batteries.Add(batteryInformation);
            }

            return batteries;
        }

        private void CheckBatteryPercentage()
        {
            List<BatteryInformation> allBatteries = GetAllBatteries();

            foreach (BatteryInformation battery in allBatteries)
            {
                if (battery.percentage >= BATTERY_PERCENTAGE_UPPER_THRESHOLD)
                {
                    BatteryUpperThresholdReached?.Invoke(this, new BatteryStatusChangedEventArgs
                    {
                        batteryInformation = battery
                    });
                }

                if (battery.percentage <= BATTERY_PERCENTAGE_LOWER_THRESHOLD)
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
