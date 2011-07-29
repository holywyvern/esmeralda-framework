using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Esmeralda.Framework
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        #region Variable Declaration
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;
        protected SceneBase standBy;
        protected SceneBase actualScene;
        #endregion

        #region Constructor
        public Game():base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        #endregion

        #region Initialize
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(graphics.GraphicsDevice);
            base.Initialize();
            Input.Reader.Initialize(this.Window.Handle);
        }
        #endregion

        #region Update
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Input.Reader.Update();
            this.Scene.Refresh();
            base.Update(gameTime);
            base.Draw(gameTime);
        }
        #endregion

        #region ActualScene Accessor
        /// <summary>
        /// Gets or sets the actual game Scene
        /// </summary>
        public SceneBase Scene
        {
            get { return this.actualScene; }
            set { this.actualScene = value; }
        }
        #endregion

        #region StandBy 
        /// <summary>
        /// Gets the actual StandByList
        /// </summary>
        public SceneBase StandBy
        {
            get { return this.standBy; }
            set { this.standBy = value; }
        }
        #endregion
    }
}
