using System;
using Esmeralda.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Esmeralda.Interfaces
{
    public interface IScene
    {
        void Initialize(Game parent, SpriteBatch spriteBatch);
        void Refresh();
        void Dispose();
    }
}
