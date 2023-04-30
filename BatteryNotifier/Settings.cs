namespace BatteryNotifier
{
    public partial class Settings : Form
    {
        private static Settings? _instance;

        public static Settings GetInstance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    _instance = new Settings();
                }
                return _instance;
            }
        }
        public bool IsActive = false;

        public Settings()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            IsActive = true;
        }

        protected override void OnClosed(EventArgs e)
        {
            IsActive &= false;
        }

        protected override void OnLoad(EventArgs e)
        {
            batteryLowerThreshold.Value = Properties.Settings.Default.BATTERY_LOWER_THRESHOLD;
            batteryUpperThreshold.Value = Properties.Settings.Default.BATTERY_UPPER_THRESHOLD;

            apply.Enabled = false;
        }

        private void resetToDefault_Click(object sender, EventArgs e)
        {
            batteryLowerThreshold.Value = Properties.Settings.Default.BATTERY_LOWER_THRESHOLD_DEFAULT;
            batteryUpperThreshold.Value = Properties.Settings.Default.BATTERY_UPPER_THRESHOLD_DEFAULT;
        }

        private void apply_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BATTERY_LOWER_THRESHOLD = (int)batteryLowerThreshold.Value;
            Properties.Settings.Default.BATTERY_UPPER_THRESHOLD = (int)batteryUpperThreshold.Value;

            Properties.Settings.Default.Save();

            close_restart.Click -= CloseWindow;
            close_restart.Click += RestartApplication;
            close_restart.Text = "Restart";

            apply.Enabled = false;
        }

        private void CloseWindow(object? sender, EventArgs e)
        {
            Dispose();
        }

        private void RestartApplication(object? sender, EventArgs e)
        {
            BatteryNotifierApplicationContext.RestartApplication();
        }

        private void batteryLowerThreshold_ValueChanged(object sender, EventArgs e)
        {
            apply.Enabled = true;
        }

        private void batteryLowerThreshold_MouseClick(object sender, MouseEventArgs e)
        {
            apply.Enabled = true;
        }

        private void batteryUpperThreshold_ValueChanged(object sender, EventArgs e)
        {
            apply.Enabled = true;
        }

        private void batteryUpperThreshold_MouseClick(object sender, MouseEventArgs e)
        {
            apply.Enabled = true;
        }
    }
}
