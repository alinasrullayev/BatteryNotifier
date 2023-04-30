namespace BatteryNotifier.Tests
{
    internal class InMemoryBatteryRepository : IBatteryRepository
    {
        private List<BatteryInformation> _batteries;

        public InMemoryBatteryRepository()
        {
            _batteries = new List<BatteryInformation>();
        }

        public void Add(BatteryInformation batteryInformation)
        {
            _batteries.Add(batteryInformation); 
        }

        public List<BatteryInformation> GetAll()
        {
            return _batteries;
        }
    }
}
