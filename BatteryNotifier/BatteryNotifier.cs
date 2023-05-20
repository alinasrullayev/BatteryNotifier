namespace BatteryNotifier
{
    internal static class BatteryNotifier
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (
                System.Diagnostics.Process.GetProcessesByName(
                    System.IO.Path.GetFileNameWithoutExtension(
                        System.Reflection.Assembly.GetEntryAssembly().Location
                    )
                ).Count() > 1
            )
            {

            }
            ApplicationConfiguration.Initialize();
            Application.Run(BatteryNotifierApplicationContext.GetInstance());
        }
    }
}