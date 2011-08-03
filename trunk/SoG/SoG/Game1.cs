using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Esmeralda.Graphics;
using Esmeralda.Sound;

namespace SoG
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Esmeralda.Framework.Game
    {
        #region Constructor
        public Game1() : base()
        {
            var cacheConfig = new CacheConfig(this.Content);
            cacheConfig.SetMapDir("MAPS");
            Cache.SetConfig(cacheConfig);

            var audioConfig = new AudioConfig(this.Content);
            audioConfig.SetBgmDir(@"Audio\BGM");
            audioConfig.SetBgsDir(@"Audio\BGS");
            audioConfig.SetMeDir(@"Audio\Me");
            audioConfig.SetSeDir(@"Audio\Se");
            Audio.SetConfig(audioConfig);
        }
        #endregion
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
            this.Scene = new SceneTest();
            this.Scene.Initialize(this, this.spriteBatch);
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
