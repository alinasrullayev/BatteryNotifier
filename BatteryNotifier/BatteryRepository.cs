using System.Management;

namespace BatteryNotifier
{
    internal class BatteryRepository : IBatteryRepository
    {
        public void Add(BatteryInformation batteryInformation)
        {
            throw new NotImplementedException();
        }

        public List<BatteryInformation> GetAll()
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
    }
}
