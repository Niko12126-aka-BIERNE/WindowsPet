namespace WindowsPet
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Bitmap homeSprite = new("Home_Sprite.png");

            Animation idleAnimation = Animation.FromSpriteSheetAndMetaData(new Bitmap("Idle_Animation_Sprite_Sheet.png"), 96, 300);
            Animation walkAnimation = Animation.FromSpriteSheetAndMetaData(new Bitmap("Walk_Animation_Sprite_Sheet.png"), 96, 100);
            Pet windowsPet = new(idleAnimation, walkAnimation);

            Application.Run(new HomeForm(homeSprite, windowsPet));
        }
    }
}