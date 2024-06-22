using System.Drawing.Drawing2D;

namespace WindowsPet
{
    public static class BitmapExtensions
    {
        public static Bitmap Resize(this Bitmap bitmap, int scale)
        {
            int scaledWidth = bitmap.Width * scale;
            int scaledHeight = bitmap.Height * scale;

            Bitmap resizedFrame = new(scaledWidth, scaledHeight);

            using (Graphics graphic = Graphics.FromImage(resizedFrame))
            {
                graphic.InterpolationMode = InterpolationMode.NearestNeighbor;
                graphic.DrawImage(bitmap, 0, 0, scaledWidth, scaledHeight);
            }

            return resizedFrame;
        }
    }
}
