using System.Runtime.InteropServices;

namespace WindowsPet
{
    internal partial class WindowManager
    {
        [LibraryImport("user32.dll")]
        private static partial IntPtr GetForegroundWindow();

        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool IsWindowVisible(IntPtr hWnd);

        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool IsIconic(IntPtr hWnd); // Check if window is minimized

        [LibraryImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static partial bool IsZoomed(IntPtr hWnd); // Check if window is maximized

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static RECT? GetFocusedWindowRectangle(IntPtr petHandle, IntPtr homeHandle)
        {
            IntPtr focusedWindowPtr = GetForegroundWindow();

            if (focusedWindowPtr == petHandle || focusedWindowPtr == homeHandle)
            {
                return null;
            }

            if (IsZoomed(focusedWindowPtr))
            {
                return null;
            }

            if (!IsWindowVisible(focusedWindowPtr) || IsIconic(focusedWindowPtr))
            {
                return null;
            }

            return GetWindowRectangle(focusedWindowPtr);
        }

        public static RECT GetWindowRectangle(IntPtr windowHandle)
        {
            GetWindowRect(windowHandle, out RECT focusedWindowRectangle);
            return focusedWindowRectangle;
        }
    }
}
