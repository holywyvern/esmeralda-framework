using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esmeralda.Input
{
    public static class Keyboard
    {

        #region Keyboard Trigger
        public static bool Trigger(Keys key)
        {
            return Reader.Triggered[(int)key];
        }
        #endregion

        #region Keyboard Press
        public static bool Press(Keys key)
        {
            return Reader.Pressed[(int)key];
        }
        #endregion

        #region Keyboard Release
        public static bool Release(Keys key)
        {
            return Reader.Released[(int)key];
        }
        #endregion

        #region Keyboard PressedTime
        public static ulong PressedTime(Keys key)
        {
            return Reader.PressedTime[(int)key];
        }
        #endregion

        #region Keyboard Any Triggered
        public static bool AnyTriggered(Keys[] buttons)
        {
            foreach (Keys btn in buttons)
            {
                if (Reader.Triggered[(int)btn] == true)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Keyboard Any Pressed
        public static bool AnyPressed(Keys[] buttons)
        {
            foreach (Keys btn in buttons)
            {
                if (Reader.Pressed[(int)btn] == true)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Keyboard Any Released
        public static bool AnyReleased(Keys[] buttons)
        {
            foreach (Keys btn in buttons)
            {
                if (Reader.Triggered[(int)btn] == true)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region Keyboard All Triggered
        public static bool AllTriggered(Keys[] btns)
        {
            foreach (Keys btn in btns)
            {
                if (Reader.Triggered[(int)btn] == false)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Keyboard All Pressed
        public static bool AllPressed(Keys[] btns)
        {
            foreach (Keys btn in btns)
            {
                if (Reader.Pressed[(int)btn] == false)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Keyboard All Released
        public static bool AllReleased(Keys[] btns)
        {
            foreach (Keys btn in btns)
            {
                if (Reader.Released[(int)btn] == false)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Keyboard Are Triggered
        public static Keys[] AreTriggered
        {
            get { return BeingTriggered(); }
        }
        #endregion

        #region Keyboard Are Pressed
        public static Keys[] ArePressed
        {
            get { return BeingPressed(); }
        }
        #endregion

        #region Keyboard Are Released
        public static Keys[] AreReleased
        {
            get { return BeingReleased(); }
        }
        #endregion

        #region Keyboard Keys Being Triggered
        private static Keys[] BeingTriggered()
        {
            var result = new List<Keys>();
            for(int key = 0; key < 256; key++)
            {
                if (Reader.Triggered[key] == true)
                {
                    result.Add((Keys)key);
                }
            }
            return result.ToArray();
        }
        #endregion

        #region Keyboard Keys Being Pressed
        private static Keys[] BeingPressed()
        {
            var result = new List<Keys>();
            for (int key = 0; key < 256; key++)
            {
                if (Reader.Pressed[key] == true)
                {
                    result.Add((Keys)key);
                }
            }
            return result.ToArray();
        }
        #endregion

        #region Keyboard Keys Being Released
        private static Keys[] BeingReleased()
        {
            var result = new List<Keys>();
            for (int key = 0; key < 256; key++)
            {
                if (Reader.Released[key] == true)
                {
                    result.Add((Keys)key);
                }
            }
            return result.ToArray();
        }
        #endregion
    }
}
