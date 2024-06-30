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
            int scale = EnvReader.GetIntValue("PET_SCALE");

            return Animation.FromSpriteSheetAndMetaData(spriteSheet, new Size(width, height), frameCount, frameDelay, scale);
        }

        public Animation LoadWalkAnimation()
        {
            Bitmap spriteSheet = new(EnvReader.GetStringValue("WALK_ANIMATION_SPRITE_SHEET"));
            int frameCount = EnvReader.GetIntValue("WALK_ANIMATION_FRAME_COUNT");
            int frameDelay = EnvReader.GetIntValue("WALK_ANIMATION_FRAME_DELAY");
            int width = EnvReader.GetIntValue("PET_SPRITE_WIDTH");
            int height = EnvReader.GetIntValue("PET_SPRITE_HEIGHT");
            int scale = EnvReader.GetIntValue("PET_SCALE");

            return Animation.FromSpriteSheetAndMetaData(spriteSheet, new Size(width, height), frameCount, frameDelay, scale);
        }

        public Bitmap LoadHomeSprite()
        {
            int scale = EnvReader.GetIntValue("HOME_SCALE");

            return new Bitmap(EnvReader.GetStringValue("HOME_SPRITE")).Resize(scale);
        }

        public Bitmap LoadWindowsPetIcon()
        {
            return new Bitmap(EnvReader.GetStringValue("SYSTEM_TRAY_ICON"));
        }

        public (int min, int max) LoadBehaviorStateTime()
        {
            int min = EnvReader.GetIntValue("MIN_BEHAVIOR_STATE_TIME");
            int max = EnvReader.GetIntValue("MAX_BEHAVIOR_STATE_TIME");

            return (min, max);
        }

        public int LoadPetSpeedInPixelsPerSecond()
        {
            return EnvReader.GetIntValue("PET_SPEED_IN_PIXELS_PER_SECOND");
        }

        public Point LoadHomeStartLocation()
        {
            int startCoordX = EnvReader.GetIntValue("HOME_START_LOCATION_X");
            int startCoordY = EnvReader.GetIntValue("HOME_START_LOCATION_Y");

            return new Point(startCoordX, startCoordY);
        }
    }
}
