﻿namespace BatteryNotifier
{
    internal class BatteryNotifierApplicationContext : ApplicationContext
    {

        private NotificationTray notificationTray;
        private BatteryPercentageListener batteryEventListener;

        public BatteryNotifierApplicationContext()
        {
            // Enable Notification Tray
            notificationTray = new NotificationTray();

            notificationTray.SetVisibility(true);
            notificationTray.ContextMenuButtonClicked += HandleContextMenuButtonClick;

            // Enable Battery Events Listener
            batteryEventListener = new BatteryPercentageListener();
            batteryEventListener.StartListening(60);

            batteryEventListener.BatteryUpperThresholdReached += HandleBatteryUpperThresholdReached;
            batteryEventListener.BatteryLowerThresholdReached += HandleBatteryLowerThresholdReached;
        }

        private void HandleBatteryLowerThresholdReached(object? sender, BatteryStatusChangedEventArgs e)
        {
            BatteryInformation? batteryInformation = e.batteryInformation;

            string title = $"Battery Warning: \n{batteryInformation?.deviceID}";
            string message = "" +               
                $"Battery percentage is {batteryInformation?.percentage}%, please plug in charger\n" +                
                $"Remaining Time: {batteryInformation?.expectedRunTime} minutes\n";

            notificationTray.SendNotification(title, message);
        }

        private void HandleBatteryUpperThresholdReached(object? sender, BatteryStatusChangedEventArgs e)
        {
            BatteryInformation? batteryInformation = e.batteryInformation;

            string title = $"Battery Warning: \n{batteryInformation?.deviceID}";
            string message = "" +
                $"Battery percentage is {batteryInformation?.percentage}%, please disconnect the charger\n" +
                $"Remaining Time: {batteryInformation?.expectedRunTime} minutes\n";            

            notificationTray.SendNotification(title, message);
        }

        private void HandleContextMenuButtonClick(object? sender, ContextMenuButtonClickedEventArgs e)
        {
            switch (e.MenuItemName)
            {
                case NotificationTray.SETTINGS_LABEL:
                    Console.WriteLine($"{e.MenuItemName} Clicked");
                    break;

                case NotificationTray.EXIT_LABEL:
                    Console.WriteLine($"{e.MenuItemName} Clicked");
                    Application.Exit();
                    break;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}