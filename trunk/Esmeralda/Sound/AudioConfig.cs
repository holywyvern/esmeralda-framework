using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;

namespace Esmeralda.Sound
{
    public class AudioConfig
    {

        #region Variable Declaration
        private ContentManager contentManager;
        private Dictionary<string, string> paths;
        #endregion

        #region Constructor
        /// <summary>
        /// AudioConfig sets the game audio locations
        /// </summary>
        /// <param name="contentManager">the content manager</param>
        public AudioConfig(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            this.paths = new Dictionary<string, string>();
            this.paths.Add("BGM", "");
            this.paths.Add("BGS", "");
            this.paths.Add("ME", "");
            this.paths.Add("SE", "");
        }
        #endregion

        #region Set Path Methods
        /// <summary>
        /// Sets the audio to find Background Musics files here
        /// </summary>
        /// <param name="dir">the location of the directory</param>
        public void SetBgmDir(string dir)
        {
            this.paths["BGM"] = dir;
        }

        /// <summary>
        /// Sets the audio to find Back Ground Sounds files here
        /// </summary>
        /// <param name="dir">the location of the directory</param>
        public void SetBgsDir(string dir)
        {
            this.paths["BGS"] = dir;
        }

        /// <summary>
        /// Sets the audio to find Musical Effects files here
        /// </summary>
        /// <param name="dir">the location of the directory</param>
        public void SetMeDir(string dir)
        {
            this.paths["Me"] = dir;
        }

        /// <summary>
        /// Sets the audio to find Sound effects files here
        /// </summary>
        /// <param name="dir">the location of the directory</param>
        public void SetSeDir(string dir)
        {
            this.paths["Se"] = dir;
        }
        #endregion

        #region Get content Manager
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
        /// Gets the paths of audio data
        /// </summary>
        public Dictionary<string, string> Paths
        {
            get { return this.paths; }
        }
        #endregion
    }
}
