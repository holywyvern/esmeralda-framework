using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Esmeralda.Framework.Tilemap
{
    public abstract class TileData : IDrawable
    {
        #region Class Variable Declaration
        protected static int size = 32;
        #endregion

        #region Instance Variable Declaration
        protected uint id;
        protected Graphics.SpriteBase sprite;
        protected Rectangle tile;
        #endregion

        #region ID accessor
        /// <summary>
        /// Gets the Tile ID
        /// </summary>
        public uint ID { get { return id; } }
        #endregion

        #region Bitmap Accessor
        /// <summary>
        /// Gets the tile Bitmap 
        /// </summary>
        public Graphics.SpriteBase Sprite
        { get { return this.sprite; } }
        #endregion

        #region Tile Size Remaper
        /// <summary>
        /// Sets the tile Size
        /// </summary>
        public static int Size
        {
            get { return TileData.size; }
            set { TileData.size = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new TileData
        /// </summary>
        /// <param name="id">Tile ID</param>
        /// <param name="bitmap">Bitmap</param>
        public TileData(uint id, Graphics.SpriteBase bitmap)
        {
            this.id = id;
            this.sprite = bitmap;
            this.tile = this.CalculateRect();
        }
        #endregion

        #region Calculate Rect
        protected Rectangle CalculateRect()
        {
            var width = this.sprite.Bitmap.Width;
            var height = this.sprite.Bitmap.Height;
            var hTiles = width / TileData.size;
            var vTiles = height / TileData.size;
            int rectY = (int)(this.id / hTiles);
            int rectX = (int)(this.id % hTiles);
            return new Rectangle(rectX, rectY, TileData.size, TileData.size);
        }
        #endregion
    }
}
