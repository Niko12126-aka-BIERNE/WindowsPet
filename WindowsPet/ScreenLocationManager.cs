namespace WindowsPet
{
    internal class ScreenLocationManager(Size petSize)
    {
        private (int x, int y) ScreenLocationOffset { get; set; } = (petSize.Width / 2, petSize.Height);
        public Point RandomLocation { get; private set; } = new Point(0, 0);
        public Point RandomLineLocation { get; private set; } = new Point(0, 0);

        public void NewRandomLocation()
        {
            Screen[] screens = Screen.AllScreens;
            Screen randomScreen = screens[Random.Shared.Next(screens.Length)];

            Rectangle screenBounds = randomScreen.Bounds;

            RandomLocation = new Point(
                Random.Shared.Next(screenBounds.X + ScreenLocationOffset.x, screenBounds.X + screenBounds.Width - ScreenLocationOffset.x),
                Random.Shared.Next(screenBounds.Y + ScreenLocationOffset.y, screenBounds.Y + screenBounds.Height)
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

        public void NewRandomLineLocation()
        {
            Screen[] screens = Screen.AllScreens;
            Screen randomScreen = screens[Random.Shared.Next(screens.Length)];

            Bitmap screenShot = new(randomScreen.Bounds.Width, randomScreen.Bounds.Height);

            Graphics screenShotGraphics = Graphics.FromImage(screenShot);
            screenShotGraphics.CopyFromScreen(randomScreen.Bounds.Left, randomScreen.Bounds.Top, 0, 0, randomScreen.Bounds.Size);

            List<Line> lines = DetectHorizontalLines(screenShot, (int)(petSize.Width * 1.5), 10, 5);
            Line randomLine = lines[Random.Shared.Next(lines.Count)];

            Point randomLineLocation = new(Random.Shared.Next(randomScreen.Bounds.Left + randomLine.StartX + petSize.Width / 2, randomScreen.Bounds.Left + randomLine.EndX - petSize.Width / 2), randomScreen.Bounds.Top + randomLine.StartY);
            RandomLineLocation = randomLineLocation;
        }

        private static List<Line> DetectHorizontalLines(Bitmap image, int minLength, int tolerance, int lineTolerance)
        {
            List<Line> lines = [];

            for (int y = 0; y < image.Height - 1; y++)
            {
                Color currentLineColor = image.GetPixel(0, y);
                Line currentLine = new(0, y + 1, 0, y + 1);

                for (int x = 1; x < image.Width; x++)
                {
                    Color currentPixelColor = image.GetPixel(x, y);

                    if (currentPixelColor.Equals(currentLineColor) && !IsColorMatch(currentPixelColor, image.GetPixel(x, y + 1), tolerance))
                    {
                        currentLine.EndX = x;
                    }
                    else
                    {
                        if (currentLine.EndX - currentLine.StartX >= minLength)
                        {
                            if (IsLineValid(currentLine, lines, lineTolerance))
                            {
                                lines.Add(currentLine);
                            }
                        }

                        currentLineColor = currentPixelColor;
                        currentLine = new(x, y + 1, x, y + 1);
                    }
                }

                if (currentLine.EndX - currentLine.StartX >= minLength)
                {
                    if (IsLineValid(currentLine, lines, lineTolerance))
                    {
                        lines.Add(currentLine);
                    }
                }
            }

            return lines;
        }

        private static bool IsLineValid(Line line, List<Line> lines, int lineTolerance)
        {
            int centerX = line.StartX + (line.EndX - line.StartX) / 2;

            bool currentLineIsValid = true;
            foreach (Line currentLine in lines)
            {
                if (currentLine.StartY < line.StartY && currentLine.StartY >= line.StartY - lineTolerance)
                {
                    if (currentLine.StartX < centerX && currentLine.EndX > centerX)
                    {
                        currentLineIsValid = false;
                        break;
                    }
                }
            }

            return currentLineIsValid;
        }

        private static bool IsColorMatch(Color pixelColor, Color lineColor, int tolerance)
        {
            return Math.Abs(pixelColor.R - lineColor.R) <= tolerance &&
                   Math.Abs(pixelColor.G - lineColor.G) <= tolerance &&
                   Math.Abs(pixelColor.B - lineColor.B) <= tolerance;
        }
    }
}
