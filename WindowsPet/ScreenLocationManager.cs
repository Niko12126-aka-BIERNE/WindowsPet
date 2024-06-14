namespace WindowsPet
{
    internal class ScreenLocationManager
    {
        public static Point RandomLocation { get; private set; } = new Point(100, 100);

        public static void NewRandomLocation()
        {
            Random random = new();

            Screen[] screens = Screen.AllScreens;
            Screen randomScreen = screens[random.Next(screens.Length)];

            Rectangle screenBounds = randomScreen.Bounds;

            RandomLocation = new Point(
                random.Next(screenBounds.X, screenBounds.X + screenBounds.Width), 
                random.Next(screenBounds.Y + 100, screenBounds.Y + screenBounds.Height)
            );
        }
    }
}
