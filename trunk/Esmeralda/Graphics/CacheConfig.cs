using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;

namespace Esmeralda.Graphics
{
    public class CacheConfig
    {
        #region Variable Declaration
        private Dictionary<string, string> paths;
        private ContentManager contentManager;
        #endregion

        #region Constructor Content Manager Only
        /// <summary>
        /// CacheConfig sets the game graphics contents
        /// </summary>
        /// <param name="contentManager">the content manager</param>
        public CacheConfig(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            this.paths = new Dictionary<string, string>();
            this.paths.Add("MAPS", "");
            this.paths.Add("CHARACTERS", "");
            this.paths.Add("SYSTEM", "");
        }
        #endregion

        #region Set Map Dir
        /// <summary>
        /// Sets the Cache configuration to find the Map Graphics Directory
        /// </summary>
        /// <param name="dir">the relative path to the Map Graphics Directory</param>
        public void SetMapDir(string dir)
        {
            this.paths["MAPS"] = dir;
        }
        #endregion

        #region Set System Dir
        /// <summary>
        /// Sets the Cache configuration to find the System Graphics Directory
        /// </summary>
        /// <param name="dir">the relative path to the System Graphics Directory</param>
        public void SetSystemDir(string dir)
        {
            this.paths["SYSTEM"] = dir;
        }
        #endregion

        #region Set Characters
        /// <summary>
        /// Sets the Cache configuration to find the Characters Graphics Directory 
        /// </summary>
        /// <param name="dir">the relative path to the Characters Graphics Directory</param>
        public void SetCharactersDir(string dir)
        {
            this.paths["CHARACTERS"] = dir;
        }
        #endregion

        #region Set Custom
        /// <summary>
        /// Sets a directory to be found 
        /// </summary>
        /// <param name="name">Name of folder</param>
        /// <param name="dir">the relative path to the Graphics Directory</param>
        public void SetCustomDir(string name, string dir)
        {
            if (paths.ContainsKey(name))
            { this.paths.Add(name, dir); }
            else
            { this.paths[name] = dir; }
        }
        #endregion

        #region Get Content Manager
        /// <summary>
        /// Gets the Content Manager
        /// </summary>
        public ContentManager ContentManager
        {
            get { return this.contentManager; }
        }
        #endregion

        #region Get Paths
        /// <summary>
        /// Gets the paths of images
        /// </summary>
        public Dictionary<string, string> Paths
        {
            get { return this.paths; }
        }
        #endregion
    }
}
