using System;

namespace Esmeralda.Input
{
    public static class Mouse
    {
        #region Mouse Trigger
        public static bool Trigger(MouseButtons button)
        {
            return Reader.Triggered[GetButton(button)];
        }
        #endregion

        #region Mouse DoubleClick
        public static bool DoubleClick(MouseButtons btn)
        {
            switch (btn)
            {
                case MouseButtons.MousePrimary: { return Reader.mouseDoubleClick[0]; }
                case MouseButtons.MouseSecondary: { return Reader.mouseDoubleClick[1]; }
            }
            return false;
        }
        #endregion

        #region Mouse Press
        public static bool Press(MouseButtons button)
        {
            return Reader.Pressed[GetButton(button)];
        }
        #endregion

        #region Mouse PressedTime
        public static ulong PressedTime(MouseButtons button)
        {
            return Reader.PressedTime[GetButton(button)];
        }
        #endregion

        #region Mouse Release
        public static bool Release(MouseButtons button)
        {
            return Reader.Released[GetButton(button)];
        }
        #endregion

        #region Mouse Get Button (swap utilitie)
        private static byte GetButton(MouseButtons button)
        {
            if (Reader.MouseSwapButtons && button == MouseButtons.MousePrimary)
            {
                return 2;
            }
            else if (Reader.MouseSwapButtons && button == MouseButtons.MouseSecondary)
            {
                return 1;
            }
            else 
            {
                return (byte)button;
            }
        }
        #endregion

        #region Mouse Get Cursor Pos
        public static Engine.Point Position
        {
            get { return Reader.cursorPos; }
        }
        #endregion

        #region Mouse On Screen
        public static bool MouseOnScreen
        {
            get
            {
                var cursor = Reader.cursorPos;
                var window = Reader.windowPos;
                var min = (cursor.X > -1 && cursor.Y > -1);
                var max = (cursor.X <= window.right && cursor.Y <= window.bottom);
                return (min && max);
            }
        }
        #endregion
    }
}
