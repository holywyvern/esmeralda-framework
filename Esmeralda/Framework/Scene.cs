using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Esmeralda.Framework
{
    public abstract class Scene : Interfaces.IScene
    {
        #region Variables
        protected Dictionary<string, Interfaces.IDrawable> objects;
        protected SpriteBatch spriteBatch;
        protected Framework.Game parent;
        #endregion

        #region Initialize
        /// <summary>
        /// Scene Initialize logic
        /// </summary>
        public virtual void Initialize(Framework.Game parent, SpriteBatch spriteBatch)
        {
            objects = new Dictionary<string, Interfaces.IDrawable>();
            this.parent = parent;
            this.spriteBatch = spriteBatch;
        }
        #endregion

        #region Generic Update
        /// <summary>
        /// Frame update generic logic
        /// </summary>
        public virtual void Refresh() 
        {
            this.Update();
            foreach (Interfaces.IDrawable sprite in this.objects.Values)
            {
                sprite.Update();
            }
            this.spriteBatch.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Blue);
            foreach (Interfaces.IDrawable sprite in this.objects.Values)
            {
                sprite.Draw(this.spriteBatch);
            }
        }
        #endregion

        #region Self Update
        /// <summary>
        /// Frame Update
        /// </summary>
        protected virtual void Update() { }
        #endregion

        #region Dispose
        public virtual void Dispose() 
        {
            foreach (Interfaces.IDrawable sprite in this.objects.Values) { sprite.Dispose(); }
            this.objects.Clear();
            this.objects = null;
            Esmeralda.Graphics.Cache.Clear();
        }
        #endregion
    }
}
