using dotenv.net;
using dotenv.net.Utilities;

namespace WindowsPet
{
    internal class ConfigManager
    {
        public ConfigManager()
        {
            DotEnv.Load(options: new DotEnvOptions(envFilePaths: [Environment.CurrentDirectory + "\\Config.env"]));
        }

        public Animation LoadIdleAnimation()
        {
            Bitmap spriteSheet = new(EnvReader.GetStringValue("IDLE_ANIMATION_SPRITE_SHEET"));
            int frameCount = EnvReader.GetIntValue("IDLE_ANIMATION_FRAME_COUNT");
            int frameDelay = EnvReader.GetIntValue("IDLE_ANIMATION_FRAME_DELAY");
            int width = EnvReader.GetIntValue("PET_SPRITE_WIDTH");
            int height = EnvReader.GetIntValue("PET_SPRITE_HEIGHT");

            return Animation.FromSpriteSheetAndMetaData(spriteSheet, new Size(width, height), frameCount, frameDelay);
        }

        public Animation LoadWalkAnimation()
        {
            Bitmap spriteSheet = new(EnvReader.GetStringValue("WALK_ANIMATION_SPRITE_SHEET"));
            int frameCount = EnvReader.GetIntValue("WALK_ANIMATION_FRAME_COUNT");
            int frameDelay = EnvReader.GetIntValue("WALK_ANIMATION_FRAME_DELAY");
            int width = EnvReader.GetIntValue("PET_SPRITE_WIDTH");
            int height = EnvReader.GetIntValue("PET_SPRITE_HEIGHT");


            return Animation.FromSpriteSheetAndMetaData(spriteSheet, new Size(width, height), frameCount, frameDelay);
        }

        public Bitmap LoadHomeSprite()
        {
            return new Bitmap(EnvReader.GetStringValue("HOME_SPRITE"));
        }

        public Bitmap LoadWindowsPetIcon()
        {
            return new Bitmap(EnvReader.GetStringValue("SYSTEM_TRAY_ICON"));
        }
    }
}
