using System.Diagnostics;

namespace WindowsPet
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Process currentProcess = Process.GetCurrentProcess();
            currentProcess.PriorityClass = ProcessPriorityClass.BelowNormal;

            ConfigManager configManager = new();

            Bitmap homeSprite = configManager.LoadHomeSprite();
            Point homeStartLocation = configManager.LoadHomeStartLocation();

            Animation idleAnimation = configManager.LoadIdleAnimation();
            Animation walkAnimation = configManager.LoadWalkAnimation();
            Bitmap petIcon = configManager.LoadWindowsPetIcon();
            int speed = configManager.LoadPetSpeedInPixelsPerSecond();
            (int min, int max) = configManager.LoadBehaviorStateTime();
            Pet windowsPet = new(idleAnimation, walkAnimation, petIcon, speed, min, max);

            Application.Run(new HomeForm(homeSprite, homeStartLocation, windowsPet));
        }
    }
}