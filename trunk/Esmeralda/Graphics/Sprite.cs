using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Esmeralda.Interfaces;

namespace Esmeralda.Graphics
{
    public abstract class Sprite : IDisposable, Interfaces.IDrawable
    {
        #region Variable Declaration
        protected Texture2D bitmap;
        protected Vector2 position;
        protected Rectangle srcRect;
        protected Color tint;
        protected Vector2 origin;
        protected Vector2 zoom;
        protected float angle;
        protected float z;
        protected bool disposed = false;
        #endregion

        #region Bitmap Access
        /// <summary>
        /// Sets or Gets the sprite bitmap
        /// </summary>
        public Texture2D Bitmap
        {
            get { return bitmap; }
            set { bitmap = value; }
        }
        #endregion

        #region Position Access
        /// <summary>
        /// Sets or Gets the position Vector
        /// </summary>
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion

        #region X pos Access
        /// <summary>
        /// Sets or Gets the X position of the sprite
        /// </summary>
        public float X
        {
            get { return this.position.X; }
            set { this.position.X = value; }
        }
        #endregion

        #region Y pos Access
        /// <summary>
        /// Sets or Gets the Y position of the sprite
        /// </summary>
        public float Y
        {
            get { return this.position.Y; }
            set { this.position.Y = value; }
        }
        #endregion

        #region Rect Access
        /// <summary>
        /// Sets or Gets the source Rectangle of the sprite bitmap
        /// </summary>
        public Rectangle Rect
        {
            get { return srcRect; }
            set { srcRect = value; }
        }
        #endregion

        #region TintColor Access
        /// <summary>
        /// Sets or Gets the Tint color
        /// </summary>
        public Color TintColor
        {
            get { return tint; }
            set { tint = value; }
        }
        #endregion

        #region Angle Access
        /// <summary>
        /// Gets or Sets the rotation angle
        /// </summary>
        public float Angle
        {
            get { return angle; }
            set { angle = value; }
        }
        #endregion

        #region Origin Access
        public Vector2 Origin
        {
            get { return origin; }
            set { origin = value; }
        }
        #endregion

        #region OX Access
        /// <summary>
        /// Gets or Sets the X origin 
        /// </summary>
        public float OX
        {
            get { return this.origin.X; }
            set { this.origin.X = value; }
        }
        #endregion

        #region OY Access
        /// <summary>
        /// Gets or Sets the X origin 
        /// </summary>
        public float OY
        {
            get { return this.origin.Y; }
            set { this.origin.Y = value; }
        }
        #endregion

        #region Zoom Access
        /// <summary>
        /// Gets or Sets the sprite Zoom
        /// </summary>
        public Vector2 Zoom
        {
            get { return zoom; }
            set { zoom = value; }
        }
        #endregion

        #region ZoomX Access
        /// <summary>
        /// Gets or Sets the ZoomX
        /// </summary>
        public float ZoomX
        {
            get { return this.zoom.X; }
            set { this.zoom.X = value; }
        }
        #endregion

        #region ZoomY Access
        /// <summary>
        /// Gets or Sets the ZoomY
        /// </summary>
        public float ZoomY
        {
            get { return this.zoom.Y; }
            set { this.zoom.Y = value; }
        }
        #endregion

        #region Z access
        public float Z
        {
            get { return this.z; }
            set
            {
                if (value < 0 || value > 100) { throw new Exception("Value out of range"); }
                else { this.z = 1 - (value / 100); }
            }
        }
        #endregion

        #region SetRect
        /// <summary>
        /// Sets all the Rect values
        /// </summary>
        /// <param name="x">new x value</param>
        /// <param name="y">new y value</param>
        /// <param name="width">new width value</param>
        /// <param name="height">new height value</param>
        public void SetRect(int x, int y, int width, int height)
        {
            this.srcRect.X = x;
            this.srcRect.Y = y;
            this.srcRect.Width = width;
            this.srcRect.Height = height;
        }
        #endregion

        #region SetRectX
        /// <summary>
        /// Sets the X value of the rect
        /// </summary>
        /// <param name="value">new X value</param>
        public void SetRectX(int value)
        {
            this.srcRect.X = value;
        }
        #endregion

        #region SetRectY
        /// <summary>
        /// Sets the Y value of the rect
        /// </summary>
        /// <param name="value">new Y value</param>
        public void SetRectY(int value)
        {
            this.srcRect.Y = value;
        }
        #endregion

        #region SetRectWidth
        /// <summary>
        /// Sets the Width value of the rect
        /// </summary>
        /// <param name="value">new Width value</param>
        public void SetRectWidth(int value)
        {
            this.srcRect.Width = value;
        }
        #endregion

        #region SetRectHeight
        /// <summary>
        /// Sets the Height value of the rect
        /// </summary>
        /// <param name="value">new Height value</param>
        public void SetRectHeight(int value)
        {
            this.srcRect.Height = value;
        }
        #endregion

        #region Update
        /// <summary>
        /// Sprite Update
        /// </summary>
        public virtual void Update() { }
        #endregion

        #region Draw
        /// <summary>
        /// Draws the sprite on the selected SpriteBatch
        /// </summary>
        /// <param name="spriteBatch"></param>
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(bitmap, position, srcRect, tint, angle, origin, zoom,
                SpriteEffects.None, z);
            spriteBatch.End();
        }
        #endregion

        #region Dispose
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(!this.disposed)
            {
                if(disposing)
                {
                    this.bitmap.Dispose();
                }
                disposed = true;
            }
        }
        ~Sprite()
        {
            Dispose(false);
        }
        #endregion

        #region Clone
        /// <summary>
        /// Returns a copy of the Sprite
        /// </summary>
        /// <returns></returns>
        public virtual Sprite Clone()
        {
            return (Sprite)this.MemberwiseClone();
        }
        #endregion
    }
}
