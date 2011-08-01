using System;
using System.Collections.Generic;


namespace Esmeralda.Framework.Tilemap
{
    public class TilemapData
    {
        #region Variable Declaration
        private List<Tile> tiles;
        private int width;
        private int height;
        #endregion

        #region Set/Get Tile
        public Tile this[int x, int y]
        {
            get { return tiles[y / this.width + x]; }
            set { tiles[y / this.width + x] = value; }
        }
        #endregion

        #region GetTiles
        public List<Tile> Tiles
        {
            get { return this.tiles; }
            set { this.tiles = value; }
        }
        #endregion

        #region Set/Get Width
        public int Width
        {
            get { return this.width; }
            set { this.width = value; }
        }
        #endregion

        #region Set/Get Height
        public int Height
        {
            get { return this.height; }
            set { this.height = value; }
        }
        #endregion

        #region Constructor
        public TilemapData(List<Tile> tiles, int width, int height)
        {
            this.tiles = tiles;
            this.width = width;
            this.height = height;
        }
        #endregion
    }
}
