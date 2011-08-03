using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Esmeralda.Framework.Tilemap
{
    public class Tile
    {
        #region Variable Declaration
        private TileData data;
        private ITileEffect effect;
        #endregion

        #region Update
        public void Update()
        {
            effect.Apply();
        }
        #endregion

        #region Draw
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(data.Sprite, position, Color.White);
            spriteBatch.End();
        }
        #endregion

        #region TileData
        public TileData TileData
        {
            get { return this.data; }
            set { this.data = value; }
        }
        #endregion

        #region Effect
        public ITileEffect Effect
        {
            get { return this.effect; }
            set { this.effect = value; }
        }
        #endregion

        #region Constructor
        public Tile(TileData data, ITileEffect effect)
        {
            this.effect = effect;
            this.data = data;
        }
        #endregion
    }
}
