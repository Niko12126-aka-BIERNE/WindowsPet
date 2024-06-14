namespace WindowsPet
{
    public class Animation(int frameDelayInMilliseconds, Size dimentions)
    {
        public Size Dimentions { get; init; } = dimentions;
        private readonly List<Bitmap> frames = [];
        public int FrameDelayInMilliseconds { get; private set; } = frameDelayInMilliseconds;
        private int frameIndex = 0;

        public static Animation FromSpriteSheetAndMetaData(Bitmap spriteSheet, int spriteWidth, int durationInMilliseconds)
        {
            Animation animation = new(durationInMilliseconds, new Size(spriteWidth, spriteSheet.Height));

            for (int spriteIndex = 0; spriteIndex < spriteSheet.Width / spriteWidth; spriteIndex++)
            {
                Bitmap frame = new(spriteWidth, spriteSheet.Height);
                int xOffset = spriteIndex * spriteWidth;

                for (int y = 0; y < spriteSheet.Height; y++)
                {
                    for (int x = 0; x < spriteWidth; x++)
                    {
                        Color pixelFromSpriteSheet = spriteSheet.GetPixel(xOffset + x, y);

                        frame.SetPixel(x, y, pixelFromSpriteSheet);
                    }
                }

                animation.frames.Add(frame);
            }

            return animation;
        }

        public Bitmap NextFrame(Direction direction)
        {
            if (frames.Count == 0)
            {
                throw new Exception("The animation does not contain any frames.");
            }

            Bitmap frame = (Bitmap)frames[frameIndex++].Clone();
            frameIndex %= frames.Count;

            if (direction == Direction.Right)
            {
                frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
            }

            return frame;
        }

        public void Reset()
        {
            frameIndex = 0;
        }
    }
}
