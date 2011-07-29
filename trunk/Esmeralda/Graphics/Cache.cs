using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Esmeralda.Graphics
{
    public static class Cache
    {
        #region Variable Declaration
        private static Dictionary<string, Texture2D> images = new Dictionary<string, Texture2D>();
        private static CacheConfig config;
        #endregion

        #region Set Configuration
        public static void SetConfig(CacheConfig config)
        {
            Cache.images = new Dictionary<string, Texture2D>();
            Cache.config = config;
        }
        #endregion

        #region Load
        /// <summary>
        /// Loads a Texture2D
        /// </summary>
        /// <param name="type">Type of bitmap Refering a path on config</param>
        /// <param name="image">Name of the bitmap</param>
        /// <returns></returns>
        public static Texture2D Load(string type, string image)
        {
            Texture2D result;
            if (Cache.images.ContainsKey(type + image))
            { result = Cache.images[type + image]; }
            else
            {
                string path = String.Format(@"{0}\{1}",Cache.config.Paths[type], image);
                result = Cache.config.ContentManager.Load<Texture2D>(path);
            }
            return result;
        }
        #endregion

        #region Clear
        /// <summary>
        /// Destroys all the images Loaded
        /// </summary>
        public static void Clear()
        {
            Cache.images.Clear();
            Cache.config.ContentManager.Unload();
        }
        #endregion
    }
}
