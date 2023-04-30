namespace BatteryNotifier
{
    public interface IBatteryRepository
    {
        public void Add(BatteryInformation batteryInformation);
        public List<BatteryInformation> GetAll();
    }
}
