using System;
using System.Runtime.InteropServices;

namespace Esmeralda.Engine
{
    public static class API
    {
        #region GetAsyncKeyState
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern short GetAsyncKeyState(int vkey);
        #endregion

        #region GetSystemMetrics
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern int GetSystemMetrics(int nIndex);
        #endregion

        #region GetClientRect
        [DllImport("user32.dll")]
        internal static extern bool GetClientRect(IntPtr HWND, ref Rect rect);
        #endregion

        #region GetCursorPos
        [DllImport("user32.dll")]
        internal static extern bool GetCursorPos(out Point pt);
        #endregion

        #region ScreenToClient
        [DllImport("user32.dll")]
        internal static extern bool ScreenToClient(IntPtr hWnd, out Point lpPoint);
        #endregion

        #region Get Double Click Time
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        internal static extern int GetDoubleClickTime();
        #endregion
    }
}
