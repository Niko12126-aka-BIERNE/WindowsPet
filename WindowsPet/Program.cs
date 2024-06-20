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

            Animation idleAnimation = configManager.LoadIdleAnimation();
            Animation walkAnimation = configManager.LoadWalkAnimation();
            Bitmap petIcon = configManager.LoadWindowsPetIcon();
            Pet windowsPet = new(idleAnimation, walkAnimation, petIcon);

            Application.Run(new HomeForm(homeSprite, windowsPet));
        }
    }
}