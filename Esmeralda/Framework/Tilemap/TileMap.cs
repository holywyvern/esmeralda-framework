using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Esmeralda.Framework.Tilemap
{
    public class TileMap : Interfaces.IDrawable
    {
        #region Variable Declaration
        private TilemapData data;
        private bool disposed;
        #endregion

        #region Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(Tile tile in data.Tiles)
            {
                int x = data.Tiles.IndexOf(tile) % data.Width;
                int y = data.Tiles.IndexOf(tile) / data.Width;
                Vector2 position = new Vector2(x,y);
                tile.Draw(spriteBatch, position);
            }
        }
        #endregion

        #region Update
        public void Update()
        {
            foreach (Tile tile in data.Tiles)
            {
                tile.Update();
            }
        }
        #endregion

        #region Dipose
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
                    this.data = null;
                }
                disposed = true;
            }
        }
        ~TileMap()
        {
            Dispose(false);
        }
        #endregion
    }
}
