using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esmeralda.Framework.Tilemap
{
    public class TileMapData
    {
        #region Variable Declaration
        private List<uint> map;
        private int width;
        private int height;
        #endregion

        #region Accessors
        public int Width { get { return this.width; } }
        public int Height { get { return this.height; } }
        #endregion
    }
}
