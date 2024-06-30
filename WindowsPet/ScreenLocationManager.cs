namespace WindowsPet
{
    internal class ScreenLocationManager(Size petSize)
    {
        private (int x, int y) ScreenLocationOffset { get; set; } = (petSize.Width / 2, petSize.Height);
        public Point RandomLocation { get; private set; } = new Point(100, 100);

        public void NewRandomLocation()
        {
            Random random = new();

            Screen[] screens = Screen.AllScreens;
            Screen randomScreen = screens[random.Next(screens.Length)];

            Rectangle screenBounds = randomScreen.Bounds;

            RandomLocation = new Point(
                random.Next(screenBounds.X + ScreenLocationOffset.x, screenBounds.X + screenBounds.Width - ScreenLocationOffset.x), 
                random.Next(screenBounds.Y + ScreenLocationOffset.y, screenBounds.Y + screenBounds.Height)
            );
        }

        public static bool IsValidLocation(Point location)
        {
            bool isValid = false;

            Screen[] screens = Screen.AllScreens;
            for (int i = 0; i < screens.Length && !isValid; i++)
            {
                Rectangle screenBounds = screens[i].Bounds;

                isValid = location.X >= screenBounds.X && 
                          location.X < screenBounds.X + screenBounds.Width &&
                          location.Y >= screenBounds.Y && 
                          location.Y < screenBounds.Y + screenBounds.Height;
            }

            return isValid;
        }
    }
}
