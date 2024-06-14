using System.Runtime.InteropServices;

namespace WindowsPet
{
    internal class MouseManager
    {
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        public static Point GetMouseLocation()
        {
            GetCursorPos(out Point lpPoint);

            return lpPoint;
        }
    }
}
