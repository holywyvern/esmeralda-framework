using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Esmeralda.Framework
{
    public abstract class SceneBase : Scene
    {
        #region Refresh Seal
        public sealed override void Refresh()
        {
            base.Refresh();
        }
        #endregion

        public sealed override void Initialize(Game parent, SpriteBatch spriteBatch)
        {
            base.Initialize(parent, spriteBatch);
            Start();
        }

        protected abstract void Start();

        #region SetScene
        /// <summary>
        /// Sets the actual scene to the specified scene
        /// </summary>
        /// <param name="scene">next scene</param>
        protected void SetScene(SceneBase scene)
        {
            parent.Scene = scene;
            parent.Scene.Initialize(parent, this.spriteBatch);
        }
        #endregion

        #region Stand by
        /// <summary>
        /// Make this scene to wait until another scene ends
        /// </summary>
        /// <param name="replacer"></param>
        protected void Standby(SceneBase replacer)
        {
            this.parent.StandBy = this.parent.Scene;
            parent.Scene = replacer;
        }
        #endregion

        #region Resume
        /// <summary>
        /// Resumes an scene
        /// </summary>
        protected void ResumeScene()
        {
            parent.Scene = parent.StandBy;
        }
        #endregion
    }
}
