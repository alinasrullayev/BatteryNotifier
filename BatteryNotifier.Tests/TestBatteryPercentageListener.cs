namespace BatteryNotifier.Tests;

public class TestBatteryPercentageListener
{
    private IBatteryPercentageListener? _listener;

    [Fact]
    public void TestLowBatteryAlertIsTriggered()
    {
        AutoResetEvent are = new AutoResetEvent(false);

        BatteryInformation battery1 = new BatteryInformation();
        battery1.deviceID = "1";
        battery1.percentage = 20;
        battery1.health = "OK";
        battery1.expectedRunTime = 60;
        battery1.state = BatteryState.Other;

        IBatteryRepository repository = new InMemoryBatteryRepository();
        repository.Add(battery1);

        _listener = new BatteryPercentageListener(repository);
        _listener.BatteryLowerThresholdReached += (sender, args) => { are.Set(); };

        _listener.StartListening(3);
        Assert.True(are.WaitOne(TimeSpan.FromSeconds(1)));
    }
}