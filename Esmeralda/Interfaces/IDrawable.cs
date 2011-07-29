using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Esmeralda.Interfaces
{
    public interface IDrawable
    {
        void Draw(SpriteBatch spriteBatch);
        void Update();
    }
}
