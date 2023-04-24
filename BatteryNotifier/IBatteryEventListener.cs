namespace BatteryNotifier
{
    internal interface IBatteryEventListener
    {
        void StartListening(int poolIntervalSeconds);
        List<BatteryInformation> GetAllBatteries();
    }
}