using System.Configuration;

namespace Client
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.ApplicationExit += OnApplicationExit;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            ConfigManager.Load();
#if DEBUG
            Application.Run(new ServerDiscoveryForm());
#elif PREVIEW
            Application.Run(new Crop_picturebox());
#else
            Application.Run(new SplashScreen());
#endif

        }

        private static void OnApplicationExit(object? sender, EventArgs e)
        {
            // TODO: Fix this cleanup logic to ensure it works as intended.
            System.Diagnostics.Debug.WriteLine("Application is exiting. Cleaning up Cached directory.");
            var directory = new DirectoryInfo(Path.Combine(Application.StartupPath, "Cached"));
            if (directory.Exists)
            {
                try
                {
                    directory.Delete(true);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Error deleting Cached directory: {ex.Message}");
                }
            }
        }
    }
}