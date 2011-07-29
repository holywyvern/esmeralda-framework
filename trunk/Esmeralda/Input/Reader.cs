using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Esmeralda.Engine;

namespace Esmeralda.Input
{
    public static class Reader
    {
        #region Children Variable Declaration
        internal static bool[] Triggered = new bool[256];
        internal static bool[] Pressed = new bool[256];
        internal static bool[] Released = new bool[256];
        internal static ulong[] PressedTime = new ulong[256];

        internal static Engine.Rect windowPos;
        internal static Engine.Point cursorPos;
        internal static bool MouseSwapButtons;
        internal static bool[] mouseDoubleClick = new bool[2] { false, false };
        private static int[] mouseDoubleClickCount = new int[2];
        private static int mouseDoubleClickTime = Engine.API.GetDoubleClickTime() / 60;
        #endregion

        #region Self Variables
        private static bool initialized;
        private static IntPtr HWND;
        #endregion

        #region Input Start
        public static void Initialize(IntPtr hwnd)
        {
            if (initialized) { return; }
            initialized = true;
            for (int i = 0; i < 256; i++)
            {
                Triggered[i] = false;
                Pressed[i] = false;
                Released[i] = false;
                PressedTime[i] = 0;
            }
            MouseSwapButtons = API.GetSystemMetrics(23) > 0;
            HWND = hwnd;
        }
        #endregion

        #region InputManager Update
        public static void Update()
        {
            UpdateKeyboard();
            UpdateMouse();
        }
        #endregion

        #region Update Keyboard
        private static void UpdateKeyboard()
        {
            for (int i = 0; i < 256; i++)
            {
                if (API.GetAsyncKeyState(i) != 0)
                {
                    Triggered[i] = PressedTime[i] == 1 ? true : false;
                    Pressed[i] = PressedTime[i] < 1 ? false : true;
                    PressedTime[i] += 1;
                    Released[i] = false;
                }
                else
                {
                    Triggered[i] = false;
                    Pressed[i] = false;
                    Released[i] = PressedTime[i] > 1 ? true : false;
                    PressedTime[i] = 0;
                }
            }
        }
        #endregion

        #region Update Mouse
        private static void UpdateMouse()
        {
            API.GetClientRect(HWND, ref windowPos);
            API.GetCursorPos(out cursorPos);
            API.ScreenToClient(HWND, out cursorPos);
            DoubleClickUpdate();
        }
        #endregion

        #region Double Click Update
        private static void DoubleClickUpdate()
        {
            CheckMouseBtnRelease();
            for (int i = 0; i < 2; i++)
            {
                if (mouseDoubleClickCount[i] > 0) { mouseDoubleClickCount[i] -= 1; }
            }
            CheckDoubleClick();
        }
        #endregion

        #region Check Mouse Button Release
        private static void CheckMouseBtnRelease()
        {
            if (Mouse.Release(MouseButtons.MousePrimary))
            {
                mouseDoubleClickCount[0] = mouseDoubleClickTime;
            }
            if (Mouse.Release(MouseButtons.MouseSecondary))
            {
                mouseDoubleClickCount[1] = mouseDoubleClickTime;
            }
        }
        #endregion

        #region Check Double Click
        private static void CheckDoubleClick()
        {
            var primaryChecker = Mouse.Trigger(MouseButtons.MousePrimary) && mouseDoubleClickCount[0] > 0;
            mouseDoubleClick[0] = primaryChecker ? true : false;
            var secondaryChecker = Mouse.Trigger(MouseButtons.MouseSecondary) && mouseDoubleClickCount[1] > 0;
            mouseDoubleClick[1] = secondaryChecker ? true : false;
        }
        #endregion
    }
}


