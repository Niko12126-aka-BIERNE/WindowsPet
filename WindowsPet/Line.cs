namespace WindowsPet
{
    public class Line(int startX, int startY, int endX, int endY)
    {
        public int StartX { get; set; } = startX;
        public int StartY { get; set; } = startY;
        public int EndX { get; set; } = endX;
        public int EndY { get; set; } = endY;
    }
}
