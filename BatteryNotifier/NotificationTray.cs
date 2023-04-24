using System.Reflection;

namespace BatteryNotifier
{
    internal class NotificationTray
    {
        public const string SETTINGS_LABEL = "Settings";
        public const string EXIT_LABEL = "Exit";

        public event EventHandler<ContextMenuButtonClickedEventArgs>? ContextMenuButtonClicked;

        private NotifyIcon notifyIcon;
        private ContextMenuStrip contextMenu;

        public NotificationTray()
        {

            notifyIcon = new NotifyIcon();
            contextMenu = new ContextMenuStrip();

            notifyIcon.Icon = Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            notifyIcon.ContextMenuStrip = contextMenu;

            contextMenu.Items.Add(SETTINGS_LABEL, null, ShowSettingsView);
            contextMenu.Items.Add(EXIT_LABEL, null, TriggerApplicationExit);

        }

        private void TriggerApplicationExit(object? sender, EventArgs e)
        {
            ContextMenuButtonClicked?.Invoke(this, new ContextMenuButtonClickedEventArgs
            {
                MenuItemName = EXIT_LABEL,
            });
        }

        private void ShowSettingsView(object? sender, EventArgs e)
        {
            ContextMenuButtonClicked?.Invoke(this, new ContextMenuButtonClickedEventArgs
            {
                MenuItemName = SETTINGS_LABEL,
            });
        }

        public void SetVisibility(bool visible)
        {
            notifyIcon.Visible = visible;
        }

        public void SendNotification(string title, string message)
        {            
            notifyIcon.ShowBalloonTip(60, title, message, ToolTipIcon.Warning);
        }
    }

    internal class ContextMenuButtonClickedEventArgs
    {
        public string? MenuItemName;
    }
}
