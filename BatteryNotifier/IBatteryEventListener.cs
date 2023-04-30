namespace BatteryNotifier
{
    public interface IBatteryEventListener
    {
        void StartListening(int poolIntervalSeconds);
    }
}