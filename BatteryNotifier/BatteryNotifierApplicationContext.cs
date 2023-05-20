namespace BatteryNotifier
{
    internal class BatteryNotifierApplicationContext : ApplicationContext
    {
        private static BatteryNotifierApplicationContext? _instance;
        private NotificationTray _notificationTray;
        private BatteryPercentageListener _batteryEventListener;

        public static BatteryNotifierApplicationContext GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BatteryNotifierApplicationContext();
            }

            return _instance;
        }

        private BatteryNotifierApplicationContext()
        {
            if (
                System.Diagnostics.Process.GetProcessesByName(
                    Path.GetFileNameWithoutExtension(
                        System.Reflection.Assembly.GetEntryAssembly()?.Location
                    )
                ).Count() > 1
            )
            {
                DialogResult dialogResult = MessageBox.Show(
                    "Only one instance of app can run at the same time",
                    "BatteryNotifier"
                );
                if (dialogResult == DialogResult.OK)
                {
                    ExitApplication();
                }
            }

            // Enable Notification Tray
            _notificationTray = new NotificationTray();

            _notificationTray.SetVisibility(true);
            _notificationTray.ContextMenuButtonClicked += HandleContextMenuButtonClick;

            // Enable Battery Events Listener
            _batteryEventListener = new BatteryPercentageListener(new BatteryRepository());
            _batteryEventListener.BatteryUpperThresholdReached += HandleBatteryUpperThresholdReached;
            _batteryEventListener.BatteryLowerThresholdReached += HandleBatteryLowerThresholdReached;

            _batteryEventListener.StartListening(60);
        }

        private void HandleBatteryLowerThresholdReached(object? sender, BatteryStatusChangedEventArgs e)
        {
            BatteryInformation? batteryInformation = e.batteryInformation;

            string title = $"Battery Warning: \n{batteryInformation?.deviceID}";
            string message = "" +
                $"Battery percentage is {batteryInformation?.percentage}%, please plug in charger\n" +
                $"Remaining Time: {batteryInformation?.expectedRunTime} minutes\n";

            _notificationTray.SendNotification(title, message);
        }

        private void HandleBatteryUpperThresholdReached(object? sender, BatteryStatusChangedEventArgs e)
        {
            BatteryInformation? batteryInformation = e.batteryInformation;

            string title = $"Battery Warning: \n{batteryInformation?.deviceID}";
            string message = "" +
                $"Battery percentage is {batteryInformation?.percentage}%, please disconnect the charger\n" +
                $"Remaining Time: {batteryInformation?.expectedRunTime} minutes\n";

            _notificationTray.SendNotification(title, message);
        }

        private void HandleContextMenuButtonClick(object? sender, ContextMenuButtonClickedEventArgs e)
        {
            switch (e.MenuItemName)
            {
                case NotificationTray.SETTINGS_LABEL:
                    Settings settings = Settings.GetInstance();

                    if (!settings.IsActive)
                    {
                        settings.ShowDialog();
                    }

                    break;

                case NotificationTray.EXIT_LABEL:
                    ExitApplication();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }

        public void RestartApplication()
        {
            Application.Restart();
            Environment.Exit(0);
        }

        public void ExitApplication()
        {
            _notificationTray.SetVisibility(false);
            Application.Exit();
        }
    }
}
