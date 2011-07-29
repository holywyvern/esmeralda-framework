using System;
using System.Collections.Generic;
using Esmeralda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Esmeralda.Graphics
{
    public class SpriteBase : Sprite
    {
        #region Constructor
        /// <summary>
        /// This class performs a new Sprite to be drawn in the screen
        /// </summary>
        /// <param name="image">string refering the bitmap</param>
        /// <param name="contentManager">content manager to load the bitmap</param>
        public SpriteBase(Texture2D bitmap)
        {
            this.bitmap = bitmap;
            this.position = Vector2.Zero;
            this.srcRect = new Rectangle(0, 0, this.bitmap.Width, this.bitmap.Height);
            this.tint = Color.White;
            this.origin = Vector2.Zero;
            this.zoom = new Vector2(1f);
            this.angle = 0;
            this.z = 0;
        }
        #endregion

        #region Set Pixel
        /// <summary>
        /// Sets one pixel of the sprite 
        /// </summary>
        /// <param name="targetX">position on x axis of pixel to modify</param>
        /// <param name="targetY">position on y axis of pixel to modify</param>
        /// <param name="newColor">the new color</param>
        public void SetPixel(int targetX, int targetY, Color newColor)
        {
            var colorData = GetColorData(bitmap);
            var target = targetY * bitmap.Width + targetX;
            colorData[target] = newColor;
            this.bitmap.SetData<Color>(colorData);
        }
        #endregion

        #region Get Pixel
        public Color GetPixel(int targetX, int targetY)
        {
            return GetColorData(this.bitmap)[targetY * this.bitmap.Width + targetX];
        }
        #endregion

        #region Bitmap Blit
        /// <summary>
        /// SDL like bitblit
        /// </summary>
        /// <param name="x">x destination</param>
        /// <param name="y">y destination</param>
        /// <param name="src">source sprite</param>
        public void BitmapBlit(int x, int y, Sprite src)
        {
            var sWidth = src.Bitmap.Width;
            var sHeight = src.Bitmap.Height;
            var maxSize = GetPixelLength();
            var blitSize = sWidth * sHeight;
            var sColorData = new Color[blitSize];
            src.Bitmap.GetData<Color>(sColorData);
            if (blitSize > maxSize)
            {
                SetColorData(0, new Rectangle(x, y, sWidth, sHeight), sColorData, maxSize);
            }
            else
            {
                SetColorData(0, new Rectangle(x, y, sWidth, sHeight), sColorData, blitSize);
            }
            GC.Collect();
        }
        #endregion

        #region Bitmap Blit with sprite rect
        /// <summary>
        /// SDL like bitblit
        /// </summary>
        /// <param name="x">x destination</param>
        /// <param name="y">y destination</param>
        /// <param name="src">source sprite</param>
        /// <param name="rect">source rect</param>
        public void BitmapBlit(int x, int y, Sprite src, Rectangle rect)
        {
            var sWidth = rect.Width;
            var sHeight = rect.Height;
            var maxSize = GetPixelLength();
            var blitSize = sWidth * sHeight;
            var sColorData = new Color[blitSize];
            src.Bitmap.GetData<Color>(0,rect, sColorData, 0, blitSize);
            if (blitSize > maxSize)
            {
                SetColorData(0, new Rectangle(x, y, sWidth, sHeight), sColorData, maxSize);
            }
            else
            {
                SetColorData(0, new Rectangle(x, y, sWidth, sHeight), sColorData, blitSize);
            }
            GC.Collect();
        }
        #endregion

        #region GetPixelLength
        /// <summary>
        /// Gets the pixels amount of the bitmap
        /// </summary>
        /// <returns></returns>
        private int GetPixelLength()
        {
            return this.bitmap.Width * this.bitmap.Height;
        }
        #endregion

        #region Get Color Data
        /// <summary>
        /// Gets an array with the bitmap colors
        /// </summary>
        /// <returns></returns>
        private Color[] GetColorData(Texture2D bitmap)
        {
            var size = bitmap.Width * bitmap.Height;
            var bmpColor = new Color[size];
            this.bitmap.GetData<Color>(bmpColor);
            return bmpColor;
        }
        #endregion

        #region Set Color Data
        /// <summary>
        /// Sets the bitmap colors
        /// </summary>
        /// <param name="buffer"></param>
        private void SetColorData(int mitmap, Rectangle rect, Color[] newData, int size)
        {
            bitmap.SetData<Color>(mitmap, rect, newData, 0, size);
        }
        #endregion
    }
}
