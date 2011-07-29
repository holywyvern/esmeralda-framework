using System;
using System.Collections.Generic;
using Esmeralda;
using Esmeralda.Graphics;
using Esmeralda.Input;
using Esmeralda.Framework;
using XNAGraph = Microsoft.Xna.Framework.Graphics;

namespace SoG
{
    public class SceneTest : Esmeralda.Framework.SceneBase
    {
        protected override void Start()
        {
            objects.Add("caja", new SpriteBase(Cache.Load("MAPS", "box")));
        }

        protected override void Update()
        {
            objects["caja"].X = Mouse.Position.X;
            objects["caja"].Y = Mouse.Position.Y;
            if(Keyboard.Trigger(Keys.RETURN))
            {
                SetScene(new SceneTest2());
            }
        }
    }
}
