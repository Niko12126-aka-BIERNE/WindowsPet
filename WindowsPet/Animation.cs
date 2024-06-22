namespace WindowsPet
{
    public class Animation(int frameDelayInMilliseconds, Size dimentions)
    {
        public Size Dimentions { get; init; } = dimentions;
        private readonly List<Bitmap> frames = [];
        public int FrameDelayInMilliseconds { get; private set; } = frameDelayInMilliseconds;
        private int frameIndex = 0;

        public static Animation FromSpriteSheetAndMetaData(Bitmap spriteSheet, Size spriteDimentions, int frameCount, int durationInMilliseconds, int scale)
        {
            Animation animation = new(durationInMilliseconds, new Size(spriteDimentions.Width * scale, spriteDimentions.Height * scale));

            for (int spriteIndex = 0; spriteIndex < frameCount; spriteIndex++)
            {
                Bitmap frame = new(spriteDimentions.Width, spriteDimentions.Height);

                int xOffset = spriteIndex * spriteDimentions.Width % spriteSheet.Width;
                int yOffset = spriteIndex * spriteDimentions.Width / spriteSheet.Width * spriteDimentions.Height;

                for (int y = 0; y < spriteDimentions.Height; y++)
                {
                    for (int x = 0; x < spriteDimentions.Width; x++)
                    {
                        Color pixelFromSpriteSheet = spriteSheet.GetPixel(xOffset + x, yOffset + y);

                        frame.SetPixel(x, y, pixelFromSpriteSheet);
                    }
                }

                if (scale > 1)
                {
                    frame = frame.Resize(scale);
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
